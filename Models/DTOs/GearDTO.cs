using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models.DTOs;

public class GearDTO
{
    public int Id { get; set; }
    [Required]
    public int GearTypeId { get; set; }
    public GearTypeDTO GearType { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Model details must be 50 characters or less")]
    public string Model { get; set; }
    public string PurchaseYear { get; set; }
    [Required]
    public int Quantity { get; set; }
    public string SerialNumber { get; set; }
    public List<BasicSongDTO> SongsUsingGear { get; set; }
}