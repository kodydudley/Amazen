using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using amazen_server.Services;
using amazen_server.Models;
using Microsoft.AspNetCore.Authorization;
using CodeWorks.Auth0Provider;

namespace amazen_server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ProductsService _ps;

    public ProductsController(ProductsService ps)
    {
      _ps = ps;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Product>> Create([FromBody] Product newProduct)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newProduct.CreatorId = userInfo.Id;
        Product created = _ps.Create(newProduct);
        created.Creator = userInfo;
        return Ok(created);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
      try
      {
        return Ok(_ps.Get());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
      try
      {
        return Ok(_ps.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Product> Delete(int id)
    {
      try
      {
        return Ok(_ps.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Product>> Edit([FromBody] Product updated, int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        updated.CreatorId = userInfo.Id;
        updated.Creator = userInfo;
        updated.Id = id;
        return Ok(_ps.Edit(updated));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}