using CapaEntidades.Inventario;
using CapaEntidades.Publicaciones;
using CapaLogica.Investigacion;
using CapaLogica.Publicaciones;
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

namespace SistemaBibliografiaUTMACH.Publicaciones
{
    public partial class frmPublicarRevista : Form
    {
        public frmPublicarRevista()
        {
            InitializeComponent();
            btnguardar.Enabled = false;
            comboBox1.Enabled = false;
        }
        public Articulo op;
        private int opc = 0;
        private int auxinfor = 0;
        RevistaArticuloLN invtArtln = new RevistaArticuloLN();
        public int cant = 0;

        private void cargarDatos()
        {
            dataGridView1.DataSource = invtArtln.ViewV2RevistaesArticulos().Where(x => x.Idarticulo == int.Parse(textBox1.Text)).ToList();
        }
        public void verDatos()
        {
            textBox1.Text = op.IdArticulo.ToString();
            textBox2.Text = op.Titulo;
        }
        private RevistaArticulo createObject()
        {
            RevistaArticulo op = null;
            int idArticulo = int.Parse(textBox1.Text);
            int idrev = ObtenerID(comboBox1.SelectedItem.ToString());
            op = new RevistaArticulo(idrev, idArticulo);
            return op;
        }
        private bool validarInvestigadorArticulo()
        {
            RevistaArticulo op = invtArtln.ViewRevistaArticulo()
            .Where(x => x.Idarticulo == int.Parse(textBox1.Text) &&
            x.Idrevista == ObtenerID(comboBox1.SelectedItem.ToString()))
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
        private void publicarArticulo()
        {
            try
            {
                if (comboBox1.SelectedItem != null)
                {
                    if (validarInvestigadorArticulo())
                    {
                        var res = MessageBox.Show("¿Esta seguro que desea publicar el Artículo Cientifico en el Revista Cientifica?", "Asignar", MessageBoxButtons.YesNo);
                        if (res.ToString().Equals("Yes"))
                        {

                            invtArtln.CreateRevistaArticulo(createObject());
                            HabilitarBotones(0);
                        }
                        cargarDatos();
                    }
                    else MessageBox.Show("El Artículo Cientifico ya se encuentra publicado en la Revista Cientifica");
                }
                else MessageBox.Show("Seleccione una Revista Cientifica en el ComboBox");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar publicar el Artículo Cientifico seleccionado" + ex.Message);
            }

        }
        private void modificarPublicacion()
        {
            try
            {
                if (comboBox1.SelectedItem != null)
                {
                    if (validarInvestigadorArticulo())
                    {
                        var res = MessageBox.Show("¿Esta seguro que desea modificar la publicación seleccionada?", "Modificar", MessageBoxButtons.YesNo);
                        if (res.ToString().Equals("Yes"))
                        {
                            invtArtln.UpdateRevistaArticulo(createObject(), auxinfor);
                            HabilitarBotones(0);
                        }
                        cargarDatos();
                    }
                    else MessageBox.Show("El Artículo Cientifico ya se encuentra publicado en la Revista Cientifica");
                }
                else MessageBox.Show("Seleccione una Revista Cientifica en el ComboBox");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar publicar el Artículo Cientifico seleccionado" + ex.Message);
            }

        }
        private void mostrarCmb()
        {

            RevistaCientificaLN invln = new RevistaCientificaLN();
            var listaInvestigadores = invln.ViewRevistaCientifica();
            foreach (var op in listaInvestigadores)
            {
                string item = $"[ID: {op.Id_revista}] - [Nombre Revista: {op.Nombre}] - [Editor: {op.Editor}]";
                comboBox1.Items.Add(item);
            }
        }

        private void eleminarPublicacion()
        {
            RevistaArticuloLN actaLN = new RevistaArticuloLN();
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Esta seguro que desea eleminar la publicación selecconada?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        int idart = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                        int idinv = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        RevistaArticulo op = new RevistaArticulo(idinv, idart);
                        actaLN.DeleteRevistaArticulo(op);
                        HabilitarBotones(0);
                    }
                }
                cargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar eliminar la publicación seleccionada" + ex.Message);
            }
        }
        private void SeleccionarIDenComboBox(int id)
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (ObtenerID(comboBox1.Items[i].ToString()) == id)
                {
                    comboBox1.SelectedIndex = i;
                    return;
                }
            }
        }
        private void HabilitarBotones(int opcion)
        {
            btnPublicar.Enabled = opcion == 1 || opcion == 0;
            btnmodificar.Enabled = opcion == 2 || opcion == 0;
            btneliminar.Enabled = opcion == 3 || opcion == 0;
            comboBox1.Enabled = opcion == 1 || opcion == 2 || opcion == 3;
            btnguardar.Enabled = opcion != 0;
            comboBox1.Enabled = opcion != 0 && opcion != 3;
            comboBox1.SelectedIndex = -1;

            switch (opcion)
            {
                case 1:
                    lbinfo.Text = "Seleccionar Revista Cientifica en el ComboBox";
                    break;
                case 2:
                    lbinfo.Text = "Seleccionar en la lista la publicación a modificar";
                    break;
                case 3:
                    lbinfo.Text = "Seleccionar en la lista la publicación a eliminar";
                    break;
                default:
                    lbinfo.Text = "...";
                    break;
            }
        }
        private void btnPublicar_Click(object sender, EventArgs e)
        {
            opc = 1;
            HabilitarBotones(1);
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            opc = 2;
            HabilitarBotones(2);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            opc = 3;
            HabilitarBotones(3);
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (opc == 1) //Publicar
            {
                publicarArticulo();

            }
            if (opc == 2) //Modificar
            {
                modificarPublicacion();
            }
            if (opc == 3) //Eliminar
            {
                eleminarPublicacion();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HabilitarBotones(0);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int idinv = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            if (opc == 2)
            {
                SeleccionarIDenComboBox(idinv);
                auxinfor = idinv;
            }
            if (opc == 3)
            {
                SeleccionarIDenComboBox(idinv);
            }
        }

        private void frmPublicarRevista_Load(object sender, EventArgs e)
        {
            cant = invtArtln.ViewRevistaArticulo().Count();
            mostrarCmb();
            cargarDatos();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cant != invtArtln.ViewRevistaArticulo().Count())
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
