using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    public ProAgilContext _context { get; }
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ProAgilContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet("getevents")]
    public async Task<IActionResult> GetEvents()
    {
      try
      {
        var results = await _context.Events.ToListAsync();
        return Ok(results);
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor");
      }
    }

    [HttpGet("getevents/{id}")]
    public async Task<IActionResult> GetEventById([FromRoute] int id)
    {
      try
      {
        var results = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
        return Ok(results);
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor");
      }
    }
  }
}