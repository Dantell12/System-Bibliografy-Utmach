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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBibliografiaUTMACH.Publicaciones
{
    public partial class frmEditInformeTecnico : Form
    {
        public frmEditInformeTecnico()
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
        public InformeTecnico createObject()
        {
            InformeTecnicoLN opln = new InformeTecnicoLN();
            InformeTecnico op = null;
            string numInforme = textBox2.Text;
            string centropublicacion = textBox3.Text;
            string mes = textBox5.Text;
            string año = textBox4.Text;
            if (opc == 1)
            {
                op = new InformeTecnico(opln.ViewInformeTecnicoFiltro(value).FirstOrDefault().Id_Informe, numInforme, centropublicacion, mes, año);
            }
            else
            {
                op = new InformeTecnico(opln.createID(), numInforme, centropublicacion, mes, año);
            }
            return op;
        }
        public void showData(InformeTecnico op)
        {
            textBox2.Text = op.Numero;
            textBox3.Text = op.Centropublicacion;
            textBox4.Text = op.Añopublicacion;
            textBox5.Text = op.Mespublicacion;
        }
      
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveData();
        }
    }
}
