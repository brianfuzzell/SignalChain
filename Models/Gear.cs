using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models;

public class Gear
{
    public int Id { get; set; }
    [Required]
    public int GearTypeId { get; set; }
    public GearType GearType { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Model details must be 50 characters or less")]
    public string Model { get; set; }
    public string PurchaseYear { get; set; }
    [Required]
    public int Quantity { get; set; }
    public string SerialNumber { get; set; }
    public List<GearSong> GearSongs { get; set; }
}