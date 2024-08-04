using System.Text.Json.Serialization;

namespace espacioPersonaje
{
    public class Personaje {
        private int Id; 
        private string? Nombre;
        private string? Tipo; //level que viene de la api
        private int Nivel;
        private int Salud; // 100
        private int Fuerza; // 1 y 10
        private int Destreza; // 1 y 5
        private int Evasion;
        private int Velocidad; //1 y 10


        public string? nombre { get => Nombre; set => Nombre = value; }
        public int id { get => Id; set => Id = value; }
        public string? tipo { get => Tipo; set => Tipo = value; }
        public int nivel { get => Nivel; set => Nivel = value; }
        public int salud { get => Salud; set => Salud = value; }
        public int fuerza { get => Fuerza; set => Fuerza = value; }
        public int destreza { get => Destreza; set => Destreza = value; }
        public int evasion { get => Evasion; set => Evasion = value; }
        public int velocidad { get => Velocidad; set => Velocidad = value; }

        public Personaje(){}
        public Personaje(int id,string? nombre, string? tipo, int nivel, int fuerza, int destreza, int evasion, int velocidad){
            Id = id;
            Nombre = nombre;
            Tipo = tipo;
            Nivel =nivel;
            Salud = 100;
            Fuerza = fuerza;
            Destreza = destreza;
            Evasion = evasion;
            Velocidad = velocidad;
        }

        // Método para mostrar el personaje
        public override string ToString() {
            return $"ID: {Id}, Nombre: {Nombre}, Tipo: {Tipo}, Nivel: {Nivel}, Salud: {Salud} ,Fuerza: {Fuerza}, Destreza: {Destreza}, Evasion: {Evasion}, Velocidad: {Velocidad}";
        }
            
        //Esta funcion va a recibir la lista general y devolvera la lista con 10 personajes 
        public List<Personaje> ObtenerAleatorios(List<Personaje> Lista){ 

            var Aleatorios = new List<Personaje>();
            Random random = new Random();
            for (int i = 0; i < 10; i++) {

                int indice = random.Next(Lista.Count);
                Aleatorios.Add(Lista[indice]);
                Lista.RemoveAt(indice);
            }

            return Aleatorios;
        }
    }
}




