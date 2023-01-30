using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencias;

namespace Logica
{
    public class LogicaJugadas
    {
        public static int AgregarJugada(string player, Juegos juego, int puntaje)
        {
            return PersistenciasJugadas.AgregarJugada(player, juego, puntaje);
        }

        public static List<Jugadas> ListarJugadas()
        {
            return PersistenciasJugadas.ListarJugadas();
        }
    }
}
