using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EventController : ControllerBase
  {
    private IProAgilRepository _repo { get; }
    public EventController(IProAgilRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        var results = await _repo.GetAllEventsAsync(true);
        return Ok(results);
      }
      catch (Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor");
      }
    }

    [HttpGet("{eventId}")]
    public async Task<IActionResult> Get(int eventId)
    {
      try
      {
        var results = await _repo.GetEventByIdAsync(eventId, true);
        return Ok(results);
      }
      catch (Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor");
      }
    }

    [HttpGet("getByTheme/{theme}")]
    public async Task<IActionResult> Get(string theme)
    {
      try
      {
        var results = await _repo.GetAllEventsByThemeAsync(theme, true);
        return Ok(results);
      }
      catch (Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Event model)
    {
      try
      {
        _repo.Add(model);
        if (await _repo.SaveChangesAsync())
        {
          return Created($"/api/event/{model.Id}", model);
        }
      }
      catch (Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor");
      }

      return BadRequest();
    }

    [HttpPut("{eventId}")]
    public async Task<IActionResult> Put([FromRoute] int eventId, [FromBody] Event model)
    {
      try
      {
        var hasEvent = await _repo.GetEventByIdAsync(eventId, false);
        if (hasEvent == null) return NotFound();
        _repo.Update(model);
        if (await _repo.SaveChangesAsync())
        {
          return Created($"/api/event/{model.Id}", model);
        }
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor");
      }

      return BadRequest();
    }

    [HttpDelete("{eventId}")]
    public async Task<IActionResult> Delete([FromRoute] int eventId)
    {
      try
      {
        var eventData = await _repo.GetEventByIdAsync(eventId, false);
        _repo.Delete(eventData);
        if (await _repo.SaveChangesAsync())
        {
          return Ok();
        }
      }
      catch (Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor");
      }

      return BadRequest();
    }
  }
}