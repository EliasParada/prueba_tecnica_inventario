using Microsoft.AspNetCore.Identity;

namespace StockWebEliasParada.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
    }
}
