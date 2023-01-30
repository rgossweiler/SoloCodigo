using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Categorias
    {
        //ATRIBUTOS
        private string codCat;
        private string nombreCat;

        //PROPIEDADES
        public string CodCat
        {
            get { return codCat; }
            set
            {
                if (value == "")
                    throw new Exception("El código de Categoría no puede quedar vacío");
                if (value.Length != 4)
                    throw new Exception("El código de Categoría debe tener de 4 Letras");
                else
                    codCat = value;
            }
        }

        public string NombreCat
        {
            get { return nombreCat; }
            set 
            {
                if (value == "")
                    throw new Exception("El nombre de la Categoría no puede quedar vacío");
                nombreCat = value;
            }
        }

        //CONSTRUCTOR
        public Categorias(string pCodCat, string pNombreCat)
        {
            CodCat = pCodCat;
            NombreCat = pNombreCat;
        }

        //OPERACIONES
    }
}
