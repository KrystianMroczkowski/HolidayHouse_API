using HolidayHouse_HouseAPI.Models;
using HolidayHouse_HouseAPI.Models.Dto;

namespace HolidayHouse_HouseAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
