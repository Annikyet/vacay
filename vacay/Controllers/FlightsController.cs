using Microsoft.AspNetCore.Mvc;
using vacay.Models;
using vacay.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace vacay.Controllers;
[ApiController] // flags for .net to register as a controller
[Route("api/[controller]")] // establish endpoint url based on class name (strips 'Controller' from name)
public class FlightsController : ControllerBase
{
  private readonly FlightsService _fs;
  // doesn't instantiate, just creates field (not property because it doesn't have get set)

  public FlightsController(FlightsService fs)
  {
    _fs = fs;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Flight>> Create([FromBody] Flight flightData)
  // TODO CreatedAt and UpdatedAt don't work
  {
    try
    {
      Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
      flightData.CreatorId = userInfo.Id;
      Flight newFlight = _fs.Create(flightData); // actually call the service, async/await is automatic via Dapper
      return Ok(newFlight);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("{id}")]
  // [Authorize]
  public ActionResult<Flight> Get(int id)
  {
    try
    {
      Flight flight = _fs.Get(id); // async/await is automatic in Dapper, calls service
      return Ok(flight); // Ok is equivalent to a 200 OK HTTP code (I think)
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpPut("{id}")]
  [Authorize]
  public async Task<ActionResult<Flight>> Update(int id, [FromBody] Flight flightData)
  {
    try
    {
      Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
      flightData.CreatorId = userInfo.Id;
      flightData.Id = id;
      Flight update = _fs.Update(flightData);
      return Ok(update);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }


    // [HttpPut("{id}")]
    // [Authorize]
    // public async Task<ActionResult<Burger>> Edit(int id, [FromBody] Burger burgerData)
    // {
    //   try
    //   {
    //     Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
    //     burgerData.CreatorId = userInfo.Id;
    //     burgerData.Id = id;
    //     Burger update = _bs.Edit(burgerData);
    //     // Manually handle the Populate (prevents creator: null)
    //     update.UpdatedAt = new DateTime();
    //     return Ok(update);
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Flight>> Remove(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Flight removed = _fs.Remove(id, userInfo.Id);
        return Ok(removed);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // public async Task<ActionResult<Burger>> Delete(int id)
    // {
    //   try
    //   {
    //     Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
    //     Burger deleted = _bs.Delete(id, userInfo.Id);
    //     return Ok(deleted);
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
}