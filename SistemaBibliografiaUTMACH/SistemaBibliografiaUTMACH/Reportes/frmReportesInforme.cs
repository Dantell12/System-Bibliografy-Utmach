using CapaEntidades.Publicaciones;
using CapaLogica.Inventario;
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
    public partial class frmReportesInforme : Form
    {
        public frmReportesInforme()
        {
            InitializeComponent();
        }
        DSReporteInforme ds = new DSReporteInforme();
        InformeTecnicoLN opln = new InformeTecnicoLN();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                List<InformeTecnico> art = opln.ViewInformeTecnico();
                foreach (InformeTecnico a in art)
                {
                    ds.InformeTecnico.AddInformeTecnicoRow(a.Id_Informe, a.Numero, a.Centropublicacion, a.Mespublicacion, a.Añopublicacion);
                }
                CR_Informe rpt = new CR_Informe();
                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar crear reporte de Informe Técnico");
            }
        }
    }
}
