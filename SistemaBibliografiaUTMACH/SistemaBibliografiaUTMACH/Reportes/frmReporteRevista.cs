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
    public partial class frmReporteRevista : Form
    {
        public frmReporteRevista()
        {
            InitializeComponent();
        }

        DSReportesRevista ds = new DSReportesRevista();
        RevistaCientificaLN opln = new RevistaCientificaLN();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                List<RevistaCientifica> art = opln.ViewRevistaCientifica();
                foreach (RevistaCientifica a in art)
                {
                    ds.RevistaCientifica.AddRevistaCientificaRow((int)a.Id_revista, a.Nombre, a.Editor, (DateTime)a.Añopublicacion, a.Frecuencia, a.Temas, (int)a.Numero, (DateTime)a.AñopublicacionActual, (decimal)a.Costo);
                }
                CR_Revista rpt = new CR_Revista();
                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar crear reporte de Revista Cientifica");
            }
        }
    }
}
