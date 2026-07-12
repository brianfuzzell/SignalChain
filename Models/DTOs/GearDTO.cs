using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models.DTOs;

public class GearDTO
{
    public int Id { get; set; }
    public int GearTypeId { get; set; }
    public GearTypeDTO GearType { get; set; }
    public string Model { get; set; }
    public string PurchaseYear { get; set; }
    public int Quantity { get; set; }
    public string SerialNumber { get; set; }
    public List<BasicSongDTO> SongsUsingGear { get; set; }
}