namespace TP04.Models;

public static class Juego
{
    public static string palabra = "";
    public static List<char> letrasUsadas = new List<char>();

    public static void generarPalabra()
    {
        Random rd = new Random();
        string[] palabras = {"Estrella", "Montaña", "Manteca", "Pancho", "Orquesta", "Banana", "Mate"};
        palabra = palabras[rd.Next(0, palabras.Length)];
        letrasUsadas.Clear(); // reiniciamos letras usadas al generar nueva palabra
    }
}

