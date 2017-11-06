using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Módulo_CC
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void asientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Asientos = new Vistas.Asientos();
            Asientos.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Cliente = new Vistas.Clientes();
            Cliente.ShowDialog();
        }

        private void documentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Documentos = new Vistas.Gestión_Documentos();
            Documentos.ShowDialog();
        }

        private void transaccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Transacciones = new Vistas.Transacciones();
            Transacciones.ShowDialog();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Listado = new Vistas.ListaClientes();
            Listado.ShowDialog();
             
        }

        private void asientosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Listado = new Listado.ListadoAsientos();
            Listado.ShowDialog();
        }
    }
}
