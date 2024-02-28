using HolidayHouse_Web.Models;

namespace HolidayHouse_Web.Services.IServices
{
	public interface IApiMessageRequestBuilder
	{
		HttpRequestMessage Build(APIRequest apiRequest);
	}
}
