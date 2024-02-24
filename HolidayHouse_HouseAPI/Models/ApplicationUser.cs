using Microsoft.AspNetCore.Identity;

namespace HolidayHouse_HouseAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }    
    }
}
