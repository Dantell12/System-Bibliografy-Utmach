using CapaEntidades.Inventario;
using SistemaBibliografiaUTMACH.Publicaciones;
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
    public partial class frmOpcionPublicacion : Form
    {
        public frmOpcionPublicacion()
        {
            InitializeComponent();
        }
        public Articulo oip = null;
        private frmAdminArticulo frmArt = new frmAdminArticulo();
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void publicarActaCongreso()
        {
            try
            {
                frmPublicarActa frm = new frmPublicarActa();
                frm.Text = "Publicar Artículo en Acta de Congreso";
                frm.op = oip;
                frm.verDatos();
                frm.ShowDialog();
                this.Dispose();
                if (frm.DialogResult == DialogResult.OK)
                {
                    frm.Close();
                    frmArt.lbinfo.ForeColor = Color.Green;
                    frmArt.lbinfo.Text = "Publicación realizada correctamente!";
                }
                else
                {
                    frm.Close();
                    frmArt.lbinfo.ForeColor = Color.Red;
                    frmArt.lbinfo.Text = "Se ha cancelado la publicación";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha encontrado una falla en la publicación de Artículos Cientificos: " + ex.Message);
            }
        }

        public void publicarInformeTecnico()
        {
            try
            {
                frmPublicarInforme frm = new frmPublicarInforme();
                frm.Text = "Publicar Artículo en Informe Técnico";
                frm.op = oip;
                frm.verDatos();
                frm.ShowDialog();
                this.Dispose();
                if (frm.DialogResult == DialogResult.OK)
                {
                    frm.Close();
                    frmArt.lbinfo.ForeColor = Color.Green;
                    frmArt.lbinfo.Text = "Publicación realizada correctamente!";
                }
                else
                {
                    frm.Close();
                    frmArt.lbinfo.ForeColor = Color.Red;
                    frmArt.lbinfo.Text = "Se ha cancelado la publicación";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha encontrado una falla en la publicación de Artículos Cientificos: " + ex.Message);
            }
        }
        public void publicarRevistaCientifica()
        {
            try
            {
                frmPublicarRevista frm = new frmPublicarRevista();
                frm.Text = "Publicar Artículo en Revista Cientifica";
                frm.op = oip;
                frm.verDatos();
                frm.ShowDialog();
                this.Dispose();
                if (frm.DialogResult == DialogResult.OK)
                {
                    frm.Close();
                    frmArt.lbinfo.ForeColor = Color.Green;
                    frmArt.lbinfo.Text = "Publicación realizada correctamente!";
                }
                else
                {
                    frm.Close();
                    frmArt.lbinfo.ForeColor = Color.Red;
                    frmArt.lbinfo.Text = "Se ha cancelado la publicación";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha encontrado una falla en la publicación de Artículos Cientificos: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            publicarActaCongreso();

        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            publicarInformeTecnico();
        }

        private void btnRevista_Click(object sender, EventArgs e)
        {
            publicarRevistaCientifica();
        }
    }
}
