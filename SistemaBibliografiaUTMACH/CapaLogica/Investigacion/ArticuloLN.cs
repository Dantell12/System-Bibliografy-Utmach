using CapaDatos;
using CapaDatos.Inventario;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Articulo = CapaEntidades.Inventario.Articulo;

namespace CapaLogica.Inventario
{
    public class ArticuloLN
    {
        public List<Articulo> ViewArticulo()
        {
            List<Articulo> ListaArticulo = new List<Articulo>();
            Articulo obp = null;
            try
            {
                List<CP_ListarArticuloResult> auxLista = ArticuloCD.ListarArticulo();
                foreach(CP_ListarArticuloResult op in  auxLista) 
                {
                    obp = new Articulo(op.id_articulo, op.Titulo, op.PalabrasClave, op.Contactos);
                    ListaArticulo.Add(obp);
                }
                return ListaArticulo;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al logica articulo");
            }
        }
        public List<Articulo> ViewArticuloFiltro(string valor)
        {
            List<Articulo> ListaArticulo = new List<Articulo>();
            Articulo obp = null;
            try
            {
                List<CP_listararticulosFiltroResult> auxLista = ArticuloCD.ListarArticuloFiltro(valor);
                foreach (CP_listararticulosFiltroResult op in auxLista)
                {
                    obp = new Articulo(op.id_articulo, op.Titulo, op.PalabrasClave, op.Contactos);
                    ListaArticulo.Add(obp);
                }
                return ListaArticulo;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al logica articulo");
            }
        }

        //insertar -> capaLogica
        public bool CreateArticulo(Articulo op)
        {
            try
            {
                ArticuloCD.InsertarArticulo(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear articulo", ex);
            }
        }
        //actualizar -> capaLogica
        public bool UpdateArticulo(Articulo op)
        {
            try
            {
                ArticuloCD.ModificarArticulo(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar articulo", ex);
            }
        }
        //eliminar -> capaLogica
        public bool DeleteArticulo(Articulo op)
        {
            try
            {
                ArticuloCD.EliminarArticulo(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar articulo", ex);
            }
        }
        public int createID()
        {
            int id = 0;
            int n = 1;
            List<CP_ListarArticuloResult> auxLista = ArticuloCD.ListarArticulo();
            foreach (CP_ListarArticuloResult op in auxLista)
            {
                if (op.id_articulo == n)
                {
                    n++; 
                }
                else
                {
                    id = n; 
                    break;
                }
            }

            if (id == 0)
            {
                id = n;
            }
            return id;
        }
    }
}
