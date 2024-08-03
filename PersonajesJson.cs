
//4) Crear un método llamado Existe que reciba un nombre de archivo y que retorne un True
//si existe y tiene datos o False en caso contrario*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
//using System.Threading.Tasks;
using System.Text.Json.Serialization;
using espacioPersonaje;
using TrabajandoJson;

namespace espacioJson
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> ListaPersonajes, string NombreArchivo){
 
            try
            {
                var miHelperdeArchivos = new HelperDeJson();
                var options = new JsonSerializerOptions { WriteIndented = true };
                string personajesJson = JsonSerializer.Serialize(ListaPersonajes, options);
                Console.WriteLine("Archivo Serializado : " + NombreArchivo);
                miHelperdeArchivos.GuardarArchivoTexto(NombreArchivo, personajesJson); 
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al guardar el archivo: " + ex.Message);
                throw;
            } 
        }

        public List<Personaje> LeerPersonajes(string nombreArchivo) {

            try
            {
                var miHelperDeArchivos = new HelperDeJson();
                string jsonDocument = miHelperDeArchivos.AbrirArchivoTexto(nombreArchivo); 
                Console.WriteLine();
                var listadoPersonajesRecuperados = JsonSerializer.Deserialize<List<Personaje>>(jsonDocument);

                return listadoPersonajesRecuperados;                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al guardar el archivo: " + ex.Message);
                throw;
            }

        }

        public bool Existe(string rutaArchivo){
            return File.Exists(rutaArchivo);
        }
    }
}