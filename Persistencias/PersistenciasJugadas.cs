using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencias
{
    public class PersistenciasJugadas
    {
        public static int AgregarJugada(string player, Juegos juego, int puntaje)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("AgregarJugada", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nombreJugador", player);
            oComando.Parameters.AddWithValue("@CodJuego", juego.CodigoJuego);
            oComando.Parameters.AddWithValue("@puntaje", puntaje);

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
                    throw new Exception("Ocurrió un error inesperado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { oConexion.Close(); }
            return resultado;
        }

        public static List<Jugadas> ListarJugadas()
        {
            SqlDataReader oReader;
            List<Jugadas> records = new List<Jugadas>();
            Jugadas jugada;
            string player;
            int numJugada, puntajeTotal;
            DateTime fechaHoraJugada;
            Juegos juego;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand oComando = new SqlCommand("ListarJugadas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        numJugada = (int)oReader["numeroJugada"];
                        puntajeTotal = (int)oReader["puntajeTotal"];
                        int aux = (int)oReader["codigoJuego"];
                        juego = PersistenciasJuegos.BuscarJuego(aux);
                        player = oReader["nombreJugador"].ToString();
                        fechaHoraJugada = (DateTime)oReader["fechaHoraJugada"];

                        jugada = new Jugadas(numJugada, player, fechaHoraJugada, puntajeTotal, juego);
                        records.Add(jugada);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { oConexion.Close(); }
            return records;
        }
    }
}
