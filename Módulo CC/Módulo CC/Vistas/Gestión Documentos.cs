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
    public partial class Gestión_Documentos : Form
    {
        public Gestión_Documentos()
        {
            InitializeComponent();
        }

        private void Gestión_Documentos_Load(object sender, EventArgs e)
        {
            var Consultas = new Clases.Consultas();
            CuentasContables.DataSource = Consultas.CuentasContables();
            CuentasContables.DisplayMember = "CuentasContables";
            CuentasContables.ValueMember = "CuentasContables";

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

            //int N = Int32.Parse(this.CuentasContables.SelectedItem.ToString());

            var Cuentas = new Cuentas(Descripcion.Text,Int32.Parse(CuentasContables.SelectedValue.ToString()),estado);
            Cuentas.Registrar();
        }
    }
}
