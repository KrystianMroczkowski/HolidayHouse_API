using HolidayHouse_HouseAPI.Models;
using HolidayHouse_HouseAPI.Models.Dto;

namespace HolidayHouse_HouseAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<TokenDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);
		Task<TokenDTO> RefreshAccessToken(TokenDTO tokenDTO);
	}
}
