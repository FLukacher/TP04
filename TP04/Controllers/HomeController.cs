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
        return View();
    }
    public IActionResult Jugar()
    {
        ViewBag.palabra = Juego.palabra;
        ViewBag.palabraOculta = Juego.palabraOculta;
        ViewBag.letrasUsadas = Juego.letrasUsadas;
        ViewBag.intentos = Juego.intentos;
        return View("jugar");
    }
    [HttpPost]
    public IActionResult PantallaVictoria(string letraUsada)
    {
        if (Juego.logicaAhorcado(letraUsada))
        {
            
            return View("ganaste");          
        }     
        return RedirectToAction("jugar");        
    }
    [HttpPost]
    public IActionResult arriesgarPalabra(string palabraArriesgar)
    {
        ViewBag.palabra = Juego.palabra;
        palabraArriesgar = palabraArriesgar.ToUpper();
        ViewBag.intentos = Juego.intentos;
        if (palabraArriesgar == Juego.palabra)
        {
            return View("ganaste");
        }
        else return View("perdiste");
        
    }

}



