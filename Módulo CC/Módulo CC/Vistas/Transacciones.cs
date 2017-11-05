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
    public partial class Transacciones : Form
    {
        public Transacciones()
        {
            InitializeComponent();
        }

        private void Transacciones_Load(object sender, EventArgs e)
        {
            var Consultas = new Clases.Consultas();
            TipoDocumento.DataSource = Consultas.TipoDocumentos();
            TipoDocumento.DisplayMember = "Descripcion";
            TipoDocumento.ValueMember = "IDDocumentos";
            Clientes.DataSource = Consultas.BusquedaClientes();
            Clientes.DisplayMember ="Nombre";
            Clientes.ValueMember = "IDClientes";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string debito;

            if (radioButton1.Checked)
            {
                debito = "DE";
            }
            else
            {
                debito = "CR";
            }
            
            var Transacciones = new Clases.Transacciones(debito, Int32.Parse(TipoDocumento.SelectedValue.ToString()), Convert.ToDateTime(fecha.Text), Int32.Parse(Clientes.SelectedValue.ToString()), Convert.ToDecimal(Monto.Text));
            Transacciones.Registrar();

        }
    }
}
