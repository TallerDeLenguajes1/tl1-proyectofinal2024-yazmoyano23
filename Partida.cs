using espacioPersonaje;
using especioHistorial;
using espacioDatosPelea;
using System.Runtime.InteropServices;

public class Partida
    {
        public void IniciarPartida(List<Personaje> competidores) {
            var elegido = ElegirPersonaje(competidores);
            // se elimina de la lista el personaje elegido
            competidores = EliminarCompetidor(competidores, elegido);
            Torneo(elegido, competidores);
        }

        public Personaje ElegirPersonaje(List<Personaje> ListaPersonajes) {
            //mostrar la lista de personajes para elegir mediante teclado
            Console.Clear();
            Console.WriteLine("Seleccionar personaje");
            for (int indice = 0; indice < ListaPersonajes.Count; indice++)
            {
                Console.WriteLine($"{indice + 1}. {ListaPersonajes[indice].nombre}");
            }
            int seleccion;
            string? entrada;

            do
            {
                
                Console.WriteLine("\nIngrese un valor entre 1 y " + ListaPersonajes.Count);
                entrada = Console.ReadLine();
                
                        
            } while (!int.TryParse(entrada, out seleccion) ||  (seleccion > ListaPersonajes.Count));

            int i = seleccion - 1; 
            Console.Clear();
            Console.WriteLine("\nTu Personaje para el combate es:\n");
            Console.WriteLine($" ID: {ListaPersonajes[i].id}\n Nombre: {ListaPersonajes[i].nombre}\n Tipo: {ListaPersonajes[i].tipo}\n Nivel: {ListaPersonajes[i].nivel}\n Salud: {ListaPersonajes[i].salud}\n Fuerza: {ListaPersonajes[i].fuerza}\n Destreza: {ListaPersonajes[i].destreza}\n Evasion: {ListaPersonajes[i].evasion}\n Velocidad: {ListaPersonajes[i].velocidad}\n");
            return ListaPersonajes[i];
        }

        public List<Personaje> EliminarCompetidor(List<Personaje> competidores, Personaje elegido) {
            // eliminar elegido de la lista competidores
            competidores.Remove(elegido);
            return competidores;
        }

        // Luchador es el personaje elegido por el usuario   
        public void Torneo(Personaje luchador, List<Personaje> competidores) {
            //obtengo un enemigo
            Personaje ganador;
            int cantidad = competidores.Count;
            do
            {
                var enemigo = OponenteAleatorio(competidores);
                //lo saco de la lista
                competidores = EliminarCompetidor(competidores, enemigo);
                //enfrentamiento
                Console.WriteLine("\nPresione una tecla para comenzar la pelea...");
                Console.ReadKey();
                Console.Clear();
                ganador = Pelea(luchador, enemigo); 
                if (ganador.id == luchador.id)
                {
                    luchador = ganador;
                    Console.ForegroundColor = ConsoleColor.Green;
                    luchador.MejorarHabilidades();
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                cantidad--; 

            } while ( cantidad != 0 && ganador.id == luchador.id); //Mientras la lista tenga oponentes y el elegido gane la pelea
            if (ganador.id == luchador.id)
            {
                Console.WriteLine("\nFELICIDADES TU DIGIMON " + ganador.nombre.ToUpper() + " ES EL GANADOR DEL TORNEO");
                var historial = new HistorialJson();
                historial.GuardarGanador(ganador,"Ganadores.json");
            } else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nFIN DEL TORNEO");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPresione una tecla para volver al menu...");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public Personaje OponenteAleatorio(List<Personaje> competidores){
            Random random = new Random();
            int indice = random.Next(competidores.Count);
            return competidores[indice];
        }

      public Personaje Pelea(Personaje luchador1, Personaje luchador2) {
        int ataques = 0;
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\n---------------------------------------------------------");
        Console.WriteLine("\t\t"+ luchador1.nombre + " VS " + luchador2.nombre);
        Console.WriteLine("---------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Black;
        
      	while (luchador1.salud > 0 && luchador2.salud > 0) {
          	//ataca el 1er luchador
          	luchador1.Ataque(luchador2);
          	// si no lo mata, ataca el 2do luchador
          	if (luchador2.salud > 0) {
              	luchador2.Ataque(luchador1);
            } else { // sino gana el 1ro
              	Console.WriteLine("\nDERROTASTE A " + luchador2.nombre.ToUpper());
            }
            ataques++;
        }
      
      	if (luchador2.salud > 0) {
          	Console.WriteLine("\nPERDISTE\nFUISTE DERROTADO POR " + luchador2.nombre.ToUpper());
            return luchador2;
        } else {
            //gana mi personaje

            if (luchador1.datos == null) {
                luchador1.datos = new List<DatosPelea>();
            }
            DatosPelea datos = new DatosPelea {
                oponente = luchador2.nombre,
                saludrestante = luchador1.salud,
                ataques = ataques
            };
            luchador1.datos.Add(datos);

          	return luchador1;
        }
      }
}
