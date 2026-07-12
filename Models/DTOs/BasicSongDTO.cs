using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models.DTOs;

public class BasicSongDTO
{
    public int SongId { get; set; }
    public string Name { get; set; }
}