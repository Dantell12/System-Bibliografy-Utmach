using CapaDatos.Publicaciones;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InformeArticulo = CapaEntidades.Publicaciones.InformeArticulo;


namespace CapaLogica.Publicaciones
{
    public class InformeArticuloLN
    {
        public List<InformeArticulo> ViewInformeArticulo()
        {
            List<InformeArticulo> ListaInformeArticulo = new List<InformeArticulo>();
            InformeArticulo obp = null;
            try
            {
                List<CP_ListarInformeArticuloResult> auxLista = InformeArticuloCD.ListarInformeArticulo();
                foreach (CP_ListarInformeArticuloResult op in auxLista)
                {
                    obp = new InformeArticulo(op.id_informe, op.id_articulo);
                    ListaInformeArticulo.Add(obp);
                }
                return ListaInformeArticulo;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al logica Informe articulo");
            }
        }
        public List<InformeArticulo> ViewV2InformeesArticulos()
        {
            List<InformeArticulo> list = new List<InformeArticulo>();
            InformeArticulo obp = null;
            try
            {
                List<CP_ListarV2InformeArticuloResult> auxLista = InformeArticuloCD.ListInformeArticulosV2();
                foreach (CP_ListarV2InformeArticuloResult op in auxLista)
                {
                    obp = new InformeArticulo();
                    obp.Idinforme = op.id_informe;
                    obp.Idarticulo = op.id_articulo;
                    obp.Titulo = op.Titulo;
                    obp.Numeroinforme = op.Numero;
                    obp.Centropublicacion = op.CentroPublicacion;
                    list.Add(obp);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al logica Informe articulo");
            }
        }


        //insertar -> capaLogica
        public bool CreateInformeArticulo(InformeArticulo op)
        {
            try
            {
                InformeArticuloCD.InsertarInformeArticulo(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear Informe articulo", ex);
            }
        }
        //actualizar -> capaLogica
        public bool UpdateInformeArticulo(InformeArticulo op, int auxinf)
        {
            try
            {
                InformeArticuloCD.ModificarInformeArticulo(op, auxinf);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar Informe articulo", ex);
            }
        }
        //eliminar -> capaLogica
        public bool DeleteInformeArticulo(InformeArticulo op)
        {
            try
            {
                InformeArticuloCD.EliminarInformeArticulo(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar Informe articulo", ex);
            }
        }
    }
}
