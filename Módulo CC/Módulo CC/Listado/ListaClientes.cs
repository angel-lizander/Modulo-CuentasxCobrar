using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Módulo_CC.Vistas
{
    public partial class ListaClientes : Form
    {
        Clases.BusquedaCriterio Busqueda = new Clases.BusquedaCriterio();
        private DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        public ListaClientes()
        {
            InitializeComponent();
        }


        private void ListaClientes_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = Busqueda.Clientes();
           
            comboBox1.SelectedIndex = 1;
            Datagridviewe();

        }

        public void Datagridviewe()
        {
            dt = Busqueda.Clientes();
            ds.Tables.Add(dt);
            dataGridView1.DataSource = dt;
        }
        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Nombre")
            {
                string Nombre = string.Concat("[", dt.Columns[1].ColumnName, "]");
                dt.DefaultView.Sort = Nombre;
                DataView view = dt.DefaultView;
                view.RowFilter = string.Empty;
                if (textBox4.Text != string.Empty)
                    view.RowFilter = Nombre + " LIKE '%" + textBox4.Text + "%'";
                dataGridView1.DataSource = view;
            }

           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value))
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

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
            //dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var Clientes = new Clases.Clientes(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), textBox1.Text, Convert.ToInt32(textBox3.Text), Convert.ToDouble(textBox2.Text), estado);
            Clientes.Editar();
            Datagridviewe();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Clientes= new Clases.Clientes(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            Clientes.Eliminar();
            Datagridviewe();
        }
    }
}
