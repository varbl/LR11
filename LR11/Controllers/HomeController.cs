using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[ServiceFilter(typeof(LogActionFilter))]
public class HomeController : ControllerBase
{

    [HttpGet]
    public IActionResult Index()
    {
        return Ok("This is the Index action.");
    }


    [HttpGet]
    public IActionResult Details(int id)
    {
        return Ok($"Details action with ID: {id}");
    }


    [HttpPost]
    public IActionResult Create([FromBody] string value)
    {
        return Ok($"Create action with value: {value}");
    }
}
