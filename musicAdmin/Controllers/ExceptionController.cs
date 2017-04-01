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
    public class ExceptionController
    {
        public static void FullException (Exception e)
        {
            // FIXME
            // tratado de excepciones
            FullException(e, true);
        }
        public static void FullException(Exception e, bool mail)
        {
            try
            {
                Inicio.ShowMessageBox("Se ha producido un error. Contacte el administrador. El programa se cerrará." );
                if (mail)
                {
                    if (DataController.mailEnviado)
                    {
                        return;
                    }
                    DataController.mailEnviado = true;
                    Thread th = ComunController.Loading("Por favor espere, se está informando sobre el error.");
                    MailController mc = new MailController();
                    string body = "Se ha producido un error en AdminMusic. <br>Mensaje de error: " + e.Message + "<br>Data: " + e.Data + "<br>Numero: " + e.HResult + "<br>Inner exception: " + e.InnerException;
                    string subject = "Error Admin Music - " + DateTime.Now.ToShortDateString();
                    mc.EnviarMail(subject, body);
                    ComunController.LoadingFinish(th);
                }
            }
            catch (Exception er)
            {
                FullException(er, false);
            }
            finally
            {
                Application.Exit();
            }

        }
    }
}
