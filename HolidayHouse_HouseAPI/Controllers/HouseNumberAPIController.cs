using AutoMapper;
using HolidayHouse_HouseAPI.Migrations;
using HolidayHouse_HouseAPI.Models;
using HolidayHouse_HouseAPI.Models.Dto;
using HolidayHouse_HouseAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HolidayHouse_HouseAPI.Controllers
{
    [Route("api/HouseNumberAPI")]
    [ApiController]
    public class HouseNumberAPIController : ControllerBase
    {
        private readonly APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IHouseNumberRepository _dbHouseNumbers;
        private readonly IHouseRepository _dbHouse;
        public HouseNumberAPIController(IHouseNumberRepository db, IMapper mapper, IHouseRepository dbHouse)
        {
            _dbHouseNumbers = db;
            _dbHouse = dbHouse;
            _mapper = mapper;
            this._response = new();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = "GetHouseNumbers")]
        public async Task<ActionResult<APIResponse>> GetHouseNumbers()
        {
            try
            {
                IEnumerable<HouseNumber> houseNumbers = await _dbHouseNumbers.GetAllAsync();
                _response.Result = _mapper.Map<List<HouseNumberDTO>>(houseNumbers);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{houseNo:int}", Name = "GetHouseNumber")]
        public async Task<ActionResult<APIResponse>> GetHouseNumber(int houseNo)
        {
            try
            {
                if (houseNo == 0) 
                { 
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                HouseNumber houseNumber = await _dbHouseNumbers.GetAsync(u => u.HouseNo == houseNo);

                if (houseNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<HouseNumberDTO>(houseNumber);
                _response.StatusCode = HttpStatusCode.OK;   
                return Ok(_response);
            }
            catch (Exception ex)
            { 
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateHouseNumber([FromBody] HouseNumberCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                if (await _dbHouse.GetAsync(u => u.Id == createDTO.HouseID) == null)
                {
                    ModelState.AddModelError("CustomError", $"Villa with {createDTO.HouseID} id doesn't exit!");
                    return BadRequest(ModelState);
                }

                HouseNumber houseNumber = _mapper.Map<HouseNumber>(createDTO);
                houseNumber.CreatedDate = DateTime.Now;

                await _dbHouseNumbers.CreateAsync(houseNumber);
                _response.Result = _mapper.Map<HouseNumberDTO>(houseNumber);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetHouseNumber", new { houseNo = houseNumber.HouseNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{houseNo:int}", Name = "DeleteHouseNumber")]
        public async Task<ActionResult<APIResponse>> DeleteHouseNumber(int houseNo)
        {
            try
            {
                if (houseNo == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                HouseNumber houseNumber = await _dbHouseNumbers.GetAsync(u => u.HouseNo == houseNo);
                if (houseNumber == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbHouseNumbers.RemoveAsync(houseNumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{houseNo:int}", Name = "UpdateHouseNumber")]
        public async Task<ActionResult<APIResponse>> UpdateHouseNumber(int houseNo, [FromBody] HouseNumberUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || updateDTO.HouseNo != houseNo)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return BadRequest(_response);
                }

                if (await _dbHouse.GetAsync(u => u.Id == updateDTO.HouseID) == null)
                {
                    ModelState.AddModelError("CustomError", $"Villa with {updateDTO.HouseID} id doesn't exit!");
                    return BadRequest(ModelState);
                }

                HouseNumber houseNumber = _mapper.Map<HouseNumber>(updateDTO); 

                await _dbHouseNumbers.UpdateAsync(houseNumber);

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
