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
    [Authorize]
    public IActionResult Get()
    {
        List<Gear> gears = _dbContext
            .Gears
            .Include(g => g.GearType)
            .OrderBy(g => g.Model)
            .ToList();

        List<GearDTO> gearDTOs = _mapper.Map<List<GearDTO>>(gears);

        return Ok(gearDTOs);
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        Gear? gear = _dbContext
            .Gears
            .Include(g => g.GearType)
            .Include(g => g.GearSongs)
                .ThenInclude(gs => gs.Song)
                    .ThenInclude(s => s.Status)
            .SingleOrDefault(g => g.Id == id);

        if (gear == null)
        {
            return NotFound();
        }

        GearDTO gearDTO = _mapper.Map<GearDTO>(gear);

        gearDTO.SongsUsingGear = gear.GearSongs
            .Select(gs => new BasicSongDTO
            {
                Id = gs.SongId,
                Title = gs.Song.Title
            })
            .ToList();

        return Ok(gearDTO);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreateGear(NewGearDTO newGear)
    {
        var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var profile = _dbContext.UserProfiles.SingleOrDefault(up => up.IdentityUserId == identityUserId);

        if (profile == null)
        {
            return NotFound();
        }

        Gear gear = new Gear
        {
            GearTypeId = newGear.GearTypeId,
            Model = newGear.Model,
            PurchaseYear = newGear.PurchaseYear,
            Quantity = newGear.Quantity,
            SerialNumber = newGear.SerialNumber,
            UserProfileId = profile.Id
        };

        _dbContext.Gears.Add(gear);
        _dbContext.SaveChanges();

        GearDTO gearDTO = _mapper.Map<GearDTO>(gear);
        gearDTO.SongsUsingGear = new List<BasicSongDTO>();

        return Created($"/api/gear/{gear.Id}", gearDTO);
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult UpdateGear(UpdateGearDTO gear, int id)
    {
        Gear? gearToUpdate = _dbContext.Gears.SingleOrDefault(g => g.Id == id);
        if (gearToUpdate == null)
        {
            return NotFound();
        }

        gearToUpdate.GearTypeId = gear.GearTypeId;
        gearToUpdate.Model = gear.Model;
        gearToUpdate.PurchaseYear = gear.PurchaseYear;
        gearToUpdate.Quantity = gear.Quantity;
        gearToUpdate.SerialNumber = gear.SerialNumber;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}/songs/{songId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult RemoveSong(int id, int songId)
    {
        GearSong? songToRemove = _dbContext.GearSongs.SingleOrDefault(gs => gs.GearId == id && gs.SongId == songId);
        if (songToRemove == null)
        {
            return NotFound();
        }

        _dbContext.GearSongs.Remove(songToRemove);
        _dbContext.SaveChanges();

        return NoContent();
    }

    // TODO: Delete Gear
    // [HttpDelete("{id}")]
    // [Authorize(Roles = "Admin")]

    // TODO: Assign gear item to a song
    // [HttpPost("{id}/assign")]
    // [Authorize]


}