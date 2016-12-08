using System;

namespace CNPC.SISDUC.Domain.Exceptions
{
    #region "Accesorios"
    public class AccesorioInexistenteException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "El Accesorio no fue localizado";
            }
        }
    }

    public class CodigoAccesorioExistenteException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "El Código del accesorio ya existe";
            }
        }
    }
    public class AccesorioNoSeGuardoException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "El Accesorio no se guardó correctamente";
            }
        }
    }
    #endregion

    #region "RegistroInspeccionVisual"
    public class RegistroInspeccionVisualInexistenteException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "El RegistroDeInspeccionVisual no fue localizado";
            }
        }
    }
    public class RegistroInspeccionVisualesInexistenteException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "No se encontraron Registros De Inspeccion Visuales";
            }
        }
    }
    public class CodigoRegistroInspeccionVisualExistenteException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "El Código del Registro De InspeccionVisual ya existe";
            }
        }
    }
    public class RegistroInspeccionVisualNoSeGuardoException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "El Registro De Inspeccion Visual no se guardó correctamente";
            }
        }
    }
    #endregion

    #region "Oleoducto"
    public class OleoductoInexistenteException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "El Oleoducto no fue localizado";
            }
        }
    }
    public class OleoductosInexistenteException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "No se encontraron Oleoductos";
            }
        }
    }
    public class CodigoOleoductoExistenteException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "El Código del oleoducto ya existe";
            }
        }
    }
    public class OleoductoNoSeGuardoException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "El Oleoducto no se guardó correctamente";
            }
        }
    }
    #endregion

    #region "CambiosTuberia"
    public class CambiosTuberiaInexistenteException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "El Cambio Tuberia no fue localizado";
            }
        }
    }
    public class CodigoCambiosTuberiaExistenteException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "El Código del Cambio Tuberia ya existe";
            }
        }
    }
    public class CambiosTuberiaNoSeGuardoException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "El Cambio Tuberia no se guardó correctamente";
            }
        }
    }
    #endregion
    public static class SHA1
    {
        public static string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }
    }

}
