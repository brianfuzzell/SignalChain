using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models;

public class GearSong
{
    public int Id { get; set; }
    public int GearId { get; set; }
    public Gear Gear { get; set; }
    public int SongId { get; set; }
    public Song Song { get; set; }
}