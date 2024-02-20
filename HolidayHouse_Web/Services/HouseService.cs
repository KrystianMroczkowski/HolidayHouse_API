using HolidayHouse_Utility;
using HolidayHouse_Web.Models;
using HolidayHouse_Web.Models.Dto;
using HolidayHouse_Web.Services.IServices;

namespace HolidayHouse_Web.Services
{
    public class HouseService : BaseService, IHouseService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string houseUrl;
        public HouseService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            houseUrl = configuration.GetValue<string>("ServiceUrls:HouseAPI");
        }

        public Task<T> CreateAsync<T>(HouseCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = houseUrl + "/api/HouseAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = houseUrl + "/api/HouseAPI/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = houseUrl + "/api/HouseAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = houseUrl + "/api/HouseAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(HouseUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = houseUrl + "/api/HouseAPI"
            });
        }
    }
}
