using HolidayHouse_Utility;
using HolidayHouse_Web.Models;
using HolidayHouse_Web.Models.Dto;
using HolidayHouse_Web.Services.IServices;

namespace HolidayHouse_Web.Services
{
    public class HouseService : IHouseService
    {
        private readonly IHttpClientFactory _clientFactory;
		private readonly IBaseService _baseService;
		private string houseUrl;
        public HouseService(IHttpClientFactory clientFactory, IConfiguration configuration, IBaseService baseService)
        {
            _clientFactory = clientFactory;
            _baseService = baseService;
            houseUrl = configuration.GetValue<string>("ServiceUrls:HouseAPI");
        }

        public async Task<T> CreateAsync<T>(HouseCreateDTO dto)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = houseUrl + "/api/HouseAPI",
                ContentType = SD.ContentType.MultipartFormData
            });
        }

        public async Task<T> DeleteAsync<T>(int id)
        {
            return await _baseService.SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = houseUrl + "/api/HouseAPI/" + id,
            });
        }

        public async Task<T> GetAllAsync<T>()
        {
            return await _baseService.SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = houseUrl + "/api/HouseAPI",
            });
        }

        public async Task<T> GetAsync<T>(int id)
        {
            return await _baseService.SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = houseUrl + "/api/HouseAPI/" + id,
            });
        }

        public async Task<T> UpdateAsync<T>(HouseUpdateDTO dto)
        {
            return await _baseService.SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = houseUrl + "/api/HouseAPI",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
