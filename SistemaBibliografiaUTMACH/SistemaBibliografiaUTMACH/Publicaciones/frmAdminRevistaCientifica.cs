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

namespace SistemaBibliografiaUTMACH.Publicaciones
{
    public partial class frmAdminRevistaCientifica : Form
    {
        public frmAdminRevistaCientifica()
        {
            InitializeComponent();
            cargarDatos();
        }
        private RevistaCientificaLN revLN = new RevistaCientificaLN();
        private void cargarDatos()
        {
            dataGridView1.DataSource = revLN.ViewRevistaCientifica();
        }
        private void filtrarLista()
        {
            if (textBox1.Text == "Introducir un dato para aplicar un filtro a la lista.")
            {
                lbinfo.ForeColor = Color.Black;
                lbinfo.Text = "...";
            }
            else
            {
                dataGridView1.DataSource = revLN.ViewRevistaCientificaFiltro(textBox1.Text);
                if (dataGridView1.Rows.Count == 0)
                {
                    lbinfo.ForeColor = Color.Red;
                    lbinfo.Text = "No se ha encontrado ningún dato para filtrar la lista :(";
                }
                else if (textBox1.Text != "")
                {
                    lbinfo.ForeColor = Color.Green;
                    lbinfo.Text = "Se ha aplicado filtro de búsqueda a la lista!";
                }
            }
        }

        public void modifyRevistaCientifica()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditRevistaCientifica frm = new frmEditRevistaCientifica();
                    frm.Text = "Actualizar";
                    frm.opc = 1;
                    frm.label1.Text = "Actualizar Revista Cientifica";
                    RevistaCientifica oip = dataGridView1.CurrentRow.DataBoundItem as RevistaCientifica;
                    frm.showData(oip);
                    frm.value = oip.Id_revista.ToString();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        RevistaCientifica op = frm.createObject();
                        revLN.UpdateRevistaCientifica(op);
                        frm.Close();
                        lbinfo.ForeColor = Color.Green;
                        lbinfo.Text = "Modificación realizada con exito!";
                    }
                    else
                    {
                        frm.Close();
                        lbinfo.ForeColor = Color.Red;
                        lbinfo.Text = "Modificación cancelada...";
                    }
                }
                cargarDatos();
            }
            catch (Exception ex)
            {
                lbinfo.ForeColor = Color.Red;
                lbinfo.Text = "Error al modificar: " + ex.Message;
            }
        }
        public void addNewRevistaCientifica()
        {
            try
            {
                frmEditRevistaCientifica frm = new frmEditRevistaCientifica();
                frm.Text = "Insertar Datos";
                frm.label1.Text = "Añadir Revista Cientifica";
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    RevistaCientifica op = frm.createObject();
                    revLN.CreateRevistaCientifica(op);
                    frm.Close();
                    lbinfo.ForeColor = Color.Green;
                    lbinfo.Text = "Se ha añadido un Revista Cientifica correctamente!";
                }
                else
                {
                    frm.Close();
                    lbinfo.ForeColor = Color.Red;
                    lbinfo.Text = "La operación de añadir ha sido cancelada...";
                }
                cargarDatos();
            }
            catch (Exception ex)
            {
                lbinfo.ForeColor = Color.Red;
                lbinfo.Text = "Error al añadir Revista Cientifica: " + ex.Message;
            }
        }
        public void deleteRevistaCientifica()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Esta seguro de realizar esta acción?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        RevistaCientifica op = dataGridView1.CurrentRow.DataBoundItem as RevistaCientifica;
                        revLN.DeleteRevistaCientifica(op);
                        lbinfo.ForeColor = Color.Green;
                        lbinfo.Text = "El Revista Cientifica se ha eliminado con exito!";
                    }
                    else
                    {
                        lbinfo.ForeColor = Color.Red;
                        lbinfo.Text = "Se ha cancelado la eliminación del artículo ";
                    }
                }
                cargarDatos();
            }
            catch (Exception ex)
            {
                lbinfo.ForeColor = Color.Red;
                lbinfo.Text = "Se ha encontrado una falla al momento de intentar eliminar el Revista Cientifica: " + ex.Message;
            }
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Introducir un dato para aplicar un filtro a la lista.")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Introducir un dato para aplicar un filtro a la lista.";
                textBox1.ForeColor = Color.LightGray;
                this.ActiveControl = null; // Quitar el foco del TextBox
            }
        }
        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
            addNewRevistaCientifica();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            modifyRevistaCientifica();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            deleteRevistaCientifica();
        }

    }
}
