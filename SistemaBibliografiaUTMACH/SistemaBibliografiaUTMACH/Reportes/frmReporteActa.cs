using CapaEntidades.Publicaciones;
using CapaLogica.Publicaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBibliografiaUTMACH.Reportes
{
    public partial class frmReporteActa : Form
    {
        public frmReporteActa()
        {
            InitializeComponent();
        }
        DSReporteActa ds = new DSReporteActa();
        ActaCongresoLN opln = new ActaCongresoLN();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                List<ActaCongreso> art = opln.ViewActaCongreso();
                foreach (ActaCongreso a in art)
                {
                    ds.ActaCongreso.AddActaCongresoRow(a.Id_ActaCongreso, a.NombreCongreso, a.Edicion, a.CiudadCelebracion, a.Fechainicio, a.Fechafinalizacion, a.TipoCongreso1, a.Pais, a.Añoprimera, a.Frecuencia);
                }
                CR_Acta rpt = new CR_Acta();
                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar crear reporte de Acta Congreso");
            }
        }
    }
}
