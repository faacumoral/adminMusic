using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicAdmin
{
    public class Musica : Archivo
    {
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }
    }
}
