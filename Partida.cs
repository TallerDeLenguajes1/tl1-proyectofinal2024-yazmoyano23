using espacioPersonaje;
using especioHistorial;
using espacioDatosPelea;

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
            Console.WriteLine("\nTu Personaje para el combate es:\n");
            Console.WriteLine($" ID: {ListaPersonajes[i].id}\n Nombre: {ListaPersonajes[i].nombre}\n Tipo: {ListaPersonajes[i].tipo}\n Nivel: {ListaPersonajes[i].nivel}\n Salud: {ListaPersonajes[i].salud}\n Fuerza: {ListaPersonajes[i].fuerza}\n Destreza: {ListaPersonajes[i].destreza}\n Evasion: {ListaPersonajes[i].evasion}\n Velocidad: {ListaPersonajes[i].velocidad}\n");
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
            int cantidad = competidores.Count;
            do
            {
                var enemigo = OponenteAleatorio(competidores);
                //lo saco de la lista
                competidores = EliminarCompetidor(competidores, enemigo);
                //enfrentamiento
                ganador = Pelea(luchador, enemigo); 
                if (ganador.id == luchador.id)
                {
                    luchador = ganador;
                    luchador.Mejora();
                    
                }
                cantidad--; 


            } while ( cantidad != 0 && ganador.id == luchador.id);
            if (ganador.id == luchador.id)
            {
                Console.WriteLine("El ganador del torneo es:" + ganador.nombre.ToUpper());
                var historial = new HistorialJson();
                historial.GuardarGanador(ganador,"Ganadores.json");
            } else
            {
                Console.WriteLine("Peldisteeeeeeeeee.\nFIN DEL TORNEO");
            }
        }

        public Personaje OponenteAleatorio(List<Personaje> competidores){
            Random random = new Random();
            int indice = random.Next(competidores.Count);
            return competidores[indice];
        }

      public Personaje Pelea(Personaje luchador1, Personaje luchador2) {
        int ataques = 0;
      	while (luchador1.salud > 0 && luchador2.salud > 0) {
          	//ataca el 1er luchador
          	luchador1.Ataque(luchador2);
          	// si no lo mata, ataca el 2do luchador
          	if (luchador2.salud > 0) {
              	luchador2.Ataque(luchador1);
            } else { // sino gana el 1ro
              	Console.WriteLine("\n"+ luchador2.nombre + " fue DERROTADO");
            }
            ataques++;
        }
      
      	if (luchador2.salud > 0) {
          	Console.WriteLine("\nEl ganador es: " + luchador2.nombre);
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

          	Console.WriteLine("\nEl ganador es: " + luchador1.nombre);
          	return luchador1;
        }
      }
}
