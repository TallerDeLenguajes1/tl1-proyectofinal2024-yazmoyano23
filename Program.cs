using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using InfoDigi;
using espacioPersonaje;
using fabrica;

public partial class Program
{
    public static async Task Main()
    {
        var competidores = new List<Personaje>(); //lista vacía que contendrá los 10 personajes
        FabricaDePersonajes Fabrica = new FabricaDePersonajes();
        
        await Fabrica.GetDigiAsync();
		//Fabrica.MostrarPersonajes();
        competidores = Fabrica.ObtenerAleatorios(10);
        foreach (var digimon in competidores)
        {
            Console.WriteLine(digimon.ToString());
        }

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