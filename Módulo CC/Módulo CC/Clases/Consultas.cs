using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Módulo_CC.Clases
{
    class Consultas
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        public DataTable CuentasContables()
        {
            var consulta = new DataTable();
            try
            {
                cn.Open();

                using (var tabla = new SqlDataAdapter("SELECT * from CuentasContable", cn))
                {
                    tabla.SelectCommand.CommandType = CommandType.Text;
                    tabla.Fill(consulta);
                }

            }
            catch (SqlException p)
            {
                MessageBox.Show(p.Message);
   
            }
            return consulta;
        }

        public DataTable TipoDocumentos()
        {
            var consulta = new DataTable();
            try
            {
                cn.Open();

                using (var tabla = new SqlDataAdapter("SELECT * from Cuentas", cn))
                {
                    tabla.SelectCommand.CommandType = CommandType.Text;
                    tabla.Fill(consulta);
                    cn.Close();
                }

            }
            catch (SqlException p)
            {
                MessageBox.Show(p.Message);

            }
            return consulta;
        }

        public DataTable BusquedaClientes()
        {
            var consulta = new DataTable();
            try
            {
                cn.Close();
                cn.Open();

                using (var tabla = new SqlDataAdapter("SELECT * from Clientes", cn))
                {
                    tabla.SelectCommand.CommandType = CommandType.Text;
                    tabla.Fill(consulta);
                    cn.Close();
                }

            }
            catch (SqlException p)
            {
                MessageBox.Show(p.Message);

            }
            return consulta;
        }

        /* public DataTable IdentificadorCliente(string busqueda)
         {
             var consulta = new DataTable();

             try
             {
                 cn.Open();

                 using (var tabla = new SqlCommand("SELECT * from Clientes WHERE CEDULA=@busqueda", cn))
                 {
                     tabla.Parameters.AddWithValue("@busqueda", busqueda);
                     SqlDataReader dr = tabla.ExecuteReader();
                     consulta.Load(dr);

                 }

             }


             catch (SqlException p)
             {
                 MessageBox.Show(p.Message);

             }
             return consulta;
         }*/
    }
}
