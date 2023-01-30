using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Pregunta
    {
        //ATRIBUTOS
        private string preguntas;
        private string respuesta1;
        private string respuesta2;
        private string respuesta3;
        private int correcta;
        private string codPregunta;
        private int puntaje;
        private Categorias categoria;

        //PROPIEDADES
        public string Preguntas
        {
            get { return preguntas; }
            set 
            {
                if (value == "")
                    throw new Exception("La pregunta no puede quedar vacía ");
                if (value.Length > 200)
                    throw new Exception("Las preguntas no pueden tener más de 200 caracteres ");
                preguntas = value;
            }
        }

        public string Respuesta1
        {
            get { return respuesta1; }
            set 
            {
                if (value == "")
                    throw new Exception("La respuesta no puede quedar vacía");
                if (value.Length > 200)
                    throw new Exception("Las respuestas no pueden tener más de 200 caracteres");
                respuesta1 = value;
            }
        }

        public string Respuesta2
        {
            get { return respuesta2; }
            set
            {
                if (value == "")
                    throw new Exception("La respuesta no puede quedar vacía");
                if (value.Length > 200)
                    throw new Exception("Las respuestas no pueden tener más de 200 caracteres");
                respuesta2 = value;
            }
        }

        public string Respuesta3
        {
            get { return respuesta3; }
            set
            {
                if (value == "")
                    throw new Exception("La respuesta no puede quedar vacía");
                if (value.Length > 200)
                    throw new Exception("Las respuestas no pueden tener más de 200 caracteres");
                respuesta3 = value;
            }
        }

        public int Correcta
        {
            get { return correcta; }
            set
            {
                if (value < 1 && value > 3)
                    throw new Exception("La respuesta correcta debe de estar entre el 1 al 3");
                else
                    correcta = value;
            }
        }

        public string CodPregunta
        {
            get { return codPregunta; }
            set 
            {
                if (value == "")
                    throw new Exception("El código de la pregunta no puede quedar vacío");
                if (value.Length != 5)
                    throw new Exception("El código de cada pregunta debe de ser de 5 caracteres ");
                else
                    codPregunta = value;
            }
        }

        public int Puntaje
        {
            get { return puntaje; }
            set
            {
                if (value < 1 && value > 10)
                    throw new Exception("El puntaje debe de ser del 1 al 10");
                else
                    puntaje = value;
            }
        }

        public Categorias Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        //CONSTRUCTOR
        public Pregunta(string pPreguntas, string pRespuesta1, string pRespuesta2, string pRespuesta3, int pCorrecta, string pCodPregunta, int pPuntaje, Categorias pCategoria)
        {
            Preguntas = pPreguntas;
            Respuesta1 = pRespuesta1;
            Respuesta2 = pRespuesta2;
            Respuesta3 = pRespuesta3;
            Correcta = pCorrecta;
            CodPregunta = pCodPregunta;
            Puntaje = pPuntaje;
            Categoria = pCategoria;
        }

        //OPERACIONES
    }
}
