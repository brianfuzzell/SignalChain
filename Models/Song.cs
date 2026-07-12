using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models;

public class Song
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Writer { get; set; }
    public string Artist { get; set; }
    public int YearRecorded { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; }
    public List<GearSong> GearSongs { get; set; }
}