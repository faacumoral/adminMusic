using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicAdmin.Controllers
{
    public class MediaPlayerController
    {
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        bool isPlaying = false;
        public void Play(string path)
        {
            try
            {
                wplayer.URL = path;
                if (this.isPlaying)
                {
                    wplayer.controls.stop();
                }
                wplayer.controls.play();
                isPlaying = true;
            }
            catch (Exception e)
            {
                ExceptionController.FullException(e);
            }
            
        }

        public void Stop()
        {
            try
            {
                wplayer.controls.stop();
            }
            catch (Exception e)
            {
                ExceptionController.FullException(e);
            }
        }

    }
}
