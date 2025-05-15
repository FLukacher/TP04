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
        return View();
    }
    public IActionResult Jugar()
    {
        if (Juego.palabra == "") Juego.generarPalabra();
        ViewBag.palabra = Juego.palabra;
        ViewBag.palabraOculta = Juego.palabraOculta;
        ViewBag.letrasUsadas = Juego.letrasUsadas;    
        return View("jugar");
    }
    [HttpPost]
    public IActionResult Logica(string letraUsada)
    {
        if (!Juego.palabraOculta.Contains("-")) 
        {
            return View("ganaste");
        }
        else
        {
            letraUsada = letraUsada.ToUpper();
            if (!Juego.letrasUsadas.Contains(letraUsada))
            {
                Juego.letrasUsadas.Add(letraUsada);
            }

            if (Juego.palabra.Contains(letraUsada))
            {
                string nueva = "";
                for (int i = 0; i < Juego.palabra.Length; i++)
                {
                    if (Juego.palabra[i] == letraUsada[0])
                    {
                        nueva += letraUsada[0];
                    }
                    else
                    {
                        nueva += Juego.palabraOculta[i];
                    }
                }
                Juego.palabraOculta = nueva;
            }

            return RedirectToAction("jugar");
        }
    }
}



