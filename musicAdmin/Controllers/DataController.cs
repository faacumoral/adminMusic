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
        public static object defaultUsb = null;

        public static string defaultPath = null;
    }
}
