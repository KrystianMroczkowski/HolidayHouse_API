using HolidayHouse_Web.Models.Dto;

namespace HolidayHouse_Web.Services.IServices
{
	public interface ITokenProvider
	{
		void SetToken(TokenDTO tokenDTO);
		TokenDTO? GetToken();
		void ClearToken();
	}
}
