namespace espacioDatosPelea
{
    public class DatosPelea {
        private string? Oponente;
        private int SaludRestante;
        private int Ataques;

        public string? oponente { get => Oponente; set => Oponente = value; }
        public int saludrestante { get => SaludRestante; set => SaludRestante = value; }
        public int ataques { get => Ataques; set => Ataques = value; }

        public DatosPelea(){}

        // Método para mostrar el personaje
        public override string ToString() {
            return $"Oponente: {Oponente} - Salud Restante: {SaludRestante} - Ataques realizados: {Ataques}";
        }
            
    }
}