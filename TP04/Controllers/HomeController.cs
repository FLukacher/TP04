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
        if (Juego.palabra == "")
        {
            Juego.generarPalabra();
        }

        ViewBag.palabra = Juego.palabra;
        ViewBag.palabraOculta = new string('-', Juego.palabra.Length);
        return View();
    }
    [HttpPost]
    public IActionResult guardarDatos(string letraUsada)
    {
        if (!string.IsNullOrEmpty(letraUsada))
        {
            char letra = letraUsada.ToLower()[0]; // tomamos la primera letra y la pasamos a minúscula
            if (!Juego.letrasUsadas.Contains(letra))
            {
                Juego.letrasUsadas.Add(letra);
            }
        }

        return RedirectToAction("Index");

    }
    public IActionResult verificarLetra(string letraUsada)
    {
        ViewBag.palabra = Juego.palabra;
        ViewBag.palabraOculta = new string('-', Juego.palabra.Length);
        if(Juego.palabra.Contains(letraUsada))
        {
            int index = Juego.palabra.IndexOf(letraUsada);
            ViewBag.palabraOculta.Replace(letraUsada, 
            Juego.palabra.IndexOf(letraUsada));
        }
        return RedirectToAction("Index");
    }
}
