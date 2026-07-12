using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models;

public class Gear
{
    public int Id { get; set; }
    public int GearTypeId { get; set; }
    public GearType GearType { get; set; }
    public string Model { get; set; }
    public string PurchaseYear { get; set; }
    public int Quantity { get; set; }
    public string SerialNumber { get; set; }
    public List<GearSong> GearSongs { get; set; }
}