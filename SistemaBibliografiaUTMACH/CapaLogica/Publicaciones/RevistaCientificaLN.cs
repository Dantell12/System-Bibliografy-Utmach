using CapaDatos.Investigacion;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevistaCientifica = CapaEntidades.Publicaciones.RevistaCientifica;
using CapaDatos.Publicaciones;
using CapaDatos.Inventario;

namespace CapaLogica.Publicaciones
{
    public class RevistaCientificaLN
    {
        public List<RevistaCientifica> ViewRevistaCientifica()
        {
            List<RevistaCientifica> ListaRevistaCientifica = new List<RevistaCientifica>();
            RevistaCientifica obp = null;
            try
            {
                List<CP_ListarRevistaCientificaResult> auxLista = RevistaCientificaCD.ListarRevistaCientifica();
                foreach (CP_ListarRevistaCientificaResult op in auxLista)
                {
                    obp = new RevistaCientifica(op.id_revista, op.Nombre, op.Editor, (DateTime)op.AnioInicioPublicacion, op.Frecuencia, op.Temas,(int)op.Numero, (DateTime)op.AnioPublicacionActual, (decimal)op.Costo);
                    ListaRevistaCientifica.Add(obp);
                }
                return ListaRevistaCientifica;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error en la logica RevistaCientifica");
            }
        }
        public List<RevistaCientifica> ViewRevistaCientificaFiltro(string valor)
        {
            List<RevistaCientifica> ListaRevistaCientifica = new List<RevistaCientifica>();
            RevistaCientifica obp = null;
            try
            {
                List<CP_listarRevistaCientificaFiltroResult> auxLista = RevistaCientificaCD.ListarRevistaCientificaFiltro(valor);
                foreach (CP_listarRevistaCientificaFiltroResult op in auxLista)
                {
                    obp = new RevistaCientifica(op.id_revista, op.Nombre, op.Editor, (DateTime)op.AnioInicioPublicacion, op.Frecuencia, op.Temas, (int)op.Numero, (DateTime)op.AnioPublicacionActual, (decimal)op.Costo);
                    ListaRevistaCientifica.Add(obp);
                }
                return ListaRevistaCientifica;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error en la logica Revista Cientifica");
            }
        }

        //insertar -> capaLogica
        public bool CreateRevistaCientifica(RevistaCientifica op)
        {
            try
            {
                RevistaCientificaCD.InsertarRevistaCientifica(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear Revista Cientifica", ex);
            }
        }
        //actualizar -> capaLogica
        public bool UpdateRevistaCientifica(RevistaCientifica op)
        {
            try
            {
                RevistaCientificaCD.ModificarRevistaCientifica(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar Revista Cientifica", ex);
            }
        }
        //eliminar -> capaLogica
        public bool DeleteRevistaCientifica(RevistaCientifica op)
        {
            try
            {
                RevistaCientificaCD.EliminarRevisstaCientifica(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar Revista Cientifica", ex);
            }
        }
        public int createID()
        {
            int id = 0;
            int n = 1;
            List<CP_ListarRevistaCientificaResult> auxLista = RevistaCientificaCD.ListarRevistaCientifica();
            foreach (CP_ListarRevistaCientificaResult op in auxLista)
            {
                if (op.id_revista == n)
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
