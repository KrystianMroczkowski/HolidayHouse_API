using AutoMapper.Internal;
using HolidayHouse_Utility;
using HolidayHouse_Web.Models;
using HolidayHouse_Web.Models.Dto;
using HolidayHouse_Web.Services.IServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HolidayHouse_Web.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClient, ITokenProvider tokenProvider)
        {
            responseModel = new();
            _tokenProvider = tokenProvider;
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest, bool withBearer = true)
        {
            try
            {
                var client = httpClient.CreateClient("HouseAPI");

				var messageFactory = () =>
				{
					HttpRequestMessage message = new();
					if (apiRequest.ContentType == SD.ContentType.MultipartFormData)
					{
						message.Headers.Add("Accept", "*/*");
					}
					else
					{
						message.Headers.Add("Accept", "application/json");
					}
					message.RequestUri = new Uri(apiRequest.Url);

					if (withBearer && _tokenProvider.GetToken() != null)
					{
						var token = _tokenProvider.GetToken();
						client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
					}

					if (apiRequest.ContentType == SD.ContentType.MultipartFormData)
					{
						var content = new MultipartFormDataContent();

						foreach (var prop in apiRequest.Data.GetType().GetProperties())
						{
							var value = prop.GetValue(apiRequest.Data);
							if (value is FormFile)
							{
								var file = (FormFile)value;
								if (file != null)
								{
									content.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
								}
							}
							else
							{
								content.Add(new StringContent(value == null ? "" : value.ToString()), prop.Name);
							}
						}
						message.Content = content;
					}
					else
					{
						if (apiRequest.Data != null)
						{
							message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
						}
					}

					switch (apiRequest.ApiType)
					{
						case SD.ApiType.POST:
							message.Method = HttpMethod.Post;
							break;
						case SD.ApiType.PUT:
							message.Method = HttpMethod.Put;
							break;
						case SD.ApiType.DELETE:
							message.Method = HttpMethod.Delete;
							break;
						default:
							message.Method = HttpMethod.Get;
							break;
					}

					return message;
				};

                HttpResponseMessage apiResponse = null;

                apiResponse = await SendWithRefreshTokenAsync(client, messageFactory, withBearer);
				var apiContent = await apiResponse.Content.ReadAsStringAsync();

				try
                {
                    APIResponse ApiResponse = JsonConvert.DeserializeObject<APIResponse>(apiContent);
                    if (ApiResponse != null && (apiResponse.StatusCode==System.Net.HttpStatusCode.BadRequest 
                        || apiResponse.StatusCode == System.Net.HttpStatusCode.NotFound))
                    {
						ApiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
						ApiResponse.IsSuccess = false;
                        var res = JsonConvert.SerializeObject(ApiResponse);
                        var returnObj = JsonConvert.DeserializeObject<T>(res);
                        return returnObj;

                    }
                }
                catch (Exception ex)
                {
                    var exceptionResponse = JsonConvert.DeserializeObject<T>(apiContent);
                    return exceptionResponse;
				}
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessages = new List<string> { ex.Message.ToString() },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
        }

		private async Task<HttpResponseMessage> SendWithRefreshTokenAsync(HttpClient httpClient, 
			Func<HttpRequestMessage> httpRequestMessageFactory, bool withBearer = true)
		{
			if (!withBearer)
			{
				return await httpClient.SendAsync(httpRequestMessageFactory());
			}
			else
			{
				TokenDTO tokenDTO = _tokenProvider.GetToken();
				if (tokenDTO != null && !string.IsNullOrEmpty(tokenDTO.AccessToken))
				{
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenDTO.AccessToken);
				} 
				
				try
				{
					var response = await httpClient.SendAsync(httpRequestMessageFactory());
                    if (response.IsSuccessStatusCode)
                    {
						return response;    
                    }
					return response;
                }
				catch (Exception ex)
				{
					throw;
				}
			}
			
		}
    }
}
