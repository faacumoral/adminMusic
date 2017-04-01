using musicAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicAdmin.Controllers
{
    // implementacion patron singleton
    public class DataController
    {
        private DataController dc = null;
        public DataController()
        {
            dc = this;
        }
        public static USB defaultUsb = null;

        public static string defaultPath = null;

        public static string fromUsername = null;

        public static string fromPassword = null;

        public static string mailTo = null;

        public static string smtpServer = null;

        public static int smtpPort = 0;

        public static bool mailEnviado = false;

        public static bool areMailPropertiesSet 
        {
            get 
            {
                return mailTo != null && smtpServer != null && smtpPort != 0 && mailTo != null && fromUsername != null && fromPassword != null;
            }
            
        }
    }
}
