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
        private int Login(string User, string Password)
        {
            int pase = 0;

            try
            {
                string consulta = "Select User From Usuarios Where Usuario=@User AND Password=@Password");

                    }
            
    }
}
