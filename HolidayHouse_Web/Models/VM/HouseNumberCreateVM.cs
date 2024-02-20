using HolidayHouse_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HolidayHouse_Web.Models.VM
{
	public class HouseNumberUpdateVM
	{
		public HouseNumberUpdateVM() 
		{
			HouseNumber = new HouseNumberUpdateDTO();
		}

		public HouseNumberUpdateDTO HouseNumber { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> HouseList { get; set; }
	}
}
