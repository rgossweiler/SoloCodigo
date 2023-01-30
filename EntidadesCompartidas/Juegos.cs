using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Juegos
    {
        //ATRIBUTOS
        private string nombreJuego;
        private int codigoJuego;
        private DateTime fechaCreado;
        private string dificultad;
        private Usuarios creador;
        private List<Pregunta> preguntasJuego;

        //PROPIEDADES
        public string NombreJuego
        {
            get { return nombreJuego; }
            set 
            {
                if (value == "")
                    throw new Exception("El nombre del juego no puede quedar vacío");
                nombreJuego = value;
            }
        }

        public int CodigoJuego
        {
            get { return codigoJuego; }
            set { codigoJuego = value; }
        }

        public DateTime FechaCreado
        {
            get { return fechaCreado; }
            set 
            {
                if (fechaCreado > DateTime.Now)
                    throw new Exception("La fecha de creado el juego no puede ser posterior a la fecha actual");
                fechaCreado = value;
            }
        }

        public string Dificultad
        {
            get { return dificultad; }
            set 
            {
                if (value != "Facil" || value != "Medio" || value != "Dificil")
                    throw new Exception("La dificultad debe ser entre Fácil, Medio o Difícil ");
                dificultad = value;
            }
        }

        public Usuarios Creador
        {
            get { return creador; }
            set { creador = value; }
        }

        public List<Pregunta> PreguntasJuego
        {
            get { return preguntasJuego; }
            set { preguntasJuego = value; }
        }

        //CONSTRUCTOR
        public Juegos(string pNombreJuego, int pCodigoJuego, DateTime pFechaCreado, string pDificultad, Usuarios pCreador, List<Pregunta> pPreguntasJuego)
        {
            NombreJuego = pNombreJuego;
            CodigoJuego = pCodigoJuego;
            FechaCreado = pFechaCreado;
            Dificultad = pDificultad;
            Creador = pCreador;
            PreguntasJuego = pPreguntasJuego;
        }

        //OPERACIONES

    }
}
