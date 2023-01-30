using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencias;

namespace Logica
{
    public class LogicaJuegos
    {
        public static Juegos BuscarJuego(int codJuego)
        {
            return PersistenciasJuegos.BuscarJuego(codJuego);
        }

        public static int AgregarJuego(string nomJuego, string dificultad)
        {
            return PersistenciasJuegos.AgregarJuego(nomJuego, dificultad);
        }

        public static List<Juegos> ListarJuegosPreguntas()
        {
            return PersistenciasJuegos.ListarJuegosPreguntas();
        }

        public static List<Juegos> ListarJuegos()
        {
            return PersistenciasJuegos.ListarJuegos();
        }

        public static int AgregarPreguntaJuego(Pregunta pregunta, Juegos juego)
        {
            return PersistenciasJuegos.AgregarPreguntaJuego(pregunta, juego);
        }

        public static int ModificarJuego(Juegos juego)
        {
            return PersistenciasJuegos.ModificarJuego(juego);
        }

        public static int QuitarPregunta(Juegos juego, Pregunta pregunta)
        {
            return PersistenciasJuegos.QuitarPregunta(juego, pregunta);
        }
    }
}
