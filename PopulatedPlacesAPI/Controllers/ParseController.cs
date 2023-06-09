using Microsoft.AspNetCore.Mvc;
using PopulatedPlacesAPI.Services.Interfaces;

namespace PopulatedPlacesAPI.Web.Controllers;

[ApiController]
[Route("api")]
public class ParseController : ControllerBase
{
    private readonly ILocationDataProvider _parsingService;

    public ParseController(ILocationDataProvider parsingService)
    {
        _parsingService = parsingService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var parsedDataList = _parsingService.GetLocationDataCollection();
        return Ok(parsedDataList);
    }
}