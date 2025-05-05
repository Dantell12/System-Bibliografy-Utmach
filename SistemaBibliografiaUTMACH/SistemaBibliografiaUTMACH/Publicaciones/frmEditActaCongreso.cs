using CapaEntidades.Publicaciones;
using CapaLogica.Publicaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBibliografiaUTMACH.Publicaciones
{
    public partial class frmEditActaCongreso : Form
    {
        public frmEditActaCongreso()
        {
            InitializeComponent();
        }

        public int opc = 0;
        public string value = "";

        private bool validateData()
        {
            bool verificar = true;
            if (textBox2.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0 ||
                textBox3.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0 ||
                textBox7.Text.Trim().Length == 0)
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
        public ActaCongreso createObject()
        {
            ActaCongresoLN opln = new ActaCongresoLN();
            ActaCongreso op = null;
            string nombreCongreso = textBox2.Text;
            string edicionCongreso = textBox4.Text;
            string ciudadCongreso = textBox3.Text;
            DateTime fechainicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;
            string tipoCongreso = comboBox1.SelectedItem.ToString();
            string paisCongreso = textBox5.Text;
            string frecuencia = comboBox2.SelectedItem.ToString();
            string añoPrimera = textBox7.Text;
            fechainicio = new DateTime(fechainicio.Year, fechainicio.Month, fechainicio.Day);
            fechaFin = new DateTime(fechaFin.Year, fechaFin.Month, fechaFin.Day);
            if (opc == 1)
            {
                op = new ActaCongreso(opln.ViewActaCongresoFiltro(value).FirstOrDefault().Id_ActaCongreso, nombreCongreso, edicionCongreso, ciudadCongreso, fechainicio, fechaFin, tipoCongreso, paisCongreso, añoPrimera, frecuencia);
            }
            else
            {
                op = new ActaCongreso(opln.createID(), nombreCongreso, edicionCongreso, ciudadCongreso, fechainicio , fechaFin, tipoCongreso, paisCongreso, añoPrimera, frecuencia);
            }
            return op;
        }
        public void showData(ActaCongreso op)
        {
            textBox2.Text = op.NombreCongreso;
            textBox3.Text = op.CiudadCelebracion;
            textBox4.Text = op.Edicion;
            textBox5.Text = op.Pais;
            textBox7.Text = op.Añoprimera;
            dateTimePicker1.Text = op.Fechainicio.ToString();
            dateTimePicker2.Text = op.Fechafinalizacion.ToString();
            comboBox1.SelectedItem = op.TipoCongreso1;
            comboBox2.SelectedItem = op.Frecuencia;
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
