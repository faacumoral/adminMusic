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

        /* sobrecarga de GetTodas, lee en path por default
         * @return: lista de archivos de musica
         */
        public List<Musica> GetTodas()
        {
            return ParseArchivoAMusica(base.GetTodosEnUbicacion(DataController.defaultPath));
        }
        /* 
         * busca canciones en lista de paths
         * @path: lista de rutas donde buscar musica
         * @return: lista de archivos de musica
         */
        public List<Musica> GetTodas(List<string> paths)
        {
            List<Musica> result = new List<Musica>();
            foreach (string pa in paths)
            {
                result.Add(this.CreateFromPath(pa));
            }
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
         * crear objeto musica a partir del path (crea archivo y luego castea)
         * @path: donde buscar archivo
         * @return: archivo musica creado en base al path
         */
        public Musica CreateFromPath(string path)
        {
            var file = ArchivoController.GetFromPath(path);
            return CreateFromArchivo(file);
        }
        /*
         * crea objecto musica en base a archivo
         * @file: archivo a parsear
         * @return: nuevo objeto musica
         */
        public Musica CreateFromArchivo(Archivo file)
        {
            try
            { 
                TagLib.File tagFile = TagLib.File.Create(file.FullPath);
                var titulo = tagFile.Tag.Title == null ? file.Nombre : tagFile.Tag.Title;
                var artista = tagFile.Tag.AlbumArtists.Count() == 0 ? "Sin artista" : tagFile.Tag.AlbumArtists[0];
                return new Musica
                {
                    Nombre = file.Nombre,
                    Ubicacion = file.Ubicacion,
                    Tamanio = file.Tamanio,
                    Extension = file.Extension,
                    Titulo = titulo,
                    Album = tagFile.Tag.Album,
                    Artista = artista
                };
            }
            catch ( Exception e)
            {
                ExceptionController.FullException(e);
                return null;
            }
        }

        /* 
         * @files: lista de archivos
         * @return: lista de musica (filtrados por extension y casteados a musica)
        */
        public static List<Musica> ParseArchivoAMusica(List<Archivo> files)
        {
            MusicaController mc = new MusicaController();
            List<Musica> result = new List<Musica>();
            foreach (Archivo file in files)
            {
                if (file.Extension == ".mp3")
                {
                    try 
                    {
                        result.Add(mc.CreateFromArchivo(file));
                    } 
                    catch (Exception e) 
                    { 
                        ExceptionController.FullException(e);
                    }
                    
                }
                
            }
            return result;
        }
        /* cambia tags (arttista, title y album) de la cancion
         * @mus: cancion a modificar
         */
        public void ChangeMusicaTags(Musica mus)
        {
            TagLib.File tagFile = TagLib.File.Create(mus.FullPath);
            tagFile.Tag.Title = mus.Titulo != null ? mus.Titulo : tagFile.Tag.Title;
            tagFile.Tag.Album = mus.Album != null ? mus.Album : tagFile.Tag.Album;
            if (mus.Artista != "Sin artista") tagFile.Tag.AlbumArtists = new string[] { mus.Artista };
            tagFile.Save();
        }
    }
}
