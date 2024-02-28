using AutoMapper;
using HolidayHouse_Utility;
using HolidayHouse_Web.Models;
using HolidayHouse_Web.Models.Dto;
using HolidayHouse_Web.Models.VM;
using HolidayHouse_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HolidayHouse_Web.Controllers
{
	public class HouseNumberController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IHouseNumberService _houseNumberService;
		private readonly IHouseService _houseService;

		public HouseNumberController(IMapper mapper, IHouseNumberService houseNumberService, IHouseService houseService)
		{
			_mapper = mapper;
			_houseNumberService = houseNumberService;
			_houseService = houseService;
		}

		public async Task<IActionResult> IndexHouseNumber()
		{
			List<HouseNumberDTO> list = new();

			var response = await _houseNumberService.GetAllAsync<APIResponse>();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<HouseNumberDTO>>(Convert.ToString(response.Result));
			}
			return View(list);
		}
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateHouseNumber()
		{
			HouseNumberCreateVM model = new();

			var responseHouse = await _houseService.GetAllAsync<APIResponse>();
			if (responseHouse != null && responseHouse.IsSuccess)
			{
				model.HouseList = JsonConvert.DeserializeObject<List<HouseDTO>>(Convert.ToString(responseHouse.Result))
				   .Select(u => new SelectListItem
				   {
					   Text = u.Name,
					   Value = u.Id.ToString()
				   });
			}
			return View(model);
		}

		[HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateHouseNumber(HouseNumberCreateVM model)
		{ 
			if (ModelState.IsValid)
			{
				var response = await _houseNumberService.CreateAsync<APIResponse>(model.HouseNumber);
				if (response != null && response.IsSuccess)
				{
					TempData["success"] = "House Number created successfully";
					return RedirectToAction(nameof(IndexHouseNumber));
				}
				else
				{
					TempData["error"] = (response.ErrorMessages != null && response.ErrorMessages.Count > 0) ?
						response.ErrorMessages[0] : "Error Encountered";
				}
			}
			var responseHouse = await _houseService.GetAllAsync<APIResponse>();
			if (responseHouse != null && responseHouse.IsSuccess)
			{
				model.HouseList = JsonConvert.DeserializeObject<List<HouseDTO>>(Convert.ToString(responseHouse.Result))
				   .Select(u => new SelectListItem
				   {
					   Text = u.Name,
					   Value = u.Id.ToString()
				   });
			}
			return View(model);
		}
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateHouseNumber(int houseNo)
		{
			HouseNumberUpdateVM houseNumberVM = new();
			var response = await _houseNumberService.GetAsync<APIResponse>(houseNo);
			if (response != null && response.IsSuccess)
			{
				HouseNumberDTO model = JsonConvert.DeserializeObject<HouseNumberDTO>(Convert.ToString(response.Result));
				houseNumberVM.HouseNumber = _mapper.Map<HouseNumberUpdateDTO>(model);
			}

			response = await _houseService.GetAllAsync<APIResponse>();
			if (response != null && response.IsSuccess)
			{
				houseNumberVM.HouseList = JsonConvert.DeserializeObject<List<HouseDTO>>(Convert.ToString(response.Result))
					.Select(u => new SelectListItem {
						Text = u.Name,
						Value = u.Id.ToString()
					});
				return View(houseNumberVM);
			}
			else
			{
				TempData["error"] = (response.ErrorMessages != null && response.ErrorMessages.Count > 0) ?
					response.ErrorMessages[0] : "Error Encountered";
			}
			return NotFound();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateHouseNumber(HouseNumberUpdateVM model)
		{
			if (ModelState.IsValid)
			{
				var response = await _houseNumberService.UpdateAsync<APIResponse>(model.HouseNumber);
				if (response != null && response.IsSuccess)
				{
					TempData["success"] = "House Number updated successfully";
					return RedirectToAction(nameof(IndexHouseNumber));
				}
				else
				{
					TempData["error"] = (response.ErrorMessages != null && response.ErrorMessages.Count > 0) ?
						response.ErrorMessages[0] : "Error Encountered";
				}
			}

			var resp = await _houseService.GetAllAsync<APIResponse>();
			if (resp != null && resp.IsSuccess)
			{
				model.HouseList = JsonConvert.DeserializeObject<List<HouseDTO>>(Convert.ToString(resp.Result))
					.Select(u => new SelectListItem
					{
						Text = u.Name,
						Value = u.Id.ToString()
					});
			}

			return View(model);
		}
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteHouseNumber(int houseNo)
		{
			HouseNumberDeleteVM model = new();
			var houseNumberResponse = await _houseNumberService.GetAsync<APIResponse>(houseNo);
			if (houseNumberResponse != null && houseNumberResponse.IsSuccess)
			{
				model.HouseNumber = JsonConvert.DeserializeObject<HouseNumberDTO>(Convert.ToString(houseNumberResponse.Result));
			}

			var houseResponse = await _houseService.GetAllAsync<APIResponse>();
			if (houseResponse != null && houseResponse.IsSuccess)
			{
				model.HouseList = JsonConvert.DeserializeObject<List<HouseDTO>>(Convert.ToString(houseResponse.Result))
					.Select(u => new SelectListItem
					{
						Text = u.Name,
						Value = u.Id.ToString()
					});
			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteHouseNumber(HouseNumberDeleteVM model)
		{
			var response = await _houseNumberService.DeleteAsync<APIResponse>(model.HouseNumber.HouseNo);
			if (response != null && response.IsSuccess)
			{
				TempData["success"] = "House Number deleted successfully";
				return RedirectToAction(nameof(IndexHouseNumber));
			}
			else
			{
				TempData["error"] = (response.ErrorMessages != null && response.ErrorMessages.Count > 0) ?
					response.ErrorMessages[0] : "Error Encountered";
			}
			return View(model);
		}
	}
}
