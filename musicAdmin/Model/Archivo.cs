using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicAdmin
{
    public class Archivo
    {
        public string Nombre { get; set; }
        public string Tamanio { get; set; }
        public string Ubicacion { get; set; }
        public string Extension { get; set; }
        public string FullPath 
        { 
            get 
            {
                return System.IO.Path.Combine(this.Ubicacion, this.Nombre) + Extension;
            }
        }
        public string FullName
        {
            get
            {
                return this.Nombre + this.Extension;
            }
        }
    }
}
