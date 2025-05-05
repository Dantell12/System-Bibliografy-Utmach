using CapaEntidades.Inventario;
using CapaLogica.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBibliografiaUTMACH.Inventario
{
    public partial class frmEditArticulo : Form
    {
        public frmEditArticulo()
        {
            InitializeComponent();
        }
        public int opc = 0;
        public string value = "";

        private bool validarDatos()
        {
            bool verificar = true;
            if (textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || textBox1.Text.Trim().Length == 0)
            {
                verificar = false;
            }
            return verificar;
        }
      
        public void guardar()
        {
            try
            {
                if (validarDatos())
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
        public Articulo CrearObjeto()
        {
            ArticuloLN opln = new ArticuloLN();
            Articulo op = null;
            string titulo = textBox2.Text;
            string palabrasclave = textBox3.Text;
            string contacto = textBox1.Text;
            if(opc == 1)
                {
                 op = new Articulo(opln.ViewArticuloFiltro(value).FirstOrDefault().IdArticulo, titulo, palabrasclave, contacto);
                }
            else
                {
                op = new Articulo(opln.createID(), titulo, palabrasclave, contacto);
                }
            return op;
        }
        public void verDatos(Articulo aop)
        {
            textBox2.Text = aop.Titulo;
            textBox3.Text = aop.Palabrasclave;
            textBox1.Text = aop.Contacto;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void frmEditArticulo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
