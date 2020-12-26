using System.Collections.Generic;
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
  public class WishListsController : ControllerBase
  {
    private readonly WishListsService _wls;
    private readonly WishListProductsService _wlps;
    public WishListsController(WishListsService wls, WishListProductsService wlps)
    {
      _wls = wls;
      _wlps = wlps;
    }

    [HttpPost]
    [Authorize]
    public ActionResult<WishList> Create([FromBody] WishList newWishList)
    {
      try
      {
        WishList created = _wls.Create(newWishList);
        return Ok(created);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<WishList>> Get()
    {
      try
      {
        return Ok(_wls.Get());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{wishlistId}/wishlistproducts")]
    public ActionResult<IEnumerable<Product>> Get(int wishlistId)
    {
      try
      {
        return Ok(_wlps.GetProductsByWishListId(wishlistId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}