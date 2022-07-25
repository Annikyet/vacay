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



    // public async Task<ActionResult<Burger>> Create([FromBody] Burger burgerData)
    // {
    //   try
    //   {
    //     Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
    //     burgerData.CreatorId = userInfo.Id;
    //     Burger newBurger = _bs.Create(burgerData);
    //     // Manually handle the Populate (prevents creator: null)
    //     newBurger.Creator = userInfo;
    //     newBurger.CreatedAt = new DateTime();
    //     newBurger.UpdatedAt = new DateTime();
    //     return Ok(newBurger);
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }



  [HttpGet("{id}")]
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
}