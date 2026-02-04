using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockWebEliasParada.Models.Entities
{
    public class Electrodomestico
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreElectrodomestico { get; set; }

        [Required]
        public int TipoCategoriaId { get; set; }

        [Required]
        public int SucursalId { get; set; }

        [Required]
        public int CantidadInventario { get; set; }

        public bool HabilitarProducto { get; set; }

        public TipoCategoria TipoCategoria { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}
