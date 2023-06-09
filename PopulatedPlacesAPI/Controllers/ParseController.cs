using Microsoft.AspNetCore.Mvc;
using PopulatedPlacesAPI.Services.Interfaces;

namespace PopulatedPlacesAPI.Web.Controllers;

[ApiController]
[Route("api")]
public class ParseController : ControllerBase
{
    private readonly IParsingService _parsingService;

    public ParseController(IParsingService parsingService)
    {
        _parsingService = parsingService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var parsedDataList = _parsingService.ParseData();
        return Ok(parsedDataList);
    }
}