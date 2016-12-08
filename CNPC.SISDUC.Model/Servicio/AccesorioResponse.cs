﻿using System.Runtime.Serialization;

namespace CNPC.SISDUC.Model.Servicio
{
    [DataContract]
    public class AccesorioResponse : Response<Accesorio>
    {
        [DataMember]
        public bool Resultado { get; set; } //true-OK, false-Error
        [DataMember]
        public string MensajeError { get; set; }
    }
}