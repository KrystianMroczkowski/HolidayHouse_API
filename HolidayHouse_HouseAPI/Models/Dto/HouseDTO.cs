using System.ComponentModel.DataAnnotations;

namespace HolidayHouse_HouseAPI.Models.Dto
{
    public class HouseDTO
    {
        [Required]
        public int HouseNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
