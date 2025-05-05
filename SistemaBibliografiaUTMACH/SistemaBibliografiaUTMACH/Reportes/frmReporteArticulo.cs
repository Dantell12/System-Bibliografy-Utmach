using CapaEntidades.Inventario;
using CapaLogica.Inventario;
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
    public partial class frmReporteArticulo : Form
    {
        public frmReporteArticulo()
        {
            InitializeComponent();
        }
        DSReportesArticulo ds = new DSReportesArticulo();
        ArticuloLN opln = new ArticuloLN();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> art = opln.ViewArticulo();
                foreach (Articulo a in art)
                {
                    ds.Articulo.AddArticuloRow(a.IdArticulo, a.Titulo, a.Palabrasclave, a.Contacto);
                }
                CR_Articulo rpt = new CR_Articulo();
                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar crear reporte de Articulo");
            }
        }
    }
}
