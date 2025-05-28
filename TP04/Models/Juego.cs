namespace TP04.Models;
using Newtonsoft.Json;


public static class Juego
{
    public static string palabra;
    public static string palabraOculta;
    public static List<string> letrasUsadas = new List<string>();
    public static int intentos;


    public static void generarPalabra()
    {
        intentos = 0;  
        Random rd = new Random();
        string[] palabras = { "Estrella", "Montaña", "Manteca", "Pancho", "Orquesta", "Vasquito", "Mate", "Electricidad", "Ajedrez" };
        palabra = palabras[rd.Next(palabras.Length)].ToUpper();
        palabraOculta = new string('-', palabra.Length);
        letrasUsadas.Clear();
    }
    public static bool logicaAhorcado(string letra)
    { 
        letra = letra.ToUpper();

        if (!letrasUsadas.Contains(letra))
        {
            letrasUsadas.Add(letra);
            intentos++;
        }

        if (palabra.Contains(letra))
        {
            string nueva = "";

            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i] == letra[0])
                {
                    nueva += letra[0];
                }
                else
                {
                    nueva += palabraOculta[i];
                }
            }

            palabraOculta = nueva;
        }

        // Devuelve true si ganó
        return !palabraOculta.Contains("-");
    }
}

