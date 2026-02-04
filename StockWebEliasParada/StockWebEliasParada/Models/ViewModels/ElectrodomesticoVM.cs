using System.ComponentModel.DataAnnotations;

public class ElectrodomesticoVM
{
    [Required]
    public string NombreElectrodomestico { get; set; }

    [Required]
    public int TipoCategoriaId { get; set; }

    [Required]
    public int SucursalId { get; set; }

    [Required]
    public int CantidadInventario { get; set; }

    public bool HabilitarProducto { get; set; }
}
