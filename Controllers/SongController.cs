using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalChain.Data;
using SignalChain.Models;
using SignalChain.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using System.Security.Claims;

namespace SignalChain.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongController : ControllerBase
{
    private SignalChainDbContext _dbContext;
    private readonly IMapper _mapper;

    public SongController(SignalChainDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        List<Song> songs = _dbContext
            .Songs
            .Include(s => s.Status)
            .Include(s => s.GearSongs)
            .OrderBy(s => s.Title)
            .ToList();

        List<SongDTO> songDTOs = _mapper.Map<List<SongDTO>>(songs);

        return Ok(songDTOs);
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        Song? song = _dbContext
            .Songs
            .Include(s => s.Status)
            .Include(s => s.GearSongs)
                .ThenInclude(gs => gs.Gear)
                    .ThenInclude(g => g.GearType)
            .SingleOrDefault(s => s.Id == id);

        if (song == null)
        {
            return NotFound();
        }

        SongDTO songDTO = _mapper.Map<SongDTO>(song);

        return Ok(songDTO);
    }
}