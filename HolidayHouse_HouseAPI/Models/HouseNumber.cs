using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolidayHouse_HouseAPI.Models
{
    public class HouseNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HouseNo { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [ForeignKey("House")]
        public int HouseID { get; set; }
        public House House { get; set; }
    }
}
