using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{

    public enum Curso
    {
        Atletismo,
        Voley,
        Futbol
    }
    class Alumno
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Curso { get; set; }

        public override string ToString()
        {
            return ID + "," + Apellido + "," + Nombre + "," + Curso;
        }
    }
}
