using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CNPC.SISDUC.DAL.Helper
{
    public class SqlHelper : IDisposable
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        public SqlHelper(string conexion)
        {
            cn = new SqlConnection(conexion);
            cmd = cn.CreateCommand();
        }
        public SqlDataReader ExecuteReader(string storedProcedure)
        {
            cmd.CommandText = storedProcedure;
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public SqlDataReader ExecuteReader(string storedProcedure, ParametroSP parametroSP)
        {
            cmd.CommandText = storedProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            if (parametroSP != null)
            {
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = parametroSP.Nombre;
                parametro.SqlDbType = parametroSP.TipoDato;
                if (parametroSP.Tamanio != 0)
                {
                    parametro.Size = parametroSP.Tamanio;
                }
                parametro.Direction = parametroSP.Direccion;
                parametro.Value = parametroSP.Value;

                cmd.Parameters.Add(parametro);
            }
            cn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public SqlDataReader ExecuteReader(string storedProcedure, List<ParametroSP> parametros)
        {
            cmd.CommandText = storedProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (var item in parametros)
            {
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = item.Nombre;
                parametro.SqlDbType = item.TipoDato;
                if (item.Tamanio != 0)
                {
                    parametro.Size = item.Tamanio;
                }
                parametro.Direction = item.Direccion;
                parametro.Value = item.Value;

                cmd.Parameters.Add(parametro);
            }
            cn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public int ExecuteNonQuery(string storedProcedure, List<ParametroSP> parametros)
        {
            int Result = 0;
            cmd.CommandText = storedProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (var item in parametros)
            {
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = item.Nombre;
                parametro.SqlDbType = item.TipoDato;
                if (item.Tamanio != 0)
                {
                    parametro.Size = item.Tamanio;
                }
                parametro.Direction = item.Direccion;
                parametro.Value = item.Value;

                cmd.Parameters.Add(parametro);
            }
            cn.Open();
            Result = cmd.ExecuteNonQuery();
            cn.Close();
            return Result;
        }

        public object ExecuteNonQuery(string storedProcedure, List<ParametroSP> parametros, string parametroSalida)
        {
            cmd.CommandText = storedProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (var item in parametros)
            {
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = item.Nombre;
                parametro.SqlDbType = item.TipoDato;
                if (item.Tamanio != 0)
                {
                    parametro.Size = item.Tamanio;
                }
                parametro.Direction = item.Direccion;
                parametro.Value = item.Value;

                cmd.Parameters.Add(parametro);
            }
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            return cmd.Parameters[parametroSalida].Value;
        }

        public void Dispose()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            cn.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
