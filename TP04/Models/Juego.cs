namespace TP04.Models;

public static class Juego
{
    public static string generarPalabra()
    {
        Random rd = new Random();
        string[] palabras = {"Estrella", "Montaña", "Manteca", "Pancho", "Orquesta", "Banana", "Mate"};
        return palabras[rd.Next(0,7)];
    }
}
