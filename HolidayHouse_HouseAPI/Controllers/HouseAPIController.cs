﻿using AutoMapper;
using HolidayHouse_HouseAPI.Data;
using HolidayHouse_HouseAPI.Models;
using HolidayHouse_HouseAPI.Models.Dto;
using HolidayHouse_HouseAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace HolidayHouse_HouseAPI.Controllers
{
    [Route("api/HouseAPI")]
    [ApiController]
    public class HouseAPIController : ControllerBase
    {
        private readonly IHouseRepository _dbHouse;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public HouseAPIController(IHouseRepository db, IMapper mapper)
        { 
            _mapper = mapper;
            _dbHouse = db;
            this._response = new();
        }

        [HttpGet]
        //[ResponseCache(CacheProfileName = "Default30")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> GetHouses([FromQuery(Name ="filterOccupancy")]int? occupancy,
            [FromQuery] string? search, int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                IEnumerable<House> houseList;

                if (occupancy > 0)
                {
                    houseList = await _dbHouse.GetAllAsync(u => u.Occupancy == occupancy, pageSize:pageSize, pageNumber:pageNumber);
                }
                else
                {
                    houseList = await _dbHouse.GetAllAsync();
                }
                if (!string.IsNullOrEmpty(search))
                {
                    houseList = houseList.Where(u => u.Name.ToLower().Contains(search));
                }
                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination)); 
                _response.Result = _mapper.Map<List<HouseDTO>>(houseList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetHouse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetHouse(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var house = await _dbHouse.GetAsync(u => u.Id == id);
                if (house == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
					_response.IsSuccess = false;
					return NotFound(_response);
                }

                _response.Result = _mapper.Map<HouseDTO>(house);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateHouse([FromBody] HouseCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
					_response.IsSuccess = false;
					return BadRequest(_response);
                }
                if (await _dbHouse.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "House already Exists!");
                    return BadRequest(ModelState);
                }

                House newHouse = _mapper.Map<House>(createDTO);

                await _dbHouse.CreateAsync(newHouse);
                _response.Result = _mapper.Map<HouseDTO>(newHouse);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetHouse", new { id = newHouse.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteHouse")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteHouse(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
					_response.IsSuccess = false;
					return BadRequest(_response);
                }
                var houseToDelete = await _dbHouse.GetAsync(u => u.Id == id);
                if (houseToDelete == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
					_response.IsSuccess = false;
					return NotFound(_response);
                }

                await _dbHouse.RemoveAsync(houseToDelete);

                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut(Name = "UpdateHouse")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateHouse([FromBody]HouseUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
					_response.IsSuccess = false;
					return BadRequest(_response);
                }

                House model = _mapper.Map<House>(updateDTO);

                await _dbHouse.UpdateAsync(model);

                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPatch("{id:int}", Name="UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialHouse(int id, JsonPatchDocument<HouseUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }

            var house = await _dbHouse.GetAsync(u => u.Id == id, tracked: false);
            if (house == null)
            {
                return BadRequest();
            }

            HouseUpdateDTO houseDTO = _mapper.Map<HouseUpdateDTO>(house);

            patchDTO.ApplyTo(houseDTO, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            House houseToUpdate = _mapper.Map<House>(houseDTO);

            await _dbHouse.UpdateAsync(houseToUpdate);

            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;

            return Ok(_response);
        }
    }
}
