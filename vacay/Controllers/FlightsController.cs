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

  [HttpGet("{flightId}")]
  [Authorize]
  public async Task<ActionResult<Flight>> Get(int flightId)
  {
    System.Console.WriteLine("flightId: " + flightId.ToString());

    try
    {
      Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

      Flight flight = _fs.AuthGet(flightId, userInfo.Id); // async/await is automatic in Dapper, calls service
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
}