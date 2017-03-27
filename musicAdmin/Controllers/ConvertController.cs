using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicAdmin.Controllers
{
    public class ConvertController
    {
        /*
         * @path: path del archivo a convertir a mp3
         * @return: path del nuevo archivo convertido, null si fallo conversion
         */
        public static string MP4ToMP3(string path)
        {
            try
            {
                Archivo archivo = ArchivoController.GetFromPath(path);
                string newFile = System.IO.Path.Combine(archivo.Ubicacion, archivo.Nombre) + ".mp3";
                var input = new MediaFile { Filename = archivo.FullPath };
                var output = new MediaFile { Filename = newFile };

                using (var engine = new Engine())
                {
                    engine.GetMetadata(input);

                    engine.Convert(input, output);
                }
                System.IO.File.Delete(path);
                return newFile;
            }
            catch (Exception e)
            {
                ExceptionController.FullException(e);
                return null;
            }
            

        }
    }
}
