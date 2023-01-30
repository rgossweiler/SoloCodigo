using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuarios
    {
        //ATRIBUTOS
        private string nomUsuario;
        private string contraseña;
        private string nombreCompleto;

        //PROPIEDADES
        public string NomUsuario
        {
            get { return nomUsuario; }
            set 
            {
                if (value.Trim() == "")
                    throw new Exception("el nombre de usuario no puede quedar vacío ");
                nomUsuario = value;
            }
        }

        public string Contraseña
        {
            get { return contraseña; }
            set 
            {
                if (value.Trim() == "")
                    throw new Exception("La contraseña del usuario no puede quedar vacía");
                contraseña = value;
            }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set 
            {
                if (value.Trim() == "")
                    throw new Exception("el nombre completo del usuario no puede quedar vacío");
                nombreCompleto = value;
            }
        }

        //CONSTRUCTOR
        public Usuarios(string pNomUsuario, string pContraseña, string pNombreCompleto)
        {
            NombreCompleto = pNombreCompleto;
            Contraseña = pContraseña;
            NomUsuario = pNomUsuario;
        }

        //OPERACIONES

    }
}
