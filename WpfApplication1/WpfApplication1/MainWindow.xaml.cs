using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly List<Alumno> ListaDeAlumnos;
        readonly List<Alumno> ListaAtletismo;
        readonly List<Alumno> ListaVoley;
        readonly List<Alumno> ListaFutbol;
        string RutaAtletismo = AppDomain.CurrentDomain.BaseDirectory + "/Atletismo.csv";
        string RutaVoley = AppDomain.CurrentDomain.BaseDirectory + "/Voley.csv";
        string RutaFutbol = AppDomain.CurrentDomain.BaseDirectory + "/Futbol.csv";

        public MainWindow()
        {
            InitializeComponent();
            ListaDeAlumnos = new List<Alumno>();
            ListaAtletismo = new List<Alumno>();
            ListaVoley = new List<Alumno>();
            ListaFutbol = new List<Alumno>();
        }

        private void btnagregar_Click(object sender, RoutedEventArgs e)
        {
            Alumno NuevoAlumno = new Alumno();
            string Nombre = txbnombre.Text;
            string Apellido = txbapellido.Text;
            string ID = txbid.Text;
            string InscripcionACurso = Convert.ToString(cbocurso.Text);

            if (EsValido(ID) & EsValidoChar(Nombre) & EsValidoChar(Apellido) & EsValidoID(int.Parse(ID), ListaDeAlumnos))
            {
                NuevoAlumno.ID = int.Parse(ID);
                NuevoAlumno.Nombre = Nombre;
                NuevoAlumno.Apellido = Apellido;
                NuevoAlumno.Curso = InscripcionACurso;

                if (Nombre.Length > 2 & Apellido.Length > 2)
                {
                    ListaDeAlumnos.Add(NuevoAlumno);
                    MessageBox.Show("El alumno fue cargado correctamente.");
                    lbxalumnos.Items.Add(NuevoAlumno.ToString());
                }
                else { MessageBox.Show("Nombre o apellido incorrecto, inténtelo de nuevo."); }
            }
            else { MessageBox.Show(" Alguno de los campos ingresados es incorrecto, vuelva a intentarlo."); }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnexportar_Click(object sender, RoutedEventArgs e)
        {
            foreach (Alumno Estudiante in ListaDeAlumnos)
            {
                if(Estudiante.Curso == Convert.ToString(Curso.Atletismo))
                {
                    ListaAtletismo.Add(Estudiante);
                }

                if (Estudiante.Curso == Convert.ToString(Curso.Voley))
                {
                    ListaVoley.Add(Estudiante);
                }

                if (Estudiante.Curso == Convert.ToString(Curso.Futbol))
                {
                    ListaFutbol.Add(Estudiante);
                }
            }
            //Atletismo
            HelperDeArchivos.CargarArchivo(RutaAtletismo, ListaAtletismo);
            //Voley
            HelperDeArchivos.CargarArchivo(RutaVoley, ListaVoley);
            //Futbol
            HelperDeArchivos.CargarArchivo(RutaFutbol, ListaFutbol);
            MessageBox.Show("Los archivos fueron exportados correctamente.");
        }

        public static bool EsValido(string AVerificar)
        {
            int Contador=0;
            bool resultado = false;
            for(int i=0; i< AVerificar.Length; i++)
            {
                if (char.IsNumber(AVerificar[i]))
                {
                    Contador++;
                }
                
            }
            if (Contador == AVerificar.Length)
            {
                resultado = true;
            }

            return resultado;
        }

        public static bool EsValidoChar(string AVerificar)
        {
            int Contador = 0;
            bool resultado = false;
            for (int i = 0; i < AVerificar.Length; i++)
            {
                if (char.IsLetter(AVerificar[i]))
                {
                    Contador++;
                }

            }
            if (Contador == AVerificar.Length)
            {
                resultado = true;
            }

            return resultado;
        }

         private static bool EsValidoID(int AVerificar, List<Alumno> ListaDeAlumnos)
        {
            bool resultado = true;
            foreach (Alumno Estudiante in ListaDeAlumnos)
            {
                if( AVerificar == Estudiante.ID)
                {
                    MessageBox.Show("El ID ingresado ya existe, pruebe con otro.");
                    resultado = false;
                }
            }

            return resultado;
        }
    }
}