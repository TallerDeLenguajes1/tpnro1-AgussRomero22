using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApplication1
{
     static class HelperDeArchivos
    {
        //Método para cargarlo y limpiarlo
        public static void CargarArchivo(string Ruta, List<Alumno> ListaDeAlumnos)
        {
            StreamWriter writer = new StreamWriter(Ruta);
            string contenido = null;
            for (int i = 0; i < ListaDeAlumnos.Count; i++)
            {
                contenido = string.Format("{0}, {1}, {2}, {3}", ListaDeAlumnos[i].Nombre, ListaDeAlumnos[i].Apellido, ListaDeAlumnos[i].ID, ListaDeAlumnos[i].Curso);
                writer.WriteLine(contenido);
            }

            writer.Close();
        }

        public static void LimpiarArchivo(string Ruta)
        {
            File.Create(Ruta);
        }
    }
}
