using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models.DTOs;

public class GearTypeDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}