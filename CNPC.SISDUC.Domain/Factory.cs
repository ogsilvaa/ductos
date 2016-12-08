using System.Reflection;

namespace CNPC.SISDUC.Domain
{
    public static class Factory<I>
    {
        public static I GetInstancia()
        {
            string libreria = "CNPC.SISDUC.Repository.SqlServer";
            string clase = "CNPC.SISDUC.Repository.SqlServer." + typeof(I).Name.Substring(1);

            Assembly assembly = Assembly.Load(libreria);
            return (I)assembly.CreateInstance(clase);
        }
    }
}
