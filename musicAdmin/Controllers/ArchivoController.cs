using musicAdmin.Forms;
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
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.DriveType == DriveType.Removable && drive.IsReady)
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
            catch (Exception e)
            {
                ExceptionController.FullException(e);
                return result;
            }
            
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

        /* sobrecarga de copiar, si no viene destino manda al defaultUsb
         * @archivo: arhivo a copiar
         * @return: true si copio bien, false si fallo
         */
        public bool Copiar(Archivo archivo)
        {
            return Copiar(archivo, DataController.defaultUsb.Ruta);
        }

        /*
         * crear un objeto archivo en base al path
         * @path: path donde buscar el archivo
         * @return: nuevo archivo generado, null si hubo excepcion
         */ 
        public void GetProperties()
        {
            try
            {
                System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create("properties.xml");
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == System.Xml.XmlNodeType.Element)
                    {
                       switch (xmlReader.Name)
	                   {
                            case "path":
                               var path = xmlReader.ReadInnerXml();
                               if (path == "MyMusic")
                               {
                                   DataController.defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                               } 
                               else
                               {
                                   DataController.defaultPath = path;
                               }
                                break;
                            case "smtpServer":
                               DataController.smtpServer = xmlReader.ReadInnerXml();
                               break;
                            case "smtpPort":
                                DataController.smtpPort = Int32.Parse(xmlReader.ReadInnerXml());
                                break;
                            case "fromUsername":
                               DataController.fromUsername = xmlReader.ReadInnerXml();
                               break;
                            case "fromPassword":
                               DataController.fromPassword = xmlReader.ReadInnerXml();
                               break;
                            case "mailTo":
                               DataController.mailTo = xmlReader.ReadInnerXml();
                               break;
	                   }
                    }
                }
            }
            catch (Exception e)
            {
                // si no leyo properties setea MyMusic por default
                DataController.defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                Inicio.ShowMessageBox("CATCH : " + e.Message);
                ExceptionController.FullException(e); 

            }
        }

        /* create archivo en base a Path
         * @string: path donde buscar el archivo
         * @return: archivo creado
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
        /* asigna un dafultUsb
         * @return: string con mensaje de error si algo fallo, null si todo ok
         */
        public string GetUSB()
        {
            if (DataController.defaultUsb == null)
            {
                var usbs = this.GetUSBConectados();
                if (usbs.Count == 0)
                {
                    return "No se han encontrado USB conectados.";
                }
                else if (usbs.Count == 1)
                {
                    // asigno ese usb como default
                    DataController.defaultUsb = usbs[0];
                }
                else
                {
                    return "Hay más de un dispositivo USB conectado. Por favor desconecte y deje uno solo.";
                }
            }
            // ya hay usb por default
            return null;
            
        }
    }
}
