namespace TP04.Models;

public static class Juego
{
    public static string palabra = ""; //atributo no obligatorio, para probar el code
    public static string palabraOculta = "";
    public static List<string> letrasUsadas = new List<string>();


    public static void generarPalabra()
    {
        Random rd = new Random();
        string[] palabras = { "Estrella", "Montaña", "Manteca", "Pancho", "Orquesta", "Vasquito", "Mate", "Electricidad", "Ajedrez" };
        palabra = palabras[rd.Next(palabras.Length)].ToUpper();
        palabraOculta = new string('-', palabra.Length); 
        letrasUsadas.Clear();
    }
}

