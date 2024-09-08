using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CadaDatos
{
    public class Conexion
    {
        public static string cn= ConfigurationManager.ConnectionStrings["MiCadena"].ToString();
    }
}
