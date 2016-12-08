using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using System;
using System.Collections.Generic;

namespace CNPC.SISDUC.Domain.Contracts
{
    public interface IDominio<T> : IDisposable
    {
        T Agregar(T item);
        bool Actualizar(T item);
        bool Eliminar(int id);
        T BuscarById(int id);
        IEnumerable<T> Listar();
    }
    public interface IAccesorioDomain : IDominio<Accesorio>
    {
        IEnumerable<Accesorio> BuscarPorNombre(string Nombre);
        IEnumerable<Accesorio> BuscarPorOleoducto(int anio, int Oleoducto, string Nombre, int Page, int Records);
        Accesorio BuscarPorCodigo(string codigo);
        AccesorioResponse FilterByTuberiaAccesorios(string TuberiaCodigo, string Nombre);
    }
    public interface IRegistroDeInspeccionVisualDomain : IDominio<RegistroInspeccionVisual>
    {
        RegistroInspeccionVisual Agregar(RegistroInspeccionVisual item, int anio = 2016);
        RegistroInspeccionVisual RetrieveByID(int ID);
        IEnumerable<RegistroInspeccionVisual> BuscarPorNombre(int AnioInspeccion, int DuctoId, string Nombre);
        IEnumerable<RegistroInspeccionVisual> BuscarPorNombre(int AnioInspeccion, int DuctoId, string Nombre, int Page, int Records);
        List<RegistroInspeccionVisual> GetListRegistroInspeccionVisualByNombre(int anio, int DuctoId, string Nombre);
        int TotalBuscarPorNombre(int AnioInspeccion, int DuctoId, string Nombre);
        RegistroInspeccionVisual BuscarPorCodigo(int AnioInspeccion, string codigo);
        IEnumerable<RegistroInspeccionVisual> Listar(int AnioInspeccion, int DuctoId);
    }
    public interface IOleoductoDomain : IDominio<Oleoducto>
    {
        IEnumerable<Oleoducto> BuscarByNombre(string Nombre);
        decimal LongitudOleoducto(int Id);
    }
    public interface ITipoSoporteDomain : IDominio<Oleoducto>
    {
         TipoSoporteResponse GetListTipoSoporte();
    }
    public interface ICambiosTuberiaDomain : IDominio<CambiosTuberia>
    {
        CambiosTuberiaResponse GetListCambiosTuberia(string NumeroOleoducto, int TuberiaID, int page, int records);
    }
}
