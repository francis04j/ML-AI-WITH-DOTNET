using Api.Interfaces;
using Api.Models;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BabyDevForecastController : ControllerBase
{
    private readonly IBabyDevService _babyDevService;
    private readonly ILogger<BabyDevForecastController> _logger;
   
   
    public BabyDevForecastController( IBabyDevService babyDevService, ILogger<BabyDevForecastController> logger)
    {
        _babyDevService = babyDevService;
        _logger = logger;
      
    }

    [HttpGet()]
    public async Task<IEnumerable<BabyDevForecastModel>> GetBabyDevelopments(int ageRangeStart, int ageRangeEnd)
    {
        var response = await _babyDevService.GetBabyDev(ageRangeStart, ageRangeEnd);
     //  var model = _mapper.Map<Entities.BabyDevForecast>(response);
     var model = response.Adapt<List<BabyDevForecastModel>>();
        return model;
    }
}