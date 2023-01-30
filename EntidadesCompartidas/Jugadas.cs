using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Jugadas
    {
        //ATRIBUTOS
        private int numJugada;
        private string nombreJugador;
        private DateTime fechaHoraJugada;
        private int puntajeTotal;
        private Juegos juego;

        //PROPIEDADES
        public int NumJugada
        {
            get { return numJugada; }
            set { numJugada = value; }
        }

        public string NombreJugador
        {
            get { return nombreJugador; }
            set 
            {
                if (value == "")
                    throw new Exception("El nombre de jugador no puede quedar vacío");
                nombreJugador = value;
            }
        }

        public DateTime FechaHoraJugada
        {
            get { return fechaHoraJugada; }
            set
            {
                if (value < DateTime.Now)
                    throw new Exception("La fecha no puede ser anterior al dia de hoy");
                else
                    fechaHoraJugada = value;
            }
        }

        public int PuntajeTotal
        {
            get { return puntajeTotal; }
            set { puntajeTotal = value; }
        }

        public Juegos Juego
        {
            get { return juego; }
            set { juego = value; }
        }

        //CONSTRUCTOR
        public Jugadas(int pNumJugada, string pNombreJugador, DateTime pFechaHoraJugada, int pPuntajeTotal, Juegos pJuego)
        {
            NumJugada = pNumJugada;
            NombreJugador = pNombreJugador;
            FechaHoraJugada = pFechaHoraJugada;
            PuntajeTotal = pPuntajeTotal;
            Juego = pJuego;
        }

        //OPERACIONES
    }
}
