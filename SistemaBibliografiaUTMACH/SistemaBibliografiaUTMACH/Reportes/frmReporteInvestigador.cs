using CapaEntidades.Investigacion;
using CapaLogica.Investigacion;
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
    public partial class frmReporteInvestigador : Form
    {
        public frmReporteInvestigador()
        {
            InitializeComponent();
        }

        DSReportesInvestigador ds = new DSReportesInvestigador();
        InvestigadorLN opln = new InvestigadorLN();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                List<Investigador> art = opln.ViewInvestigador();
                foreach (Investigador a in art)
                {
                    ds.Investigador.AddInvestigadorRow(a.Id_investigador, a.Nombre, a.Centrotrabajo, a.Correo, a.Temas);
                }
                CR_Investigador rpt = new CR_Investigador();
                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar crear reporte de Investigador");
            }
        }
    }
}
