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
    public partial class ListadoAsientos : Form
    {
        private DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        Clases.BusquedaCriterio Busqueda = new Clases.BusquedaCriterio();

        public ListadoAsientos()
        {
            InitializeComponent();
        }

        private void Datadridview()
        {
            dt = Busqueda.Asientos();
            ds.Tables.Add(dt);
            dataGridView1.DataSource = dt;
           
        }
        private void ListadoAsientos_Load(object sender, EventArgs e)
        {
            var Consultas = new Clases.Consultas();
            CuentaContable.DataSource = Consultas.CuentasContables();
            CuentaContable.DisplayMember = "CuentasContables";
            CuentaContable.ValueMember = "CuentasContables";
            Clientes.DataSource = Consultas.BusquedaClientes();
            Clientes.DisplayMember = "Nombre";
            Clientes.ValueMember = "IDClientes";
            Datadridview();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdescripcion.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Clientes.DisplayMember= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            CuentaContable.DisplayMember= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string tipo = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            textBox1.Text = tipo;

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value) == "DE")
            {
                debito.Checked = true;
                Credito.Checked = false;
            }
            else
            {
                Credito.Checked = true;
                debito.Checked = false;
            }
           

            txtfecha.Text= Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);

            if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[7].Value))
            {
                radioButton1.Checked = true;
            }

            else
            {
                radioButton2.Checked = true;
            }
           
            txtmonto.Text= Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text== "Descripción")
            {
                string Descripcion = string.Concat("[", dt.Columns[1].ColumnName, "]");
                dt.DefaultView.Sort = Descripcion;
                DataView view = dt.DefaultView;
                view.RowFilter = string.Empty;
                if (textBox4.Text != string.Empty)
                    view.RowFilter = Descripcion + " LIKE '%" + textBox4.Text + "%'";
                dataGridView1.DataSource = view;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            bool estado;
            string tipomov;

            if (radioButton1.Checked)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }
            if (debito.Checked)
            {
                tipomov = "DE";
            }
            else
            {
                tipomov = "CR";
            }

            //var Asientos= new Clases.Asientos(txtdescripcion.Text, Convert.ToInt32(Clientes.SelectedValue.ToString()), Int32.Parse(CuentaContable.SelectedValue.ToString()),tipomov, Convert.ToDateTime(txtfecha.Text), estado, Convert.ToDecimal(txtmonto.Text),a);
            var Asientos = new Clases.Asientos(txtdescripcion.Text, Convert.ToInt32(Clientes.SelectedValue.ToString()), Int32.Parse(CuentaContable.SelectedValue.ToString()), tipomov, Convert.ToDateTime(txtfecha.Text), estado, Convert.ToDecimal(txtmonto.Text), a);

            Asientos.Editar();
            Datadridview();
        }
    }
}
