using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HolidayHouse_HouseAPI.Controllers
{
	[Route("ErrorHandling")]
	[ApiController]
	[AllowAnonymous]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class ErrorHandlingController : ControllerBase
	{
		[Route("ProcessError")]
		public IActionResult ProcessError([FromServices] IHostEnvironment hostEnvironment)
		{
			if (hostEnvironment.IsDevelopment())
			{
				var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
				return Problem(
					detail: feature.Error.StackTrace,
					title: feature.Error.Message,
					instance: hostEnvironment.EnvironmentName
					);
			}
			else
			{
				return Problem();
			}
		}
	}
}
