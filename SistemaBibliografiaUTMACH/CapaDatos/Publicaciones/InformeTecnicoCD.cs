using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Publicaciones
{
    public class InformeTecnicoCD
    {
        public static List<CP_ListarInformeTecnicoResult> ListarInformeTecnico()
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_ListarInformeTecnico().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar InformeTecnico", ex);
            }
            finally
            {
                DB = null;
            }
        }
        //Filtro
        public static List<CP_listarinformeTecnicoFiltroResult> ListarInformeTecnicoFiltro(string valor)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    return DB.CP_listarinformeTecnicoFiltro(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar la lista de Informe Tecnico", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Insertar
        public static void InsertarInformeTecnico(CapaEntidades.Publicaciones.InformeTecnico op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_InsertarInformeTecnico(op.Id_Informe, op.Numero, op.Centropublicacion, op.Mespublicacion, op.Añopublicacion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar insertar InformeTecnico", ex);
            }
            finally
            {
                DB = null;
            }
        }



        //modificar
        public static void ModificarInformeTecnico(CapaEntidades.Publicaciones.InformeTecnico op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_ActualizarInformeTecnico(op.Id_Informe, op.Numero, op.Centropublicacion, op.Mespublicacion, op.Añopublicacion);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Informe Tecnico", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //Eliminar
        public static void EliminarInformeTecnico(CapaEntidades.Publicaciones.InformeTecnico op)
        {
            BDutmachBibliografiaDataContext DB = null;
            try
            {
                using (DB = new BDutmachBibliografiaDataContext())
                {
                    DB.CP_EliminarInformeTecnico(op.Id_Informe);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Informe Tecnico", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
