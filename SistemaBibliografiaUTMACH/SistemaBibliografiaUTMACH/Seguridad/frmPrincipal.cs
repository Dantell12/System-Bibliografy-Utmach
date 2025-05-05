using CapaEntidades.Inventario;
using CapaEntidades.Investigacion;
using CapaEntidades.Publicaciones;
using CapaLogica.Inventario;
using CapaLogica.Investigacion;
using CapaLogica.Publicaciones;
using SistemaBibliografiaUTMACH.Inventario;
using SistemaBibliografiaUTMACH.Publicaciones;
using SistemaBibliografiaUTMACH.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBibliografiaUTMACH.Investigacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            panelSubmenuInvestigacion.Visible = false;
            panelSubmenupubli.Visible = false;
            panelSubmenuReportes.Visible = false;
        }
        private void hideSubmenu()
        {
            if(panelSubmenuInvestigacion.Visible == true) 
            {
                panelSubmenuInvestigacion.Visible = false;
                btnInvestigacion.BackColor = Color.FromArgb(42, 134, 191);
            }
            if (panelSubmenupubli.Visible == true)
            {
                panelSubmenupubli.Visible = false;
                btnPublicaciones.BackColor = Color.FromArgb(42, 134, 191);
            }
            if(panelSubmenuReportes.Visible == true)
            {
                panelSubmenuReportes.Visible=false;
                btnReportes.BackColor = Color.FromArgb(42, 134, 191);
            }
        }
        private void showPanelSubmenu(Panel Submenu, Button btn)
        {
            if (Submenu.Visible == false)
            {
                hideSubmenu();
                Submenu.Visible = true;
                btn.BackColor = Color.FromArgb(25, 64, 115);
            }
            else
            {
                Submenu.Visible = false;
                btn.BackColor = Color.FromArgb(42, 134, 191);
            }
            }

            private void frmPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        private void btnInvestigacion_Click(object sender, EventArgs e)
        {
            showPanelSubmenu(panelSubmenuInvestigacion, btnInvestigacion);
        }

        private void btnPublicaciones_Click(object sender, EventArgs e)
        {
            showPanelSubmenu(panelSubmenupubli, btnPublicaciones);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            showPanelSubmenu(panelSubmenuReportes, btnReportes);
        }

        public void AbrirFormulario(Form formulario)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            formulario.MdiParent = this;
            formulario.FormClosed += (sender, e) =>
            {
            
                formulario.Dispose();
            };
            formulario.Show();
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAdminArticulo());
        }

        private void btnInvestigadores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAdminInvestigador());
        }

        private void btnRevistas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAdminRevistaCientifica());
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAdminInformeTecnico());

        }

        private void btnActasCongreso_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAdminActaCongreso());

        }

        private void btnReporteArticulo_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReporteArticulo());
        }

        private void btnReporteInforme_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportesInforme());
        }

        private void btnReporteRevista_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReporteRevista());
        }

        private void btnReporteActa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReporteActa()); 
        }

        private void btnReporteInvestigador_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReporteInvestigador());
        }
    }
}
