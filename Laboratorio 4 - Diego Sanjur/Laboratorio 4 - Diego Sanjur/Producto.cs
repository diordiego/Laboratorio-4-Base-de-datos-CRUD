using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_4___Diego_Sanjur
{
    public class Producto
    { 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public byte[] Imagen { get; set; } 
    }
}
