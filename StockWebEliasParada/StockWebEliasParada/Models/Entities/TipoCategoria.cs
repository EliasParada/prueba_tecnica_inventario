using System.ComponentModel.DataAnnotations;

namespace StockWebEliasParada.Models.Entities
{
    public class TipoCategoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Nombre { get; set; }

        public bool HabilitarTipo { get; set; } = true;

        public ICollection<Electrodomestico>? Electrodomesticos { get; set; }
    }
}