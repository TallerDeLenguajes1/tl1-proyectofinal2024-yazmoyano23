using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using InfoDigi;
using espacioPersonaje;
using fabrica;
using espacioJson;
using especioHistorial;
using espacioDatosPelea;

public partial class Program
{
    public static async Task Main()
    {

        string? entrada;  
        int seleccion;
        bool salir;
        var competidores = new List<Personaje>(); //lista vacía que contendrá los 10 personajes
        FabricaDePersonajes Fabrica = new FabricaDePersonajes();
        string rutaPersonajes = "Digimon.json";
        string rutaGanadores = "Ganadores.json";
        var personajeArchivos = new PersonajesJson();

        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n1: NUEVA PARTIDA");
            Console.WriteLine("2: VER GANADORES");
            Console.WriteLine("3: SALIR");
            Console.ForegroundColor = ConsoleColor.Black;
            do
            {
                    
                Console.WriteLine("\nIngresar opcion:");
                entrada = Console.ReadLine();
                    
                            
            } while (!int.TryParse(entrada, out seleccion) || (seleccion != 1 && seleccion != 2 && seleccion != 3) );  


            if (seleccion == 1)
            {

                if (personajeArchivos.Existe(rutaPersonajes))
                {
                    competidores = personajeArchivos.LeerPersonajes(rutaPersonajes);
                } else {
                    await Fabrica.GetDigiAsync();
                    competidores = Fabrica.ObtenerAleatorios(10);
                    personajeArchivos.GuardarPersonajes(competidores,rutaPersonajes);
                }  
                
                var partida = new Partida();
                partida.IniciarPartida(competidores); 
            } 

            if (seleccion == 2)
            {
                var ganadores = new List<Personaje>();
                var historial = new HistorialJson();
                var listadatos = new List<DatosPelea>();
                ganadores = historial.LeerGanadores(rutaGanadores);
                foreach (var ganador in ganadores)
                {
                    listadatos = ganador.datos;
                    Console.WriteLine(ganador.ToString());
                   
                    foreach (var item in listadatos)
                    {
                        Console.WriteLine(item.ToString()); 
                    }
                }
            }

            if (seleccion == 3)
            {
                salir = false;
            } else
            {
                salir = true;
            }
            
        } while (salir);
    
        
    }

    static async Task<Digimon[]> GetDigiAsync()
    {
        var url = "https://digimon-api.vercel.app/api/digimon";
        
        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                
                // Deserializar la respuesta JSON en una lista de objetos Fruit
                Digimon[]? personajes = JsonSerializer.Deserialize<Digimon[]>(responseBody);
                
                return personajes;
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Problemas de acceso a la API");
            Console.WriteLine("Message: {0}", e.Message);
            return null;
        }
    }
}