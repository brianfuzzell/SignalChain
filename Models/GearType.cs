using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models;

public class GearType
{
    public int Id { get; set; }
    public string Name { get; set; }
}