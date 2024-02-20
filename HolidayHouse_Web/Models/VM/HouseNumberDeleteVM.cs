using HolidayHouse_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HolidayHouse_Web.Models.VM
{
	public class HouseNumberDeleteVM
	{
		public HouseNumberDeleteVM() 
		{
			HouseNumber = new HouseNumberDTO();
		}

		public HouseNumberDTO HouseNumber { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> HouseList { get; set; }
	}
}
