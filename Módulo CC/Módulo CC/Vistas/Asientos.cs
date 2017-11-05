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
    public partial class Asientos : Form
    {
        public Asientos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tipo;
            bool estado;
            if (radioButton4.Checked)
            {
                tipo = "Debito";
            }
            else
            {
                tipo = "Credito";
            }
            if (radioButton1.Checked)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }



            var Asientos = new Clases.Asientos(txtdescripcion.Text, Convert.ToInt32(Clientes.SelectedValue.ToString()),Int32.Parse(CuentaContable.SelectedValue.ToString()), tipo, DateTime.Parse(txtfecha.Text), estado, Convert.ToDecimal(txtmonto.Text));
        }

        private void Asientos_Load(object sender, EventArgs e)
        {
            var Consultas = new Clases.Consultas();
            CuentaContable.DataSource = Consultas.CuentasContables();
            CuentaContable.DisplayMember = "CuentasContables";
            CuentaContable.ValueMember = "CuentasContables";
            Clientes.DataSource = Consultas.BusquedaClientes();
            Clientes.DisplayMember = "Nombre";
            Clientes.ValueMember = "IDClientes";
        }
    }
}
