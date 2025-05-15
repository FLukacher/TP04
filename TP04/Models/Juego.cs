namespace TP04.Models;

public static class Juego
{
    public static string palabra = "";
    public static string palabraOculta = "";
    public static List<string> letrasUsadas = new List<string>();


    public static void generarPalabra()
    {
        string[] palabras = { "Estrella", "Montaña", "Manteca", "Pancho", "Orquesta", "Banana", "Mate" };
        Random rd = new Random();
        palabra = palabras[rd.Next(palabras.Length)].ToUpper();
        palabraOculta = new string('-', palabra.Length);
        letrasUsadas.Clear();
    }
}

