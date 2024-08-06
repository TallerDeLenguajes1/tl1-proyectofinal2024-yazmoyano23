using espacioPersonaje;
using especioHistorial;
public class Partida
{
    public void IniciarPartida(List<Personaje> competidores) {
      	var elegido = ElegirPersonaje(competidores);
      	// se elimina de la lista el personaje elegido
      	competidores = EliminarCompetidor(competidores, elegido);
      	Torneo(elegido, competidores);
       /* foreach (var digimon in competidores)
        {
            Console.WriteLine(digimon.ToString());    
        }*/
    }
    public Personaje ElegirPersonaje(List<Personaje> ListaPersonajes) {
      	//mostrar la lista de personajes para elegir mediante teclado
        Console.WriteLine("Seleccionar personaje");
        
        for (int indice = 0; indice < ListaPersonajes.Count; indice++)
        {
            Console.WriteLine($"{indice + 1}. {ListaPersonajes[indice].nombre}");
        }
        int seleccion;
        string entrada;

        do
        {
            
            Console.WriteLine("Ingrese un valor entre 1 y " + ListaPersonajes.Count);
            entrada = Console.ReadLine();
            
                     
        } while (!int.TryParse(entrada, out seleccion) ||  (seleccion > ListaPersonajes.Count));

        int i = seleccion - 1; 
        Console.WriteLine("Tu Personaje para el combate es:");
        Console.WriteLine($" ID: {ListaPersonajes[i].id}\n Nombre: {ListaPersonajes[i].nombre}\n Tipo: {ListaPersonajes[i].tipo}\n Nivel: {ListaPersonajes[i].nivel}\n Salud: {ListaPersonajes[i].salud}\n Fuerza: {ListaPersonajes[i].fuerza}\n Destreza: {ListaPersonajes[i].destreza}\n Evasion: {ListaPersonajes[i].evasion}\n Velocidad: {ListaPersonajes[i].velocidad}");
        return ListaPersonajes[i];
    }

    public List<Personaje> EliminarCompetidor(List<Personaje> competidores, Personaje elegido) {
      	// eliminar elegido de la lista competidores
      	competidores.Remove(elegido);
      	return competidores;
    }

    public void Torneo(Personaje luchador, List<Personaje> competidores) {
      	//obtengo un enemigo
        Personaje ganador;
        do
        {
           var enemigo = OponenteAleatorio(competidores);
      	   //lo saco de la lista
      	   competidores = EliminarCompetidor(competidores, enemigo);
      	   //enfrentamiento
      	   ganador = Pelea(luchador, enemigo); 
        } while (competidores != null && ganador.id == luchador.id);
      	if (ganador.id == luchador.id)
        {
            Console.WriteLine("EL ganador es:" + ganador.nombre.ToUpper());
            var historial = new HistorialJson();
            historial.GuardarGanador(ganador,"Ganadores.json");
        } else
        {
             Console.WriteLine("Peldisteeeeeeeeee");
        }
    }

    public Personaje OponenteAleatorio(List<Personaje> competidores){
      	Random random = new Random();
        int indice = random.Next(competidores.Count);
        return competidores[indice];
    }

    public Personaje Pelea(Personaje luchador1, Personaje luchador2) {
      	while (luchador1.salud > 0 && luchador2.salud > 0) {
          	//ataca el 1er luchador
          	luchador1.Ataque(luchador2);
          	// si no lo mata, ataca el 2do luchador
          	if (luchador2.salud > 0) {
              	luchador2.Ataque(luchador1);
            } else { // sino gana el 1ro
              	Console.WriteLine(luchador2.nombre + " fue DERROTADO");
            }
        }
      
      	if (luchador2.salud > 0) {
          	Console.WriteLine("El ganador es: " + luchador2.nombre);
            return luchador2;
        } else {
          	Console.WriteLine("El ganador es: " + luchador1.nombre);
          	return luchador1;
        }
    }
}