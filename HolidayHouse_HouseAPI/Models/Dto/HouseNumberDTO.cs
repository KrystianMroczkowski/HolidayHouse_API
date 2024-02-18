﻿using System.ComponentModel.DataAnnotations;

namespace HolidayHouse_HouseAPI.Models.Dto
{
    public class HouseNumberDTO
    {
        [Required]
        public int HouseNo { get; set; }
        public string SpecialDetails { get; set; }
        [Required]
        public int HouseID { get; set; }
    }
}
