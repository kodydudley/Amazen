using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using amazen_server.Models;
using amazen_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazen_server.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class ProfileController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly ProductsService _mps;
    public ProfileController(ProfilesService ps, ProductsService mps)
    {
      _ps = ps;
      _mps = mps;
    }

    [HttpGet]
    [Authorize]

    public async Task<ActionResult<ProfileController>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/products")]
    public async Task<ActionResult<Profile>> GetProductsByProfile(string id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_mps.GetProductsByProfile(id, userInfo?.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }

    }
  }
}