using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models.DTOs;

public class BasicSongDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
}