using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04.Models;

namespace TP04.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Juego.generarPalabra();
        ViewBag.palabra = Juego.generarPalabra();
        ViewBag.palabraOculta = new string('-', ViewBag.palabra.Length);
        return View();
    }

}
