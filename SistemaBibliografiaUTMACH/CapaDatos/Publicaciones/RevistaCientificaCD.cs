using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Publicaciones
{
    public class RevistaCientificaCD
    {
        public static List<CP_ListarRevistaCientificaResult> ListarRevistaCientifica()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarRevistaCientifica().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Revista Cientifica", ex);
            }
            finally
            {
                DB = null;
            }
        }
        //Filtro
        public static List<CP_listarRevistaCientificaFiltroResult> ListarRevistaCientificaFiltro(string valor)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_listarRevistaCientificaFiltro(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar la lista de Revista Cientifica", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Insertar
        public static void InsertarRevistaCientifica(CapaEntidades.Publicaciones.RevistaCientifica op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_InsertarRevistaCientifica(op.Id_revista,op.Nombre, op.Editor, op.Añopublicacion, op.Frecuencia, op.Temas, op.Numero, op.AñopublicacionActual, op.Costo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar insertar Revissta Cientifica", ex);
            }
            finally
            {
                DB = null;
            }
        }



        //modificar
        public static void ModificarRevistaCientifica(CapaEntidades.Publicaciones.RevistaCientifica op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_ActualizarRevistaCientifica(op.Id_revista, op.Nombre, op.Editor, op.Añopublicacion, op.Frecuencia, op.Temas, op.Numero, op.AñopublicacionActual, op.Costo);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Revista Cientifica", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Eliminar
        public static void EliminarRevisstaCientifica(CapaEntidades.Publicaciones.RevistaCientifica op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_EliminarRevistaCientifica(op.Id_revista);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Revista Cientifica", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
