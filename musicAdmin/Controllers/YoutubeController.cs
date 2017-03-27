using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExtractor;

namespace musicAdmin.Controllers
{
    public class YoutubeController
    {
        /*
         * @link: link del video a descargar
         * @path: donde se va a guardar el video
         * @return: el full path del nuevo archivo, null si fallo
         */
        public static string GetVideo(string link, string path)
        {
            try
            {
                IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(link);
                // get video
                VideoInfo video = videoInfos
                    .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360);

                if (video.RequiresDecryption)
                {
                    DownloadUrlResolver.DecryptDownloadUrl(video);
                }
                string fullPath = System.IO.Path.Combine(path, video.Title) + ".mp4";
                var videoDownloader = new VideoDownloader(video, fullPath);
                // FIXME manejo de progress bar
                //videoDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage);
                videoDownloader.Execute();
                return fullPath;
            }
            catch (Exception e)
            {
                ExceptionController.FullException(e);
                return null;
            }
            
        }

        /*
         * @link: link del video a descargar
         * @path: donde se va a guardar el audio
         * @return: path del video
         */
        public static string GetAudioFromVideo(string link, string path)
        {
            return ConvertController.MP4ToMP3(GetVideo(link, path));
        }
    }
}
