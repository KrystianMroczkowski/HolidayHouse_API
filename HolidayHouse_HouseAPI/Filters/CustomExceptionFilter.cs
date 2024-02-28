using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HolidayHouse_HouseAPI.Filters
{
	public class CustomExceptionFilter : IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
			if (context.Exception is FileNotFoundException fileNotFoundException)
			{
				context.Result = new ObjectResult("File not found but handled in filter")
				{
					StatusCode = 503
				};
				context.ExceptionHandled = true;
			}
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{

		}
	}
}
