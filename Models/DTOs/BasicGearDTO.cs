using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models.DTOs;

public class BasicGearDTO
{
    public int Id { get; set; }
    public string Model { get; set; }
}