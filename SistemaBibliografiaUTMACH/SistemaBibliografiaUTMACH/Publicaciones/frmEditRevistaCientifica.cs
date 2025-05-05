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
    public partial class frmEditRevistaCientifica : Form
    {
        public frmEditRevistaCientifica()
        {
            InitializeComponent();
        }
        public int opc = 0;
        public string value = "";

        private bool validateData()
        {
            bool verificar = true;
            if ( textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 ||
                 textBox6.Text.Trim().Length == 0 || textBox7.Text.Trim().Length == 0 ||
                 textBox9.Text.Trim().Length == 0)
            {
                verificar = false;
            }
            return verificar;
        }

        public void saveData()
        {
            try
            {
                if (validateData())
                {

                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Los campos con (*) son obligatorios");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public RevistaCientifica createObject()
        {
            RevistaCientificaLN opln = new RevistaCientificaLN();
            RevistaCientifica op = null;
            string nombreRevista = textBox2.Text;
            string nombreEditor = textBox3.Text;
            DateTime añoIniciPubli = dateTimePicker1.Value;
            string frecuencia = comboBox1.SelectedItem.ToString();
            string temasTratados = textBox6.Text;
            int numRevista = int.Parse(textBox7.Text);
            DateTime Añopublicacionactual = dateTimePicker2.Value;
            decimal costopubli = decimal.Parse(textBox9.Text);
            añoIniciPubli = new DateTime(añoIniciPubli.Year, añoIniciPubli.Month, añoIniciPubli.Day);
            Añopublicacionactual = new DateTime(Añopublicacionactual.Year, Añopublicacionactual.Month, Añopublicacionactual.Day);
            if (opc == 1)
            {
                op = new RevistaCientifica(opln.ViewRevistaCientificaFiltro(value).FirstOrDefault().Id_revista, nombreRevista, nombreEditor, añoIniciPubli, frecuencia, temasTratados, numRevista, Añopublicacionactual, costopubli);
            }
            else
            {
                op = new RevistaCientifica(opln.createID(), nombreRevista, nombreEditor, añoIniciPubli, frecuencia, temasTratados, numRevista, Añopublicacionactual, costopubli);
            }
            return op;
        }
        public void showData(RevistaCientifica oRevista)
        {
            textBox2.Text = oRevista.Nombre;
            textBox3.Text = oRevista.Editor;
            dateTimePicker1.Text = oRevista.Añopublicacion.ToString();
            comboBox1.SelectedItem = oRevista.Frecuencia;
            textBox6.Text = oRevista.Temas;
            textBox7.Text = oRevista.Numero.ToString();
            dateTimePicker2.Text = oRevista.AñopublicacionActual.ToString();
            textBox9.Text = oRevista.Costo.ToString();
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
