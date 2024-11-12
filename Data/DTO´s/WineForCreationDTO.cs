using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Data.DTO_s;

public class WineForCreationDTO
{
    public required string Name { get; set; }
    public required string Variety { get; set; }
    public required int Year { get; set; }
    public required string Region { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad de vinos a agregar debe ser mayor a 0.")]
    [DefaultValue(1)]
    public int Stock { get; set; }
}