using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencias
{
    public class PersistenciasCategorias
    {
        public static int AgregarCategoria(Categorias categoria)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("AgregarCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codCat", categoria.CodCat);
            oComando.Parameters.AddWithValue("@nomCat", categoria.NombreCat);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            int resultado = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                resultado = (int)oComando.Parameters["@Retorno"].Value;
                if (resultado == -1)
                    throw new Exception("El código ya se encuentra registrado");
                else if (resultado == -2)
                    throw new Exception("El nombre ya está asociado a un código");
                else if (resultado == -3)
                    throw new Exception("Ocurrió un error inesperado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { oConexion.Close(); }
            return resultado;
        }

        public static int ModificarCategoria(Categorias categoria)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("ModificarCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codCat", categoria.CodCat);
            oComando.Parameters.AddWithValue("@nomCat", categoria.NombreCat);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            int resultado = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                resultado = (int)oComando.Parameters["@Retorno"].Value;
                if (resultado == -1)
                    throw new Exception("El nombre ya está asociado a un código");
                else if (resultado == -2)
                    throw new Exception("Ocurrió un error inesperado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { oConexion.Close(); }
            return resultado;
        }

        public static Categorias BuscarCategoria(string codCat)
        {
            SqlDataReader oReader;
            Categorias oCategoria = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("BuscarCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codCat", codCat);
            
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        codCat = oReader["codigoCat"].ToString();
                        string nomCat = oReader["nombreCat"].ToString();

                        oCategoria = new Categorias(codCat, nomCat);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { oConexion.Close(); }
            return oCategoria;
        }

        public static Categorias BuscarCategoriaNombre(string nomCat)
        {
            SqlDataReader oReader;
            Categorias oCategoria = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("BuscarCategoriaNombre", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomCat", nomCat);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nomCat = oReader["nombreCat"].ToString();
                        string codCat = oReader["codigoCat"].ToString();

                        oCategoria = new Categorias(codCat, nomCat);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { oConexion.Close(); }
            return oCategoria;
        }

        public static int EliminarCategoria(Categorias categoria)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("@EliminarCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@codCat", categoria.CodCat);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            int resultado = 0;
            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                resultado = (int)oComando.Parameters["@Retorno"].Value;
                if (resultado == -1)
                    throw new Exception("La categoría tiene preguntas asociadas  - no puede eliminarse");
                else if (resultado == -2)
                    throw new Exception("Ocurrió un error inesperado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { oConexion.Close(); }
            return resultado;
        }
    }
}
