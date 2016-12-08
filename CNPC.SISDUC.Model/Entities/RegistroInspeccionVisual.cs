//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPC.SISDUC.Model
{
    using System;
    using System.Collections.Generic;

    public partial class RegistroInspeccionVisual
    {
        public int Id { get; set; }
        public int OleoductoID { get; set; }
        public string CodigoDelTubo { get; set; }
        public string NumeroOleoducto { get; set; }
        public string CodigoDelTubo01 { get; set; }
        public string CodigoDelTubo02 { get; set; }
        public string CodigoDelTubo03 { get; set; }
        public Nullable<int> NumeroAnterior { get; set; }
        public Nullable<decimal> NPS { get; set; }
        public Nullable<int> Schedule { get; set; }
        public Nullable<int> SHC { get; set; }
        public string TipoMaterial { get; set; }
        public Nullable<decimal> Longitud { get; set; }
        public string CoordenadasUTM_X { get; set; }
        public string CoordenadasUTM_Y { get; set; }
        public Nullable<decimal> ExtremoInicial1 { get; set; }
        public Nullable<decimal> ExtremoInicial2 { get; set; }
        public Nullable<decimal> ExtremoInicial3 { get; set; }
        public Nullable<decimal> ExtremoInicial4 { get; set; }
        public Nullable<decimal> BSCAN { get; set; }
        public Nullable<decimal> EspesorPared { get; set; }
        public Nullable<decimal> ExtremoMedio1 { get; set; }
        public Nullable<decimal> ExtremoMedio2 { get; set; }
        public Nullable<decimal> ExtremoMedio3 { get; set; }
        public Nullable<decimal> ExtremoMedio4 { get; set; }
        public Nullable<decimal> MapeoCorrison { get; set; }
        public Nullable<decimal> PitCorrosion { get; set; }
        public Nullable<decimal> ExtremoFinal1 { get; set; }
        public Nullable<decimal> ExtremoFinal2 { get; set; }
        public Nullable<decimal> ExtremoFinal3 { get; set; }
        public Nullable<decimal> ExtremoFinal4 { get; set; }
        public Nullable<decimal> LEFT_MINIMO { get; set; }
        public Nullable<decimal> EspesorRemanente { get; set; }
        public string Defecto { get; set; }
        public Nullable<bool> Defecto2 { get; set; }
        public Nullable<int> NumeroGrapas { get; set; }
        public string TipoSoporte { get; set; }
        public Nullable<bool> Elastomero { get; set; }
        public Nullable<bool> Maleza { get; set; }
        public Nullable<bool> TuberiaAlrededor { get; set; }
        public Nullable<bool> Pintura { get; set; }
        public Nullable<bool> CruceCarretera { get; set; }
        public string TipoProteccion { get; set; }
        public string EstadoProteccion { get; set; }
        public string EstadoTuberia { get; set; }
        public Nullable<System.DateTime> UltimaFechaDeInspeccion { get; set; }
        public int AnioInspeccion { get; set; }
        public Nullable<bool> SeleccionarTuberia { get; set; }
        public string RowState { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public Nullable<int> TuberiaId { get; set; }
    }
}