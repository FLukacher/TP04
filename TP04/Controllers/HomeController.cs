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
        if (Juego.palabra == null) Juego.generarPalabra();
        ViewBag.palabra = Juego.palabra;
        ViewBag.palabraOculta = Juego.palabraOculta;
        ViewBag.letrasUsadas = Juego.letrasUsadas;
        ViewBag.intentos = Juego.intentos;
        return View("jugar");
    }
    [HttpPost]
    public IActionResult Logica(string letraUsada)
    { 
        ViewBag.palabra = Juego.palabra;     
        letraUsada = letraUsada.ToUpper();
        if (!Juego.letrasUsadas.Contains(letraUsada))
        {
            Juego.letrasUsadas.Add(letraUsada);
            Juego.intentos++;

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
        if (!Juego.palabraOculta.Contains("-"))
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



