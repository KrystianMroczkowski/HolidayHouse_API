using HolidayHouse_Utility;
using HolidayHouse_Web.Models;
using HolidayHouse_Web.Models.Dto;
using HolidayHouse_Web.Services.IServices;
using Newtonsoft.Json.Linq;

namespace HolidayHouse_Web.Services
{
    public class HouseNumberService : BaseService, IHouseNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string houseUrl;
        public HouseNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            houseUrl = configuration.GetValue<string>("ServiceUrls:HouseAPI");
        }

        public Task<T> CreateAsync<T>(HouseNumberCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = houseUrl + "/api/HouseNumberAPI",
                Token = token,
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = houseUrl + "/api/HouseNumberAPI/" + id,
                Token = token,
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = houseUrl + "/api/HouseNumberAPI",
                Token = token,
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = houseUrl + "/api/HouseNumberAPI/" + id,
                Token = token,
            });
        }

        public Task<T> UpdateAsync<T>(HouseNumberUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = houseUrl + "/api/HouseNumberAPI",
                Token = token,
            });
        }
    }
}
