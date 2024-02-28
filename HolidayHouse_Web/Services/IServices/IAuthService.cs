using HolidayHouse_Web.Models.Dto;

namespace HolidayHouse_Web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LogoutAsync<T>(TokenDTO obj);
        Task<T> LoginAsync<T>(LoginRequestDTO objToCreate);
        Task<T> RegisterAsync<T>(RegistrationRequestDTO objToCreate);
    }
}
