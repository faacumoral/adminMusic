using musicAdmin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        /* muestra el form de carga 
         * @form: form actual (para deshabilitar)
         * @msg: mensaje a mostrar
         * @return: thread del form de carga
         */
        public static Thread Loading(string msg)
        {
            var th = new Thread(() => new Loading(msg).ShowDialog());
            th.Start();
            return th;
        }
        /* oculta el form
         * @form: form a deshabilitar
         * @th: thread a abortar
         */ 
        public static void LoadingFinish(Thread th)
        {
            th.Abort();
        }
    }
}
