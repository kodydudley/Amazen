using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using amazen_server.Models;
using amazen_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazen_server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WishListProductsController : ControllerBase
  {
    private readonly WishListProductsService _wlps;

    public WishListProductsController(WishListProductsService wlps)
    {
      _wlps = wlps;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<WishListProduct>> Post([FromBody] WishListProduct newWishListProduct)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newWishListProduct.CreatorId = userInfo.Id;
        return Ok(_wlps.Create(newWishListProduct));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_wlps.Delete(id, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}