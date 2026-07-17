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
public class UserProfileController : ControllerBase
{
    private SignalChainDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserProfileController(SignalChainDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        List<UserProfile> userProfiles = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .ToList();

        List<UserProfileDTO> userProfileDTOs = _mapper.Map<List<UserProfileDTO>>(userProfiles);

        return Ok(userProfileDTOs);
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        List<UserProfile> userProfiles = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .ToList();

        List<UserProfileDTO> userProfileDTOs = _mapper.Map<List<UserProfileDTO>>(userProfiles);

        return Ok(userProfileDTOs);
    }
}