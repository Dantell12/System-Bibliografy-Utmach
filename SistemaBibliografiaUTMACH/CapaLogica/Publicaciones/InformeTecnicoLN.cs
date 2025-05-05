using CapaDatos.Publicaciones;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InformeTecnico = CapaEntidades.Publicaciones.InformeTecnico;
using CapaDatos.Inventario;

namespace CapaLogica.Publicaciones
{
    public class InformeTecnicoLN
    {
        public List<InformeTecnico> ViewInformeTecnico()
        {
            List<InformeTecnico> ListaInformeTecnico = new List<InformeTecnico>();
            InformeTecnico obp = null;
            try
            {
                List<CP_ListarInformeTecnicoResult> auxLista = InformeTecnicoCD.ListarInformeTecnico();
                foreach (CP_ListarInformeTecnicoResult op in auxLista)
                {
                    obp = new InformeTecnico(op.id_informe, op.Numero, op.CentroPublicacion, op.MesPublicacion, op.AñoPublicacion);
                    ListaInformeTecnico.Add(obp);
                }
                return ListaInformeTecnico;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error en la logica InformeTecnico");
            }
        }
        public List<InformeTecnico> ViewInformeTecnicoFiltro(string valor)
        {
            List<InformeTecnico> ListaInformeTecnico = new List<InformeTecnico>();
            InformeTecnico obp = null;
            try
            {
                List<CP_listarinformeTecnicoFiltroResult> auxLista = InformeTecnicoCD.ListarInformeTecnicoFiltro(valor);
                foreach (CP_listarinformeTecnicoFiltroResult op in auxLista)
                {
                    obp = new InformeTecnico(op.id_informe, op.Numero, op.CentroPublicacion, op.MesPublicacion, op.AñoPublicacion);
                    ListaInformeTecnico.Add(obp);
                }
                return ListaInformeTecnico;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error en al logica Informe Tecnico");
            }
        }

        //insertar -> capaLogica
        public bool CreateInformeTecnico(InformeTecnico op)
        {
            try
            {
                InformeTecnicoCD.InsertarInformeTecnico(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear Informe Tecnico", ex);
            }
        }
        //actualizar -> capaLogica
        public bool UpdateInformeTecnico(InformeTecnico op)
        {
            try
            {
                InformeTecnicoCD.ModificarInformeTecnico(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar Informe Tecnico", ex);
            }
        }
        //eliminar -> capaLogica
        public bool DeleteInformeTecnico(InformeTecnico op)
        {
            try
            {
                InformeTecnicoCD.EliminarInformeTecnico(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar Informe Tecnico", ex);
            }
        }
        public int createID()
        {
            int id = 0;
            int n = 1;
            List<CP_ListarInformeTecnicoResult> auxLista = InformeTecnicoCD.ListarInformeTecnico();
            foreach (CP_ListarInformeTecnicoResult op in auxLista)
            {
                if (op.id_informe == n)
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
