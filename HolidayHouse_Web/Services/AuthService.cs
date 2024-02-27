using HolidayHouse_Utility;
using HolidayHouse_Web.Models;
using HolidayHouse_Web.Models.Dto;
using HolidayHouse_Web.Services.IServices;

namespace HolidayHouse_Web.Services
{
    public class AuthService : IAuthService
    { 
        private readonly IHttpClientFactory _clientFactory;
		private readonly IBaseService _baseService;
		private string houseUrl;

        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration, IBaseService baseService)
        {
            _clientFactory = clientFactory;
            _baseService = baseService;
            houseUrl = configuration.GetValue<string>("ServiceUrls:HouseAPI");
        }

        public async Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = houseUrl + "/api/UserAuth/login"
            }, withBearer:false);
        }

        public async Task<T> RegisterAsync<T>(RegistrationRequestDTO obj)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = houseUrl + "/api/UserAuth/register"
            }, withBearer:false);
        }
    }
}
