using System.ComponentModel.DataAnnotations;

namespace StockWebEliasParada.ViewModels
{
    public class InventarioUpdateVM
    {
        [Required]
        public int ElectrodomesticoId { get; set; }

        [Required]
        [Range(1, 10000)]
        public int Cantidad { get; set; }
    }
}