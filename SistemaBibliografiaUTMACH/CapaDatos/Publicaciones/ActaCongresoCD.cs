using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Publicaciones
{
    public class ActaCongresoCD
    {
        public static List<CP_ListarActaCongresoResult> ListarActaCongreso()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarActaCongreso().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Acta de Congreso", ex);
            }
            finally
            {
                DB = null;
            }
        }
        //Filtro
        public static List<CP_listaractaCongresoFiltroResult> ListarActaCongresoFiltro(string valor)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_listaractaCongresoFiltro(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar la lista de Actas de Congreso", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Insertar
        public static void InsertarActaCongreso(CapaEntidades.Publicaciones.ActaCongreso op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_InsertarActaCongreso(op.Id_ActaCongreso, op.NombreCongreso, op.Edicion, op.CiudadCelebracion, op.Fechainicio, op.Fechafinalizacion, op.TipoCongreso1, op.Pais, op.Añoprimera, op.Frecuencia);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar insertar ActaCongreso", ex);
            }
            finally
            {
                DB = null;
            }
        }



        //modificar
        public static void ModificarActaCongreso(CapaEntidades.Publicaciones.ActaCongreso op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_ActualizarActaCongreso(op.Id_ActaCongreso, op.NombreCongreso, op.Edicion, op.CiudadCelebracion, op.Fechainicio, op.Fechafinalizacion, op.TipoCongreso1, op.Pais, op.Añoprimera, op.Frecuencia);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar ActaCongreso", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Eliminar
        public static void EliminarActaCongreso(CapaEntidades.Publicaciones.ActaCongreso op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_EliminarActaCongreso(op.Id_ActaCongreso);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar ActaCongreso", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
