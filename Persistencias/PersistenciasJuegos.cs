using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencias
{
    public class PersistenciasJuegos
    {
        public static Juegos BuscarJuego(int pCodJuego)
        {
            string nombreJuego;
            DateTime fechaCreado;
            string dificultad;
            Usuarios creador;
            List<Pregunta> preguntasJuego;
            Juegos pJuego = null;

            SqlDataReader oReader;
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("BuscarJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codJuego", pCodJuego);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nombreJuego = oReader["nombreJuego"].ToString();
                        pCodJuego = (int)oReader["codigoJuego"];
                        fechaCreado = (DateTime)oReader["fechaCreado"];
                        dificultad = oReader["dificultad"].ToString();
                        string aux = oReader["creador"].ToString();
                        creador = PersistenciasUsuarios.BuscarUsuario(aux);
                        preguntasJuego = PersistenciasPreguntas.ListarPreguntasJuego(pCodJuego);

                        pJuego = new Juegos(nombreJuego, pCodJuego, fechaCreado, dificultad, creador, preguntasJuego);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { oConexion.Close(); }
            return pJuego;
        }

        public static int AgregarJuego(string pNombreJuego, string pDificultad)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("AgregarJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomJuego", pNombreJuego);
            oComando.Parameters.AddWithValue("@dificultad", pDificultad);

            SqlParameter oRetorno = new SqlParameter("@retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            int resultado = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                if (resultado == -1)
                    throw new Exception("El nombre del juego ya se encuentra registrado");
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

        public static List<Juegos> ListarJuegosPreguntas()
        {
            SqlDataReader oReader;
            List<Juegos> JuegosConPreguntas = null;
            Juegos juegos = null;
            int codJuego;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("ListarJuegosPreguntas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codJuego = (int)oReader["codigoJuego"];
                        juegos = BuscarJuego(codJuego);
                        JuegosConPreguntas.Add(juegos);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { oConexion.Close(); }
            return JuegosConPreguntas;
        }

        public static List<Juegos> ListarJuegos()
        {
            SqlDataReader oReader;
            List<Juegos> juegos = new List<Juegos>();
            List<Pregunta> preguntas = new List<Pregunta>();
            string nomJuego, dificultad; 
            Usuarios creador;
            int codJuego;
            DateTime fechaCreado;
            Juegos juego = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("ListarJuegos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        nomJuego = oReader["nombreJuego"].ToString();
                        codJuego = (int)oReader["codigoJuego"];
                        fechaCreado = (DateTime)oReader["fechaCreado"];
                        dificultad = oReader["dificultad"].ToString();
                        string aux = oReader["creador"].ToString();
                        creador = PersistenciasUsuarios.BuscarUsuario(aux);
                        preguntas = PersistenciasPreguntas.ListarPreguntasJuego(codJuego);
                        juego = new Juegos(nomJuego, codJuego, fechaCreado, dificultad, creador, preguntas);
                        juegos.Add(juego);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { oConexion.Close(); }
            return juegos;
        }

        public static int AgregarPreguntaJuego(Pregunta pPreg, Juegos pJuego)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("AgregarPreguntaJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("codPreg", pPreg.CodPregunta);
            oComando.Parameters.AddWithValue("nomJuego", pJuego.NombreJuego);

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
                    throw new Exception("El juego al que quiere asociar la pregunta no existe");
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

        public static int ModificarJuego(Juegos pjuego)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("ModificarJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomJuego", pjuego.NombreJuego);
            oComando.Parameters.AddWithValue("@dificultad", pjuego.Dificultad);
            oComando.Parameters.AddWithValue("@codJuego", pjuego.CodigoJuego);

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
                    throw new Exception("El nombre del juego ya se encuentra asociado");
                else if (resultado == -2)
                    throw new Exception("El juego que quiere modificar no existe");
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

        public static int QuitarPregunta(Juegos pJuego, Pregunta pPreg)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("QuitarPregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomJuego", pJuego.NombreJuego);
            oComando.Parameters.AddWithValue("@codPre", pPreg.CodPregunta);

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
                    throw new Exception("El juego que quiere modificar no existe");
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
