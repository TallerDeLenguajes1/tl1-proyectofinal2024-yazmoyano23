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
using espacioMensajes;

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
        var msj = new mensajes();
        
        do
        {
            //Console.Clear();
            msj.titulo();
            Console.ForegroundColor = ConsoleColor.Blue;
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
                var historial = new HistorialJson();
                if (historial.Existe(rutaGanadores))
                {
                    var ganadores = new List<Personaje>();
                    var listadatos = new List<DatosPelea>();
                    ganadores = historial.LeerGanadores(rutaGanadores);
                    Console.WriteLine("\nLISTA DE GANADORES");
                    foreach (var ganador in ganadores)
                    {
                        listadatos = ganador.datos;
                        Console.WriteLine(ganador.ToString());
                   
                        foreach (var item in listadatos)
                        {
                            Console.WriteLine(item.ToString()); 
                        }
                    }
                } else {
                    Console.WriteLine("\nAun no se guardaron ganadores");
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPresione una tecla para volver al menu...");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
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
}