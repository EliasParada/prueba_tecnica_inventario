using System.ComponentModel.DataAnnotations;

namespace StockWebEliasParada.Models.Entities
{
    public class Sucursal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreSucursal { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [Phone]
        public string Telefono { get; set; }

        public bool HabilitarSucursal { get; set; } = true;

        public ICollection<Electrodomestico>? Electrodomesticos { get; set; }
    }
}