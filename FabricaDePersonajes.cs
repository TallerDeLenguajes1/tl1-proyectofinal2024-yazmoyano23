using System.Text.Json;
using espacioPersonaje;
using InfoDigi;

namespace fabrica
{
    public class FabricaDePersonajes {

		private Digimon[]? Arreglo;

        public Digimon[]? Arreglo1 { get => Arreglo; set => Arreglo = value; }

        public async Task GetDigiAsync() //trae TODOS los personajes de la API
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
                
                Arreglo1 = personajes;
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Problemas de acceso a la API");
            Console.WriteLine("Message: {0}", e.Message);
            //return null;
        }
    }
    
    public void MostrarPersonajes() 
    {
        //Digimon[] Arreglo = await GetDigiAsync();
        var listaDigimon = new List<Personaje>();
        
        if (Arreglo1 != null)
        {
            int i = 1;
            Random aleatorio = new Random();
            foreach (var digimon in Arreglo1)
            {
                //crear lista de personajes, crear parametros, crear el objeto llamar al constructor y agregar a lista
                string? nombre = digimon.name ;
                string? tipo = digimon.level ;
                int nivel = aleatorio.Next(1,11);
                int fuerza = aleatorio.Next(1,11);
                int destreza = aleatorio.Next(1,6);
                int evasion = aleatorio.Next(1,11);
                int velocidad = aleatorio.Next(1,11);
                
                var nuevoDigimon = new Personaje(i,nombre,tipo,nivel,fuerza,destreza,evasion,velocidad);
                listaDigimon.Add(nuevoDigimon);
                i++;
            }

            foreach (var digimon in listaDigimon)
            {
                Console.WriteLine(digimon.ToString());
            }
        }
        else
        {
            Console.WriteLine("No se pudieron obtener los personajes.");
        }
    }
    private Personaje GetPersonaje(int indice,int i) {
      	Random aleatorio = new Random();
      	string? nombre = Arreglo1[indice].name;
        string? tipo = Arreglo1[indice].level;
        int nivel = aleatorio.Next(1,11);
        int fuerza = aleatorio.Next(1,11);
        int destreza = aleatorio.Next(1,6);
        int evasion = aleatorio.Next(1,11);
        int velocidad = aleatorio.Next(1,11);

        var nuevoDigimon = new Personaje(i,nombre,tipo,nivel,fuerza,destreza,evasion,velocidad);
        return nuevoDigimon;
    }

    public List<Personaje> ObtenerAleatorios(int cantidad){ 

        var Aleatorios = new List<Personaje>();
        Personaje player = new Personaje();
        Random random = new Random();
        for (int i = 0; i < cantidad; i++) {
            int indice = random.Next(Arreglo1.Length);
            player = GetPersonaje(indice,i);
            Aleatorios.Add(player);
          /*  if(Aleatorios.Find(a => a.nombre == player.nombre) != null) 
            {
                i--;
            }
            else
            {
                Aleatorios.Add(player);
            }*/
        }
        return Aleatorios;
    }        
    }
}