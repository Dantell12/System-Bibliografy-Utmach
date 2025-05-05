using CapaEntidades.Investigacion;
using CapaLogica.Investigacion;
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
    public partial class frmAdminInvestigador : Form
    {
        public frmAdminInvestigador()
        {
            InitializeComponent();
            cargarDatos();
        }
        InvestigadorLN invtLN = new InvestigadorLN();
        private void cargarDatos()
        {
            dataGridView1.DataSource = invtLN.ViewInvestigador();
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
                dataGridView1.DataSource = invtLN.ViewInvestigadorFiltro(textBox1.Text);
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

        public void modifyInvestigador()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditInvestigador frm = new frmEditInvestigador();
                    frm.Text = "Modificar Investigador";
                    frm.opc = 1;
                    frm.label6.Text = "Modificar Investigador";
                    Investigador oip = dataGridView1.CurrentRow.DataBoundItem as Investigador;
                    frm.showData(oip);
                    frm.value = oip.Id_investigador.ToString();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        Investigador op = frm.createObject();
                        invtLN.UpdateInvestigador(op);
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
                cargarDatos();            }
            catch (Exception ex)
            {
                lbinfo.ForeColor = Color.Red;
                lbinfo.Text = "Error al modificar: " + ex.Message;
            }
        }
        public void addNewInvestigador()
        {
            try
            {
                frmEditInvestigador frm = new frmEditInvestigador();
                frm.Text = "Insertar Datos";
                frm.label6.Text = "Insertar Investigador";
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Investigador op = frm.createObject();
                    invtLN.CreateInvestigador(op);
                    frm.Close();
                    lbinfo.ForeColor = Color.Green;
                    lbinfo.Text = "Se ha añadido un artículo cientifico correctamente!";
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
        public void deleteInvestigador()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Esta seguro de realizar esta acción?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        Investigador op = dataGridView1.CurrentRow.DataBoundItem as Investigador;
                        invtLN.DeleteInvestigador(op);
                        lbinfo.ForeColor = Color.Green;
                        lbinfo.Text = "El artículo cientifico se ha eliminado con exito!";
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
                lbinfo.Text = "Se ha encontrado una falla al momento de intentar eliminar el artículo: " + ex.Message;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            modifyInvestigador();
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            addNewInvestigador();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            deleteInvestigador();
        }
    }
}
