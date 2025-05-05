using CapaEntidades.Inventario;
using CapaLogica.Inventario;
using SistemaBibliografiaUTMACH.Inventario;
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
    public partial class frmAdminArticulo : Form
    {
        public frmAdminArticulo()
        {
            InitializeComponent();
            cargarDatos();
        }

        ArticuloLN artLN = new ArticuloLN();
        private void cargarDatos()
        {
            dataGridView1.DataSource = artLN.ViewArticulo();
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
                dataGridView1.DataSource = artLN.ViewArticuloFiltro(textBox1.Text);
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

        public void modifyArticulo()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditArticulo frm = new frmEditArticulo();
                    frm.Text = "Actualizar";
                    frm.opc = 1;
                    frm.label1.Text = "Actualizar Articulo";
                    Articulo oip = dataGridView1.CurrentRow.DataBoundItem as Articulo;
                    frm.verDatos(oip);
                    frm.value = oip.IdArticulo.ToString();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        Articulo op = frm.CrearObjeto();
                        artLN.UpdateArticulo(op);
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
                dataGridView1.DataSource = artLN.ViewArticulo();
            }
            catch (Exception ex)
            {
                lbinfo.ForeColor = Color.Red;
                lbinfo.Text = "Error al modificar: " + ex.Message;
            }
        }
        public void addNewArticulo()
        {
            try
            {
                frmEditArticulo frm = new frmEditArticulo();
                frm.Text = "Insertar Datos";
                frm.label1.Text = "Añadir Articulo";
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Articulo op = frm.CrearObjeto();
                    artLN.CreateArticulo(op);
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
                dataGridView1.DataSource = artLN.ViewArticulo();

            }
            catch (Exception ex)
            {
                lbinfo.ForeColor = Color.Red;
                lbinfo.Text = "Error al añadir: " + ex.Message;
            }
        }
        public void deleteArticulo()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Esta seguro de realizar esta acción?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        Articulo op = dataGridView1.CurrentRow.DataBoundItem as Articulo;
                        artLN.DeleteArticulo(op);
                        lbinfo.ForeColor = Color.Green;
                        lbinfo.Text = "El artículo cientifico se ha eliminado con exito!";
                    }
                    else
                    {
                        lbinfo.ForeColor = Color.Red;
                        lbinfo.Text = "Se ha cancelado la eliminación del artículo ";
                    }
                }
                dataGridView1.DataSource = artLN.ViewArticulo();
            }
            catch (Exception ex)
            {
                lbinfo.ForeColor = Color.Red;
                lbinfo.Text = "Se ha encontrado una falla al momento de intentar eliminar el artículo: " + ex.Message;
            }
        }
        public void asignarInvestigador()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmAsignarInvestigadorArticulo frm = new frmAsignarInvestigadorArticulo();
                    frm.Text = "Asignar Investigador";
                    frm.op = dataGridView1.CurrentRow.DataBoundItem as Articulo;
                    frm.verDatos();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        frm.Close();
                        lbinfo.ForeColor = Color.Green;
                        lbinfo.Text = "Cambios realizados correctamente!";
                    }
                    else
                    {
                        frm.Close();
                        lbinfo.ForeColor = Color.Red;
                        lbinfo.Text = "Se ha cancelado la asignación" ; 
                    }
                }
            }
            catch (Exception ex)
            {
                lbinfo.ForeColor = Color.Red;
                lbinfo.Text = "Se ha encontrado una falla en la asignación de investigadores: " + ex.Message;
            }
        }
        public void publicarRevista()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmPublicarRevista frm = new frmPublicarRevista();
                    frm.Text = "Asignar Investigador";
                    frm.op = dataGridView1.CurrentRow.DataBoundItem as Articulo;
                    frm.verDatos();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        frm.Close();
                        lbinfo.ForeColor = Color.Green;
                        lbinfo.Text = "Publicación realizada con exito!";
                    }
                    else
                    {
                        frm.Close();
                        lbinfo.ForeColor = Color.Red;
                        lbinfo.Text = "Publicación cancelada...!";
                    }
                }
            }
            catch (Exception ex)
            {
                lbinfo.ForeColor = Color.Red;
                lbinfo.Text = "Se ha encontrado una falla al momento de publicar el artículo cientifico: " + ex.Message;

            }
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
                textBox1.ForeColor = Color.Green;
                this.ActiveControl = null; // Quitar el foco del TextBox
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void btnAsignInvest_Click(object sender, EventArgs e)
        {
            asignarInvestigador();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            modifyArticulo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            deleteArticulo();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            addNewArticulo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                frmOpcionPublicacion frm = new frmOpcionPublicacion();
                frm.Text = "Asignar Investigador";
                frm.oip = dataGridView1.CurrentRow.DataBoundItem as Articulo;
                frm.ShowDialog();
            }
            else
            {
                lbinfo.ForeColor = Color.Red;
                lbinfo.Text = "Elegir un Artículo Cientifico en la lista";
            }
               
        }
    }
}
