using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaModeloDom
{
    public class Alojamiento
    {
        public Alojamiento()
        {

        }

        public Alojamiento(string nombre, string email, string telefono, string codPostal, string fechaActualizacion, string web, string direccion, string pais, string ciudad, string tipo, string categoria, string subCategoria, string descripcion)
        {
            this.nombre = nombre;
            this.email = email;
            this.telefono = telefono;
            this.codPostal = codPostal;
            this.fechaActualizacion = fechaActualizacion;
            this.web = web;
            this.direccion = direccion;
            this.pais = pais;
            this.ciudad = ciudad;
            this.tipo = tipo;
            this.categoria = categoria;
            this.subCategoria = subCategoria;
            this.descripcion = descripcion;
        }

        public String nombre { get; set; }
        public String email { get; set; }
        public String telefono { get; set; }
        public String codPostal { get; set; }
        public String fechaActualizacion { get; set; }
        public String web { get; set; }
        public String direccion { get; set; }
        public String pais { get; set; }
        public String ciudad { get; set; }
        public String tipo { get; set; }
        public String categoria { get; set; }
        public String subCategoria { get; set; }
        public String descripcion { get; set; }
    }
}
