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
using System.Windows.Shapes;

namespace PracticaModeloDom
{
    /// <summary>
    /// Lógica de interacción para VentanaImagenes.xaml
    /// </summary>
    public partial class VentanaImagenes : Window
    {
        public VentanaImagenes()
        {
            InitializeComponent();
            CargarImagenes();
        }


        public void CargarImagenes()
        {
            foreach(String s in Datos.listaDirecciones)
            {
                getImage(s);
            }
        }

        private void getImage(string url)
        {

            Image img = new Image();
            string ur = url.Replace("http", "https");
            img.Source = new BitmapImage(new Uri(ur));
            img.Height = 250;
            img.Width = 350;
            img.Margin = new Thickness(10);
            img.Stretch = Stretch.UniformToFill;
            salidaImagenes.Orientation = Orientation.Horizontal;
            salidaImagenes.Children.Add(img);

        }

    }
}
