using System;
using System.Data;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using GovermentSimulator.Models;

public class Program
{
    public static void Main()
    {
        Random random = new Random();
        int numeroGob = 0;
        int politicaChanges = 0;
        int protesta = 0;

        while(true)
        {
            int anio = 1;
           numeroGob++;
            Gobierno gobiernoActual = getNewGoverment(numeroGob);
            Pueblo pueblo = getRandomPoblation();
            Gobierno anterior = getNewGoverment(99);
            bool cambioGobierno = false;
            Console.WriteLine("Nuevo Gobierno");
            
            while (anio <= 4)
            {

                Console.WriteLine($"PERIODO:{anio}\nnombre:{gobiernoActual.nombre}\npartido:{gobiernoActual.partido}\npolitica:{gobiernoActual.politica}");
                Console.WriteLine($"\nContienda Actual:{pueblo.contiendaCivil}");
                Console.ReadLine();
                

                if (anio > 1 && gobiernoActual.partido == "LIBERAL")
                {
                    gobiernoActual.politica = getPoliticas();
                    politicaChanges++;
                }
                if (cambioGobierno == true && anterior.partido == "CONSERVADOR")
                {
                    gobiernoActual = anterior;
                }
                if (gobiernoActual.politica == "COERCITIVA")
                {
                    pueblo.contiendaCivil = "ALTA";
                    protesta++;
                    break;
                }
                else if (gobiernoActual.politica == "PERMISIVA")
                {
                    pueblo.contiendaCivil = "BAJA";
                    
                }
                Console.WriteLine($"Respuesta al periodo {anio} del gobierno {gobiernoActual.nombre}\nContiendaCivil:{pueblo.contiendaCivil}\n\nEstado del gobierno luego de este periodo\npartido:{gobiernoActual.partido}\npolitica:{gobiernoActual.politica}");
                Console.ReadLine();
                anio++;
                Console.Clear();




            }
            cambioGobierno = true;
            Console.WriteLine("Ocurrio un cambio de gobierno........");
            string input = Console.ReadLine();
            if (input.Equals("t", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("El programa se detendrá.");
                Console.ReadLine();
                Console.Clear();
                break;
            }


        }
        Console.WriteLine($"ESTADISTICAS:\nCambios De gobierno:{numeroGob}\nProtestas:{protesta}\nCambio de politicas:{politicaChanges}");
     
    }

    static public string getPartidos()
    {
        Random random = new Random();
        Array partidos = Enum.GetValues(typeof(partidos));
        partidos partidoAleatorio = (partidos)partidos.GetValue(random.Next(partidos.Length));
        return partidoAleatorio.ToString();
    }

    static public string getPoliticas()
    {
        Random random = new Random();
        Array politicas = Enum.GetValues(typeof(politicas));
        politicas politicaAleatoria = (politicas)politicas.GetValue(random.Next(politicas.Length));
        return politicaAleatoria.ToString();
    }

    static public string getContienda()
    {
        Random random = new Random();
        Array contiendas = Enum.GetValues(typeof(contiendas));
        contiendas contiendaAleatoria = (contiendas)contiendas.GetValue(random.Next(contiendas.Length));
        return contiendaAleatoria.ToString();
    }

    static Gobierno getNewGoverment(int num)
    {
        Gobierno gobierno = new Gobierno(1, $"Gobierno {num}", getPartidos(), getPoliticas());
        return gobierno;
    }

    static Pueblo getPoblation(string contienda)
    {
        Pueblo poblation = new Pueblo(1, contienda);
        return poblation;
    }
    static Pueblo getRandomPoblation()
    {
        Pueblo poblation = new Pueblo(1, getContienda());
        return poblation;
    }
}
