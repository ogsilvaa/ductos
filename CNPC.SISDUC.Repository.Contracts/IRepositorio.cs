using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPC.SISDUC.Repository.Contracts
{
    public interface IRepositorio<T> : IDisposable
    {
        T Agregar(T item);
        bool Actualizar(T item);
        bool Eliminar(int id);
        T BuscarPorId(int id);
        IEnumerable<T> Listar();
    }
    public interface IAccesorioRepositorio : IRepositorio<Accesorio>
    {
        IEnumerable<Accesorio> BuscarPorNombre(string Nombre);
        IEnumerable<Accesorio> BuscarPorOleoducto(int anio, int OleoductoId, string Nombre, int Page, int Records);
        int TotalBuscarPorNombre(int TuberiaId, string Nombre);
        Accesorio BuscarPorCodigo(string codigo);
        IEnumerable<Accesorio> BuscarPorTuberia(string TuberiaCodigo, string Nombre);
    }
    public interface IRegistroInspeccionVisualRepositorio : IRepositorio<RegistroInspeccionVisual>
    {
        IEnumerable<RegistroInspeccionVisual> BuscarPorNombre(int AnioInspeccion, int DuctoId, string Nombre);
        IEnumerable<RegistroInspeccionVisual> BuscarPorNombre(int AnioInspeccion, int DuctoId, string Nombre, int Page, int Records);
        int TotalBuscarPorNombre(int AnioInspeccion, int DuctoId, string Nombre);
        RegistroInspeccionVisual BuscarPorCodigo(int AnioInspeccion, string codigo);
        IEnumerable<RegistroInspeccionVisual> Listar(int AnioInspeccion, int DuctoId);
        IEnumerable<RegistroInspeccionVisual> GetListRegistroInspeccionVisualByNombre(int anio, int DuctoId, string Nombre);
        IEnumerable<RegistroInspeccionVisual> RegistroInspeccionVisualListarEliminados(int AnioInspeccion, int ductoId);
    }
    public interface IOleoductoRepositorio : IRepositorio<Oleoducto>
    {
        IEnumerable<Oleoducto> BuscarByNombre(string Nombre);
        decimal LongitudOleoducto(int Id);
        OleoductoResponse FilterByName(string prefijo,string Nombre, int page, int records);
        List<Oleoducto> GetListOleoductosByNombre(string prefijo,string Nombre);
        Oleoducto FilterByID(int ID);
        List<Inventario> ObtenerInventario();
    }
    public interface ITipoSoporteRepositorio : IRepositorio<TipoSoporte>
    {
        TipoSoporteResponse usp_GetListTipoSoporte();
    }
    public interface ICambiosTuberiaRepositorio : IRepositorio<CambiosTuberia>
    {
        CambiosTuberiaResponse usp_GetListCambiosTuberia(string NumeroOleoducto, int TuberiaID, int records, int page);
        IEnumerable<CambiosTuberia> BuscarPorNombre(string NumeroOleoducto, int TuberiaId, int Page, int Records, out int TotalPage);
    }
    public interface IUsuario : IRepositorio<Usuario>
    {
        IEnumerable<Usuario> BuscarByNombre(string Nombre);
        Usuario ValidarUsuario(string Usuario = "", string Contrasenia = "", bool ActiveDirectory = false);
        Usuario CreateUsuario(Usuario registro);

    }
    public interface IConstantes : IRepositorio<Constantes>
    {
        IEnumerable<Constantes> ListarTipoSoporte();
    }
    public interface ICambiosTuberia : IRepositorio<CambiosTuberia>
    {
        IEnumerable<CambiosTuberia> ListarCambiosTuberia();
    }
}
