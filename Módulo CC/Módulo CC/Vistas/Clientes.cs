using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Módulo_CC.Vistas
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool estado;

            if (radioButton1.Checked)
            {
               estado = true;
            }
            else
            {
                estado = false;
            }
            var Clientes = new Clases.Clientes(txtNombre.Text,Convert.ToInt32(txtCedula.Text),Convert.ToDouble(txtCredito.Text),estado);
            Clientes.Registrar();
        }
    }
}
