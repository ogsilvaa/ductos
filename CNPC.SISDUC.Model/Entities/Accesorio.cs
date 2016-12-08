namespace CNPC.SISDUC.Model
{
    using System;

    public class Accesorio
    {
        public virtual int Id { get; set; }
        public virtual string NombreAccesorio { get; set; }
        public virtual string CodigoTuberia { get; set; }
        public virtual string Correlativo { get; set; }
        public virtual string CodigoAccesorio { get; set; }
        public virtual Nullable<decimal> NPS { get; set; }
        public virtual Nullable<int> Schedule { get; set; }
        public virtual string TipoMaterial { get; set; }
        public virtual Nullable<decimal> Longitud { get; set; }
        public virtual Nullable<int> CoordenadasUTMX { get; set; }
        public virtual Nullable<int> CoordenadasUTMY { get; set; }
        public virtual string Observaciones { get; set; }
        public virtual string CondicionAccesorio { get; set; }
        public virtual string RowState { get; set; }
        public virtual Nullable<System.DateTime> LastUpdate { get; set; }
        public virtual int RegistroInspeccionVisualId { get; set; }
        public override bool Equals(Object obj)
        {
            if (obj is Accesorio)
            {
                var that = obj as Accesorio;
                bool result = this.Id == that.Id &&
                    this.NombreAccesorio == that.NombreAccesorio &&
                    this.CodigoTuberia == that.CodigoTuberia &&
                    this.Correlativo == that.Correlativo &&
                    this.NPS == that.NPS &&
                    this.Schedule == that.Schedule &&
                    this.TipoMaterial == that.TipoMaterial &&
                    this.Longitud == that.Longitud &&
                    this.CoordenadasUTMX == that.CoordenadasUTMX &&
                    this.CoordenadasUTMY == that.CoordenadasUTMY &&
                    this.Observaciones == that.Observaciones &&
                    this.CondicionAccesorio == that.CondicionAccesorio &&
                    this.RowState == that.RowState &&
                    this.LastUpdate == that.LastUpdate &&
                    this.RegistroInspeccionVisualId == that.RegistroInspeccionVisualId;
                return result;
            }
            else
            {
                return false;
            }

        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
