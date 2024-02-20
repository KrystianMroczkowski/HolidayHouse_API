using HolidayHouse_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HolidayHouse_Web.Models.VM
{
	public class HouseNumberCreateVM
	{
		public HouseNumberCreateVM() 
		{
			HouseNumber = new HouseNumberCreateDTO();
		}

		public HouseNumberCreateDTO HouseNumber { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> HouseList { get; set; }
	}
}
