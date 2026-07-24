using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models.DTOs;

public class SongDTO
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage = "Song title must be 100 characters or less")]
    public string Title { get; set; }
    public string Writer { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Artist name must be 50 characters or less")]
    public string Artist { get; set; }
    public int YearRecorded { get; set; }
    [Required]
    public int StatusId { get; set; }
    public StatusDTO Status { get; set; }
    public List<BasicGearDTO> GearUsed { get; set; }
}