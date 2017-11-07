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
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public Login()
        {
            InitializeComponent();
        }
        private int Logeador(string User, string Password)
        {
            int pase = 0;
            SqlDataReader lector;

            try
            {

                string consulta = "Select User From Usuarios Where Usuario=@User AND Password=@Password";
                SqlCommand myCommand = new SqlCommand(consulta, cn);
                myCommand.Parameters.AddWithValue("@User", textBox1);
                myCommand.Parameters.AddWithValue("@Password", textBox2.Text);
                lector = myCommand.ExecuteReader();


                while (lector.Read())
                {
                    pase = 1;
                }
            }

            catch (SqlException p)
            {

                MessageBox.Show(p.Message);
            }

            return pase;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Estoy al tanto de que este login está vulnerable a SQL Injection. No tuve tiempo de encriptar el pass. Lo haré en el próximo entregable. 
            
            if(Logeador(textBox1.Text, textBox2.Text) == 1)
            {
                var frmPrincipal = new Principal();
                frmPrincipal.Show();
            }

            else
            {
                MessageBox.Show("No Juan Pablo, eso no está en la base de datos");
            }

        }
    }
}
