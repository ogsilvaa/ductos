using System.Data;

namespace CNPC.SISDUC.DAL.Helper
{
    public class ParametroSP
    {
        public ParametroSP(string nombre, SqlDbType tipoDato, int tamanio, object value, 
                           ParameterDirection direccion = ParameterDirection.Input)
        {
            this.Nombre = nombre;
            this.TipoDato = tipoDato;
            this.Tamanio = tamanio;
            this.Direccion = direccion;
            this.Value = value;
        }
        public string Nombre { get; set; }
        public SqlDbType TipoDato { get; set; }
        public int Tamanio { get; set; }
        public ParameterDirection Direccion { get; set; }
        public object Value { get; set; }
    }
}
