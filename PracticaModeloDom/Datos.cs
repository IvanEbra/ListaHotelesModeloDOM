 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Net.Http;
using System.IO;

namespace PracticaModeloDom
{
    public class Datos
    {
        public XmlDocument documento = new XmlDocument();
        public XmlElement raiz;
        public XmlNodeList nombres;
        private XmlNodeList listaService;
        private XmlNode multimedia;
        public Alojamiento alojamiento=new Alojamiento();
        public static List<String> listaDirecciones = new List<String>();

        public async Task CargarXml(String ruta)
        {
            HttpClient cliente = new HttpClient();
            Stream respuesta = await cliente.GetStreamAsync(ruta);
            StreamReader reader = new StreamReader(respuesta, System.Text.Encoding.ASCII, false);
            documento.Load(reader);
            raiz = documento.DocumentElement;
            nombres =raiz.GetElementsByTagName("name");
            listaService = raiz.GetElementsByTagName("service");
        }

        public  void CargarAlojamientos(String nombreSeleccionado)
        {
            SautinSoft.HtmlToRtf h = new SautinSoft.HtmlToRtf();
            h.OutputFormat = SautinSoft.HtmlToRtf.eOutputFormat.TextUnicode;

            foreach (XmlElement nodo in listaService)
            {
                if (Convert.ToString(nodo["basicData"]["name"].InnerText).Equals(nombreSeleccionado))
                {
                    try
                    {
                        alojamiento.nombre = Convert.ToString(nodo["basicData"]["name"].InnerText);
                        alojamiento.email = nodo["basicData"]["email"].InnerText;
                        alojamiento.telefono = nodo["basicData"]["phone"].InnerText;
                        alojamiento.codPostal = nodo["geoData"]["zipcode"].InnerText;
                        alojamiento.fechaActualizacion = nodo.Attributes["fechaActualizacion"].Value;
                        alojamiento.web = nodo["basicData"]["web"].InnerText;
                        alojamiento.direccion = nodo["geoData"]["address"].InnerText;
                        alojamiento.pais = nodo["geoData"]["country"].InnerText;
                        alojamiento.ciudad = nodo["geoData"]["subAdministrativeArea"].InnerText;
                        alojamiento.tipo = nodo["extradata"].SelectSingleNode("item[@name='Tipo']").InnerText;
                        alojamiento.categoria = nodo["extradata"]["categorias"]["categoria"].SelectSingleNode("item[@name='Categoria']").InnerText;
                        alojamiento.subCategoria = nodo["extradata"]["categorias"]["categoria"]["subcategorias"]["subcategoria"].SelectSingleNode("item[@name='SubCategoria']").InnerText;
                        alojamiento.descripcion = h.ConvertString(nodo["basicData"]["body"].InnerText);
                        multimedia = nodo["multimedia"];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    
                }
            }

            CargarDireccionesImagenes();
        }

        public void CargarDireccionesImagenes()
        {
            listaDirecciones.Clear();
            if (multimedia != null)
            {
                foreach (XmlElement nodo in multimedia)
                {
                    String ruta = nodo["url"].InnerText;
                    listaDirecciones.Add(ruta);
                }
            }
        }
    }
}
