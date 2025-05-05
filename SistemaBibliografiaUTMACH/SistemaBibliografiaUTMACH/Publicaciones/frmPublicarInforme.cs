using CapaEntidades.Inventario;
using CapaEntidades.Publicaciones;
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
    public partial class frmPublicarInforme : Form
    {
        public frmPublicarInforme()
        {
            InitializeComponent();
            btnguardar.Enabled = false;
            comboBox1.Enabled = false;  
        }
        public Articulo op;
        private int opc = 0;
        private int auxinfor = 0;
        InformeArticuloLN invtArtln = new InformeArticuloLN();
        public int cant = 0;

        private void cargarDatos()
        {
            dataGridView1.DataSource = invtArtln.ViewV2InformeesArticulos().Where(x => x.Idarticulo == int.Parse(textBox1.Text)).ToList();
        }
        public void verDatos()
        {
            textBox1.Text = op.IdArticulo.ToString();
            textBox2.Text = op.Titulo;
        }
        private InformeArticulo createObject()
        {
            InformeArticulo op = null;
            int idArticulo = int.Parse(textBox1.Text);
            int idinforme = ObtenerID(comboBox1.SelectedItem.ToString());
            op = new InformeArticulo(idinforme, idArticulo);
            return op;
        }
        private bool validarInvestigadorArticulo()
        {
            InformeArticulo op = invtArtln.ViewInformeArticulo()
            .Where(x => x.Idarticulo == int.Parse(textBox1.Text) &&
            x.Idinforme == ObtenerID(comboBox1.SelectedItem.ToString()))
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
                        var res = MessageBox.Show("¿Esta seguro que desea publicar el Artículo Cientifico en el Informe Técnico?", "Asignar", MessageBoxButtons.YesNo);
                        if (res.ToString().Equals("Yes"))
                        {

                            invtArtln.CreateInformeArticulo(createObject());
                            HabilitarBotones(0);
                        }
                        cargarDatos();
                    }
                    else MessageBox.Show("El Artículo Cientifico ya se encuentra publicado en este Informe Técnico");
                }
                else MessageBox.Show("Seleccione un Informe Técnico en el ComboBox");

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
                            invtArtln.UpdateInformeArticulo(createObject(), auxinfor);
                            HabilitarBotones(0);
                        }
                        cargarDatos();
                    }
                    else MessageBox.Show("El Artículo Cientifico ya se encuentra publicado en el Informe Técnico");
                }
                else MessageBox.Show("Seleccione un Informe Técnico en el ComboBox");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar publicar el Artículo Cientifico seleccionado" + ex.Message);
            }

        }
        private void mostrarCmb()
        {

            InformeTecnicoLN invln = new InformeTecnicoLN();
            var listaInvestigadores = invln.ViewInformeTecnico();
            foreach (var op in listaInvestigadores)
            {
                string item = $"[ID: {op.Id_Informe}] - [Número de Informe: {op.Numero}] - [Centro Publicación: {op.Centropublicacion}]";
                comboBox1.Items.Add(item);
            }
        }

        private void eleminarPublicacion()
        {
            InformeArticuloLN actaLN = new InformeArticuloLN();
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Esta seguro que desea eleminar la publicación selecconada?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        int idart = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                        int idinv = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        InformeArticulo op = new InformeArticulo(idinv, idart);
                        actaLN.DeleteInformeArticulo(op);
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
                    lbinfo.Text = "Seleccionar Informe Técnico en el ComboBox";
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
            int idinv = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (cant != invtArtln.ViewInformeArticulo().Count())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.Dispose();
            }
        }

        private void frmPublicarInforme_Load(object sender, EventArgs e)
        {
            cant = invtArtln.ViewInformeArticulo().Count();
            mostrarCmb();
            cargarDatos();
        }
    }
}
