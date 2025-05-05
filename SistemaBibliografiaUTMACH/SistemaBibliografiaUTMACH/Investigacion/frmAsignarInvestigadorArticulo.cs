using CapaEntidades.Inventario;
using CapaEntidades.Investigacion;
using CapaLogica.Investigacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBibliografiaUTMACH.Investigacion
{
    public partial class frmAsignarInvestigadorArticulo : Form
    {
        public frmAsignarInvestigadorArticulo()
        {
            InitializeComponent();
            btnguardar.Enabled = false;
            comboBox1.Enabled = false;
        }
        public Articulo op;
        private int opc = 0;
        private int auxinv = 0;
        InvestigadorArticuloLN invtArtln = new InvestigadorArticuloLN();
        public int cant = 0;

        private void cargarDatos()
        {
            dataGridView1.DataSource = invtArtln.ViewInvestigadoresArticulos().Where(x => x.IdArticulo == int.Parse(textBox1.Text)).ToList();
        }
        public void verDatos()
        {
            textBox1.Text = op.IdArticulo.ToString();
            textBox2.Text = op.Titulo;
        }
        private InvestigadorArticulo createObject()
        {
            InvestigadorArticulo op = null;
            int idArticulo = int.Parse(textBox1.Text);
            int idInvestigador = ObtenerID(comboBox1.SelectedItem.ToString());
            op = new InvestigadorArticulo(idInvestigador, idArticulo);
            return op;
        }
        private bool validarInvestigadorArticulo()
        {
            InvestigadorArticulo op = invtArtln.ViewInvestigadorArticulo()
            .Where(x => x.IdArticulo == int.Parse(textBox1.Text) &&
            x.IdInvestigador == ObtenerID(comboBox1.SelectedItem.ToString()))
            .FirstOrDefault();
            if (op != null)
            {
                return false;
            }
            else return true;
        }
        private int ObtenerID(string input)
        {
            Match match = Regex.Match(input, @"\d+");
            int num = 0;
            if (match.Success)
            {
                if (int.TryParse(match.Value, out int numero))
                {
                    num = numero;
                }
            }
            return num;
        }
        private void asignarInvestigador()
        {
            try
            {
                if (comboBox1.SelectedItem != null)
                {
                    if (validarInvestigadorArticulo())
                    {
                        var res = MessageBox.Show("¿Esta seguro que desea asignar el investigador seleccionado en el artículo?", "Asignar", MessageBoxButtons.YesNo);
                        if (res.ToString().Equals("Yes"))
                        {

                            invtArtln.CreateInvestigadorArticulo(createObject());
                            HabilitarBotones(0);
                        }
                        cargarDatos();
                    }
                    else MessageBox.Show("El investigador ya está asignado al artículo");
                }
                else MessageBox.Show("Seleccione un investigador en el ComboBox");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar asignar investigador al artículo seleccionado" + ex.Message);
            }

        }
        private void modificarInvestigador()
        {
            try
            {
                if (comboBox1.SelectedItem != null)
                {
                    if (validarInvestigadorArticulo())
                    {
                        var res = MessageBox.Show("¿Esta seguro que desea modificar el investigador seleccionado en el artículo?", "Modificar", MessageBoxButtons.YesNo);
                        if (res.ToString().Equals("Yes"))
                        {
                            invtArtln.UpdateInvestigadorArticulo(createObject(), auxinv);
                            HabilitarBotones(0);
                        }
                        cargarDatos();
                    }
                    else MessageBox.Show("El investigador ya está asignado al artículo");
                }
                else MessageBox.Show("Seleccione un investigador en el ComboBox");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar asignar investigador al artículo seleccionado" + ex.Message);
            }

        }
        private void mostrarCmb()
        {

            InvestigadorLN invln = new InvestigadorLN();
            var listaInvestigadores = invln.ViewInvestigador();
            foreach (var investigador in listaInvestigadores)
            {
                string item = $"[ID: {investigador.Id_investigador}] - [Nombre: {investigador.Nombre}] - [Centro de Trabajo: {investigador.Centrotrabajo}]";
                comboBox1.Items.Add(item);
            }
        }

        private void eliminarasignacion()
        {
            InvestigadorArticuloLN invln = new InvestigadorArticuloLN();
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Esta seguro que desea eliminar la asignación de articulos e investigadores??", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        int idart = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                        int idinv = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        InvestigadorArticulo op = new InvestigadorArticulo(idinv, idart);
                        invln.DeleteInvestigadorArticulo(op);
                        HabilitarBotones(0);
                    }
                }
                cargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar eliminar la asignación" + ex.Message);
            }
        }
        private void SeleccionarIDenComboBox(int id)
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                // Comprueba si el elemento actual tiene el valor que deseas seleccionar
                if (ObtenerID(comboBox1.Items[i].ToString()) == id)
                {
                    // Si es el elemento que buscas, establece el índice seleccionado
                    comboBox1.SelectedIndex = i;
                    return; // Sale del bucle una vez que se ha encontrado y seleccionado el elemento
                }
            }
        }


        private void frmAsignarInvestigadorArticulo_Load(object sender, EventArgs e)
        {
            cant = invtArtln.ViewInvestigadorArticulo().Count();
            mostrarCmb();
            cargarDatos();
        }


        private void HabilitarBotones(int opcion)
        {
            btnAsignar.Enabled = opcion == 1 || opcion == 0;
            btnmodificar.Enabled = opcion == 2 || opcion == 0;
            btneliminar.Enabled = opcion == 3 || opcion == 0;
            comboBox1.Enabled = opcion == 1 || opcion == 2 || opcion == 3;
            btnguardar.Enabled = opcion != 0;
            comboBox1.Enabled = opcion != 0 && opcion != 3;
            comboBox1.SelectedIndex = -1;

            switch (opcion)
            {
                case 1:
                    lbinfo.Text = "Seleccione un investigador en el ComboBox";
                    break;
                case 2:
                    lbinfo.Text = "Seleccione en la lista la asignación a modificar";
                    break;
                case 3:
                    lbinfo.Text = "Seleccione en la lista la asignación a eliminar";
                    break;
                default:
                    lbinfo.Text = "";
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            opc = 0;
            HabilitarBotones(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            opc = 1;
            HabilitarBotones(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            opc = 2;
            HabilitarBotones(2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            opc = 3;
            HabilitarBotones(3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (opc == 1) //Asignar
            {
                asignarInvestigador();
            }
            if (opc == 2) //Modificar
            {
                modificarInvestigador();
            }
            if (opc == 3) //Eliminar
            {
                eliminarasignacion();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int idinv = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (opc == 2)
            {
                SeleccionarIDenComboBox(idinv);
                auxinv = idinv;
            }
            if (opc == 3)
            {
                SeleccionarIDenComboBox(idinv);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cant != invtArtln.ViewInvestigadoresArticulos().Count())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.Dispose();
            }
        }

    }
}