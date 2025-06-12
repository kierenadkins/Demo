using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using MediatR;
using Application.Numbers.Commands;

namespace Demo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;

    public HomeController(ILogger<HomeController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new NumberModel());
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddNumbersAsync(NumberModel model)
    {
        model.Result = await _mediator.Send(new CalculateNumbersCommand { Number1 = model.Number1, Number2 = model.Number2 });
        return View("Index" ,model); 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
