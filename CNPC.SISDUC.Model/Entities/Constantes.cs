using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPC.SISDUC.Model
{
    public partial class Constantes
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public string Valor { get; set; }
        public string RowState { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
    }
    public enum EEstadoRowState
    {
        None = 0x0,
        A,   //ADDED
        U,//UNCHANGED
        M, //MODIFIED
        D // DELETED
    }
}
