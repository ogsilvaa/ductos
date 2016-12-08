
namespace CNPC.SISDUC.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CambiosTuberia
    {
        public int Id { get; set; }
        public string NumeroOleoducto { get; set; }
        public string CodigoDelTubo01 { get; set; }
        public string CodigoDelTuboReemplazado { get; set; }
        public int TuberiaId { get; set; }
        public string Motivo { get; set; }
        public string OrdenServicio { get; set; }
        public Nullable<System.DateTime> FechaOrdenServicio { get; set; }
        public string RowState { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
    }
}
