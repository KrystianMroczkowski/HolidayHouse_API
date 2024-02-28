using AutoMapper;
using HolidayHouse_Utility;
using HolidayHouse_Web.Models;
using HolidayHouse_Web.Models.Dto;
using HolidayHouse_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HolidayHouse_Web.Controllers
{
    public class HouseController : Controller
    {
        private readonly IHouseService _houseService;
        private readonly IMapper _mapper;

        public HouseController(IHouseService houseService, IMapper mapper)
        {
            _houseService = houseService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexHouse()
        {
            List<HouseDTO> list = new();

            var response = await _houseService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess != false) 
            {
                list = JsonConvert.DeserializeObject<List<HouseDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateHouse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateHouse(HouseCreateDTO model)
		{
            if (ModelState.IsValid)
            {
                var response = await _houseService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
					TempData["success"] = "House created successfully";
                    return RedirectToAction(nameof(IndexHouse));
                }
            }
            TempData["error"] = "Error encountered";
            return View(model);
		}
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateHouse(int houseId)
		{
            var response = await _houseService.GetAsync<APIResponse>(houseId);
            if (response != null && response.IsSuccess != false)
            {
                HouseDTO model = JsonConvert.DeserializeObject<HouseDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<HouseUpdateDTO>(model));
            }
			return NotFound();
		}

        [HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateHouse(HouseUpdateDTO model)
		{
			if (ModelState.IsValid)
			{
				var response = await _houseService.UpdateAsync<APIResponse>(model);
				if (response != null && response.IsSuccess)
				{
                    TempData["success"] = "House updated successfully";
                    return RedirectToAction(nameof(IndexHouse));
				}
			}
            TempData["error"] = "Error encountered";
            return View(model);
		    }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteHouse(int houseId)
		{
			var response = await _houseService.GetAsync<APIResponse>(houseId);
			if (response != null && response.IsSuccess != false)
			{
				HouseDTO model = JsonConvert.DeserializeObject<HouseDTO>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteHouse(HouseDTO model)
		{
			var response = await _houseService.DeleteAsync<APIResponse>(model.Id);
			if (response != null && response.IsSuccess)
			{
                TempData["success"] = "House deleted successfully";
                return RedirectToAction(nameof(IndexHouse));
			}
            TempData["error"] = "Error encountered";
            return View(model);
		}
	}
}
