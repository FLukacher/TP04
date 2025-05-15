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
        ViewBag.palabraOculta = Juego.palabraOculta;
        ViewBag.letrasUsadas = Juego.letrasUsadas;      
        return View();
    }
    [HttpPost]
    public IActionResult guardarDatos(string letraUsada)
    {
        if (letraUsada != null)
        {
            if (!Juego.letrasUsadas.Contains(letraUsada.ToUpper()))
            {
                Juego.letrasUsadas.Add(letraUsada.ToUpper());
            }
        }

        return RedirectToAction("Index");

    }
    [HttpPost]
    public IActionResult verificarLetra(string letraUsada)
    {
        ViewBag.palabra = Juego.palabra;

        if (Juego.palabra.Contains(letraUsada))
        {
            letraUsada = letraUsada.ToUpper();
            int index = Juego.palabra.IndexOf(letraUsada);
            foreach(char letra in Juego.palabra)
            {
                if(letra == letraUsada[0])
                {
                    Juego.palabraOculta = Juego.palabraOculta.Remove(index, 1).Insert(index, letraUsada.ToUpper());
                }
            }
        }

        ViewBag.palabraOculta = Juego.palabraOculta;

    return RedirectToAction("Index");
    }
}
