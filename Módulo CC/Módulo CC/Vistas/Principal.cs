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

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Cliente = new Vistas.Clientes();
            Cliente.ShowDialog();
        }

        private void documentosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Documentos = new Vistas.Gestión_Documentos();
            Documentos.ShowDialog();
        }

        private void transaccionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Transacciones = new Vistas.Transacciones();
            Transacciones.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
