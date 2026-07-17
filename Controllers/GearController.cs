using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalChain.Data;
using SignalChain.Models;
using SignalChain.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace SignalChain.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GearController : ControllerBase
{
    private SignalChainDbContext _dbContext;
    private readonly IMapper _mapper;

    public GearController(SignalChainDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpGet]
    //[Authorize]
    public IActionResult Get()
    {
        List<Gear> gears = _dbContext
            .Gears
            .Include(g => g.GearType)
            .ToList();

        List<GearDTO> gearDTOs = _mapper.Map<List<GearDTO>>(gears);

        return Ok(gearDTOs);
    }
}