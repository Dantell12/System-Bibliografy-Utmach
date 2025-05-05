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
    public partial class frmAdminInformeTecnico : Form
    {
        public frmAdminInformeTecnico()
        {
            InitializeComponent();
            cargarDatos();
        }

        private InformeTecnicoLN actLN = new InformeTecnicoLN();
        private void cargarDatos()
        {
            dataGridView1.DataSource = actLN.ViewInformeTecnico();
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
                dataGridView1.DataSource = actLN.ViewInformeTecnicoFiltro(textBox1.Text);
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

        public void modifyInformeTecnico()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditInformeTecnico frm = new frmEditInformeTecnico();
                    frm.Text = "Actualizar";
                    frm.opc = 1;
                    frm.label1.Text = "Actualizar Informe Tecnico";
                    InformeTecnico oip = dataGridView1.CurrentRow.DataBoundItem as InformeTecnico;
                    frm.showData(oip);
                    frm.value = oip.Id_Informe.ToString();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        InformeTecnico op = frm.createObject();
                        actLN.UpdateInformeTecnico(op);
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
        public void addNewInformeTecnico()
        {
            try
            {
                frmEditInformeTecnico frm = new frmEditInformeTecnico();
                frm.Text = "Insertar Datos";
                frm.label1.Text = "Añadir Informe Técnico";
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    InformeTecnico op = frm.createObject();
                    actLN.CreateInformeTecnico(op);
                    frm.Close();
                    lbinfo.ForeColor = Color.Green;
                    lbinfo.Text = "Se ha añadido un informe técnico correctamente!";
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
                lbinfo.Text = "Error al añadir: " + ex.Message;
            }
        }
        public void deleteInformeTecnico()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Esta seguro de realizar esta acción?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        InformeTecnico op = dataGridView1.CurrentRow.DataBoundItem as InformeTecnico;
                        actLN.DeleteInformeTecnico(op);
                        lbinfo.ForeColor = Color.Green;
                        lbinfo.Text = "El informe técnico se ha eliminado con exito!";
                    }
                    else
                    {
                        lbinfo.ForeColor = Color.Red;
                        lbinfo.Text = "Se ha cancelado la eliminación del informe técnico ";
                    }
                }
                cargarDatos();
            }
            catch (Exception ex)
            {
                lbinfo.ForeColor = Color.Red;
                lbinfo.Text = "Se ha encontrado una falla al momento de intentar eliminar el informe técnico: " + ex.Message;
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
            addNewInformeTecnico();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            modifyInformeTecnico();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            deleteInformeTecnico();
        }
    }
}
