using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicAdmin.Controllers
{
    public class MusicaController : ArchivoController
    {
        /* 
         * @path: ruta donde buscar musica
         * @return: lista de archivos de musica
         */
        public List<Musica> GetTodas(string path)
        {
            return ParseArchivoAMusica(base.GetTodosEnUbicacion(path));
        }

        /* 
         * @path: lista de rutas donde buscar musica
         * @return: lista de archivos de musica
         */
        public List<Musica> GetTodas(List<string> paths)
        {
            // FIXME
            return null;
        }

        /* 
         * @return: lista de canciones en "My Music"
         */
        public List<Musica> GetTodasEnMyMusic()
        {
            return GetTodas(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
        }

        /* 
         * @files: lista de archivos
         * @return: lista de musica (filtrados por extension y casteados a musica)
        */
        public static List<Musica> ParseArchivoAMusica(List<Archivo> files)
        {
            List<Musica> result = new List<Musica>();
            foreach (Archivo file in files)
            {
                if (file.Extension == ".mp3")
                {
                    try 
                    {
                        TagLib.File tagFile = TagLib.File.Create(file.FullPath);
                        var titulo = tagFile.Tag.Title == null ? file.Nombre : tagFile.Tag.Title;
                        var artista = tagFile.Tag.FirstAlbumArtist == null ? "Sin artista" : tagFile.Tag.FirstAlbumArtist;
                        result.Add(new Musica
                        {
                            Nombre = file.Nombre,
                            Ubicacion = file.Ubicacion,
                            Tamanio = file.Tamanio,
                            Extension = file.Extension,
                            Titulo = titulo,
                            Album = tagFile.Tag.Album,
                            Artista = artista
                        });
                    } 
                    catch (Exception e) 
                    { 
                        ExceptionController.FullException(e);
                    }
                    
                }
                
            }
            return result;
        }
    }
}
