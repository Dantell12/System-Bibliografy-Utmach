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
    public partial class frmAdminActaCongreso : Form
    {
        public frmAdminActaCongreso()
        {
            InitializeComponent();
            cargarDatos();
        }
        private ActaCongresoLN actLN = new ActaCongresoLN();
        private void cargarDatos()
        {
            dataGridView1.DataSource = actLN.ViewActaCongreso();
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
                dataGridView1.DataSource = actLN.ViewActaCongresoFiltro(textBox1.Text);
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

        public void modifyActaCongreso()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditActaCongreso frm = new frmEditActaCongreso();
                    frm.Text = "Actualizar";
                    frm.opc = 1;
                    frm.label11.Text = "Actualizar Acta de Congreso";
                    ActaCongreso oip = dataGridView1.CurrentRow.DataBoundItem as ActaCongreso;
                    frm.showData(oip);
                    frm.value = oip.Id_ActaCongreso.ToString();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        ActaCongreso op = frm.createObject();
                        actLN.UpdateActaCongreso(op);
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
        public void addNewActaCongreso()
        {
            try
            {
                frmEditActaCongreso frm = new frmEditActaCongreso();
                frm.Text = "Insertar Datos";
                frm.label11.Text = "Añadir Acta de Congreso";
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    ActaCongreso op = frm.createObject();
                    actLN.CreateActaCongreso(op);
                    frm.Close();
                    lbinfo.ForeColor = Color.Green;
                    lbinfo.Text = "Se ha añadido un Acta de Congreso correctamente!";
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
                lbinfo.Text = "Error al añadir Acta de Congreso: " + ex.Message;
            }
        }
        public void deleteActaCongreso()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Esta seguro de realizar esta acción?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        ActaCongreso op = dataGridView1.CurrentRow.DataBoundItem as ActaCongreso;
                        actLN.DeleteActaCongreso(op);
                        lbinfo.ForeColor = Color.Green;
                        lbinfo.Text = "El Acta de Congreso se ha eliminado con exito!";
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
                lbinfo.Text = "Se ha encontrado una falla al momento de intentar eliminar el Acta de Congreso: " + ex.Message;
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
            addNewActaCongreso();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            modifyActaCongreso();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            deleteActaCongreso();
        }
    }
}
