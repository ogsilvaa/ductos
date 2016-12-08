using System.Configuration;

namespace CNPC.SISDUC.Repository.SqlServer
{
    public static class Util
    {
        public static string Conexion()
        {
            return ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString;
        }
    }
}
