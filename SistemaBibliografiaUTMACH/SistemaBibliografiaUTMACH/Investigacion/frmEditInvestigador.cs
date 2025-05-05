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
    public partial class frmEditInvestigador : Form
    {
        public frmEditInvestigador()
        {
            InitializeComponent();
        }
        public int opc = 0;
        public string value = "";

        private bool validateData()
        {
            bool verificar = true;
            if (textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 ||
                textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0)
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
        public Investigador createObject()
        {
            InvestigadorLN opln = new InvestigadorLN();
            Investigador op = null;
            string nombre = textBox2.Text;
            string centroTrabajo = textBox4.Text;
            string email = textBox3.Text;
            string tema = textBox5.Text;
            if (opc == 1)
            {
                op = new Investigador(opln.ViewInvestigadorFiltro(value).FirstOrDefault().Id_investigador, nombre, centroTrabajo, email, tema);
            }
            else
            {
                op = new Investigador(opln.createID(), nombre, centroTrabajo, email, tema);
            }
            return op;
        }
        public void showData(Investigador op)
        {
            textBox2.Text = op.Nombre;
            textBox4.Text = op.Centrotrabajo;
            textBox3.Text = op.Correo;
            textBox5.Text = op.Temas;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            saveData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
