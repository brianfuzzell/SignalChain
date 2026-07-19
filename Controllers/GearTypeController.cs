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
public class GearTypeController : ControllerBase
{
    private SignalChainDbContext _dbContext;
    private readonly IMapper _mapper;

    public GearTypeController(SignalChainDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        List<GearType> gearTypes = _dbContext
            .GearTypes
            .OrderBy(g => g.Name)
            .ToList();

        List<GearTypeDTO> gearTypeDTOs = _mapper.Map<List<GearTypeDTO>>(gearTypes);

        return Ok(gearTypeDTOs);
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        GearType? gearType = _dbContext
            .GearTypes
            .SingleOrDefault(gt => gt.Id == id);

        if (gearType == null)
        {
            return NotFound();
        }

        GearTypeDTO gearTypeDTO = _mapper.Map<GearTypeDTO>(gearType);

        return Ok(gearTypeDTO);
    }
}