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

        songDTO.GearUsed = song.GearSongs
            .Select(gs => new BasicGearDTO
            {
                Id = gs.GearId,
                Model = gs.Gear.Model
            })
            .OrderBy(gs => gs.Model)
            .ToList();

        return Ok(songDTO);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreateSong(NewSongDTO newSong)
    {
        var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var profile = _dbContext.UserProfiles.SingleOrDefault(up => up.IdentityUserId == identityUserId);

        if (profile == null)
        {
            return NotFound();
        }

        Song song = new Song
        {
            Title = newSong.Title,
            Writer = newSong.Writer,
            Artist = newSong.Artist,
            YearRecorded = newSong.YearRecorded,
            StatusId = newSong.StatusId,
            UserProfileId = profile.Id
        };

        _dbContext.Songs.Add(song);
        _dbContext.SaveChanges();

        SongDTO songDTO = _mapper.Map<SongDTO>(song);
        songDTO.GearUsed = new List<BasicGearDTO>();

        return Created($"/api/song/{song.Id}", songDTO);
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult UpdateSong(UpdateSongDTO song, int id)
    {
        Song? songToUpdate = _dbContext.Songs.SingleOrDefault(s => s.Id == id);
        if (songToUpdate == null)
        {
            return NotFound();
        }

        songToUpdate.Title = song.Title;
        songToUpdate.Writer = song.Writer;
        songToUpdate.Artist = song.Artist;
        songToUpdate.YearRecorded = song.YearRecorded;
        songToUpdate.StatusId = song.StatusId;

        _dbContext.SaveChanges();

        return NoContent();
    }
}