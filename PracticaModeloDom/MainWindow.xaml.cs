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
using System.Xml;

namespace PracticaModeloDom
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Datos datos=new Datos();
        public XmlNode elementoSeleccionado;

        public MainWindow()
        {
            InitializeComponent();
            CargarDatos();
        }

        private async void CargarDatos()
        {
            try
            {
                await datos.CargarXml("https://www.esmadrid.com/opendata/alojamientos_v1_es.xml");
                CargarListaNombres();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void CargarListaNombres()
        {
            listBoxNombres.ItemsSource = datos.nombres;
        }

        private void listBoxNombres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            botonVerImagenes.IsEnabled = true;

            textBoxNombre.Text = "";
            textBoxEmail.Text = "";
            textBoxTelefono.Text = "";
            textBoxCodigoPostal.Text = "";
            textBoxFechaActualizacion.Text = "";
            textBoxWeb.Text = "";
            textBoxDireccion.Text = "";
            textBoxPais.Text = "";
            textBoxCiudad.Text = "";
            textBoxTipo.Text = "";
            textBoxCategoria.Text = "";
            textBoxSubCategoria.Text = "";
            textBoxDescripcion.Text = "";

            elementoSeleccionado = listBoxNombres.SelectedItem as XmlNode;
            String nombreSeleccionado = elementoSeleccionado.InnerText;

            datos.CargarAlojamientos(nombreSeleccionado);
            try
            {
                textBoxNombre.Text = datos.alojamiento.nombre;
                textBoxEmail.Text = datos.alojamiento.email;
                textBoxTelefono.Text = datos.alojamiento.codPostal;
                textBoxCodigoPostal.Text = datos.alojamiento.codPostal;
                textBoxFechaActualizacion.Text = datos.alojamiento.fechaActualizacion;
                textBoxWeb.Text = datos.alojamiento.web;
                textBoxDireccion.Text = datos.alojamiento.direccion;
                textBoxPais.Text = datos.alojamiento.pais;
                textBoxCiudad.Text = datos.alojamiento.ciudad;
                textBoxTipo.Text = datos.alojamiento.tipo;
                textBoxCategoria.Text = datos.alojamiento.categoria;
                textBoxSubCategoria.Text = datos.alojamiento.subCategoria;
                textBoxDescripcion.Text = datos.alojamiento.descripcion;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void botonVerImagenes_Click(object sender, RoutedEventArgs e)
        {
            VentanaImagenes ventanaImagenes = new VentanaImagenes();
            ventanaImagenes.Show();
        }
    }
}
