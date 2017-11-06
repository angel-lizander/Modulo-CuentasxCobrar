using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Módulo_CC.Listado
{
    public partial class ListadoTransacciones : Form
    {
        public ListadoTransacciones()
        {
            InitializeComponent();
        }

        private void ListadoTransacciones_Load(object sender, EventArgs e)
        {
            var Consultas = new Clases.Consultas();
            TipoDocumento.DataSource = Consultas.TipoDocumentos();
            TipoDocumento.DisplayMember = "Descripcion";
            TipoDocumento.ValueMember = "IDDocumentos";
            Clientes.DataSource = Consultas.BusquedaClientes();
            Clientes.DisplayMember = "Nombre";
            Clientes.ValueMember = "IDClientes";
            Datagridview();
        }

        public void Datagridview()
        {
            var Consultas = new Clases.Consultas();
           dataGridView1.DataSource = Consultas.BusquedaTransacciones();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            if (Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value)=="CR")
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            else
            {
               
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }

            TipoDocumento.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value;
            Clientes.SelectedValue= dataGridView1.CurrentRow.Cells[3].Value;
            fecha.Text =dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Monto.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            string tipo; 
            if (radioButton1.Checked)
            {
                tipo = "DE";
            }
            else
            {
                tipo = "CR";
            }

            var Transacciones = new Clases.Transacciones(Convert.ToInt32(label7.Text), tipo, Int32.Parse(TipoDocumento.SelectedIndex.ToString()), 
                Convert.ToDateTime(fecha.Text), Int32.Parse(Clientes.SelectedIndex.ToString()), Decimal.Parse(Monto.Text));

            Transacciones.Editar();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            var Transacciones = new Clases.Transacciones(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            Transacciones.Eliminar();
            Datagridview();
        }
    }
}
