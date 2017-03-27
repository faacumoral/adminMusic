using musicAdmin.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicAdmin.Controllers
{
    public class ArchivoController
    {
        /* 
         * @path: ruta donde buscar archivos
         * @return: lista de archivos
         */
        public List<Archivo> GetTodosEnUbicacion(string path)
        {
            List<Archivo> result = new List<Archivo>();
            try
            {
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    result.Add(GetFromPath(file));
                }
            } 
            catch (Exception e) 
            { 
                ExceptionController.FullException(e);
                return null;
            }
            return result;
        }

        /* 
         * @path: lista de rutas donde buscar archivos
         * @return: lista de archivos
         */
        public List<Archivo> GetTodosEnUbicacion(List<string> paths)
        {
            List<Archivo> result = new List<Archivo>();
            foreach (var path in paths)
            {
                result.AddRange(GetTodosEnUbicacion(path));
            }
            return result;
        }
        
        /*
         * @return: lista de USB conectados actualmente, vacia en caso de que no haya ninguno
         */
        public List<USB> GetUSBConectados()
        {
            List<USB> result = new List<USB>();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    result.Add(new USB
                    {
                        Etiqueta = drive.VolumeLabel,
                        Ruta = drive.RootDirectory.FullName
                    });
                }
            }
            return result;
        }
        /*
         * @archivo: archivo a copiar
         * @destino: ruta a donde copiar el archivo
         * @return: true si copio con exito, false si fallo
         */
        public bool Copiar(Archivo archivo, string destino)
        {
            try
            {
                string origen = Path.Combine(archivo.Ubicacion, archivo.FullName);
                string dest = destino + archivo.FullName;
                File.Copy(origen, dest, true);
                return true; 
            }
            catch (Exception e)
            {
                ExceptionController.FullException(e);
                return false;
            }
        }

        /*
         * crear un objeto archivo en base al path
         * @path: path donde buscar el archivo
         * @return: nuevo archivo generado, null si hubo excepcion
         */ 
        public static Archivo GetFromPath(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                return new Archivo
                {
                    Nombre = Path.GetFileNameWithoutExtension(path),
                    Tamanio = file.Length.ToString(),
                    Extension = file.Extension,
                    Ubicacion = file.DirectoryName
                };
            }
            catch (Exception e)
            {
                ExceptionController.FullException(e);
                return null;
            }
            
        }
    
    }
}
