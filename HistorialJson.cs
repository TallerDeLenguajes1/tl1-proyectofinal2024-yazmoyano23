using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using espacioPersonaje;
using TrabajandoJson;
namespace especioHistorial
{
    class HistorialJson
    {
        public void GuardarGanador(Personaje Ganador, string NombreArchivo){ //Pendiente la info relevante
            try
            {
                var listaGanadores = new List<Personaje>();

                if (Existe(NombreArchivo)) //Si el archivo existe y tiene ganadores
                {
                    listaGanadores = LeerGanadores(NombreArchivo); //Recibo la lista del archivo con ganadores
                    listaGanadores.Add(Ganador); //Agrego el nuevo
            
                } else {
                    listaGanadores.Add(Ganador);
                }
                
                var miHelperdeArchivos = new HelperDeJson();

                var options = new JsonSerializerOptions { WriteIndented = true };
                string ganadoresJson = JsonSerializer.Serialize(listaGanadores, options);
                Console.WriteLine("Guardando ganador...");
                miHelperdeArchivos.GuardarArchivoTexto(NombreArchivo, ganadoresJson);   

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al guardar el archivo: " + ex.Message);
                throw;
            } 
        }

        public List<Personaje> LeerGanadores(string nombreArchivo) {

            try
            {
                var miHelperDeArchivos = new HelperDeJson();
                string jsonDocument = miHelperDeArchivos.AbrirArchivoTexto(nombreArchivo); 
                Console.WriteLine();
                var GanadoresRecuperados = JsonSerializer.Deserialize<List<Personaje>>(jsonDocument);

                return GanadoresRecuperados;                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al guardar el archivo: " + ex.Message);
                throw;
            }

        }

        public bool Existe(string rutaArchivo) {

            FileInfo fileInfo = new FileInfo(rutaArchivo);

            if (File.Exists(rutaArchivo)) //si existe y tiene datos
            {
                if (fileInfo.Length > 0)
                {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

    }
}
