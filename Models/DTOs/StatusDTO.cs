using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models.DTOs;

public class StatusDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}