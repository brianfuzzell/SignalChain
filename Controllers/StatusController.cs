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
public class StatusController : ControllerBase
{
    private SignalChainDbContext _dbContext;
    private readonly IMapper _mapper;

    public StatusController(SignalChainDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        List<Status> statuses = _dbContext
            .Statuses
            .OrderBy(s => s.Name)
            .ToList();

        List<StatusDTO> statusDTOs = _mapper.Map<List<StatusDTO>>(statuses);

        return Ok(statusDTOs);
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        Status? status = _dbContext
            .Statuses
            .SingleOrDefault(s => s.Id == id);

        if (status == null)
        {
            return NotFound();
        }

        StatusDTO statusDTO = _mapper.Map<StatusDTO>(status);

        return Ok(statusDTO);
    }
}