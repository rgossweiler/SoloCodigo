using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencias;

namespace Logica
{
    public class LogicaCategorias
    {
        public static int AgregarCategoria(Categorias categoria)
        {
            return PersistenciasCategorias.AgregarCategoria(categoria);
        }

        public static int ModificarCategoria(Categorias categoria)
        {
            return PersistenciasCategorias.ModificarCategoria(categoria);
        }

        public static Categorias BuscarCategoria(string codCat)
        {
            return PersistenciasCategorias.BuscarCategoria(codCat);
        }

        public static Categorias BuscarCategoriaNombre(string nomCat)
        {
            return PersistenciasCategorias.BuscarCategoriaNombre(nomCat);
        }

        public static int EliminarCategoria(Categorias categoria)
        {
            return PersistenciasCategorias.EliminarCategoria(categoria);
        }
    }
}
