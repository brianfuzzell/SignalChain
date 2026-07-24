using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalChain.Models;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; }
}