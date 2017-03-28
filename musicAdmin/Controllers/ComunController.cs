using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicAdmin.Controllers
{
    public class ComunController
    {
        /* quita caracteres no permitidos para path
         * @path: a modificar
         * @return: nuevo path sin caracteres
         */
        public static string QuitarCaracteresProhibidos(string path)
        {
            foreach (char ch in System.IO.Path.GetInvalidFileNameChars())
	        {
                path = path.Replace(ch, ' ');		 
	        }
            return path;
        }
    }
}
