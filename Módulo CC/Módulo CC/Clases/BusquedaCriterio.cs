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
    class BusquedaCriterio
    {

        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        public DataTable Clientes()
        {
            SqlDataAdapter da;
            var tabla = new DataTable();
            da = new SqlDataAdapter("SELECT * from Clientes", cn);
             da.Fill(tabla);
            return tabla;
           
        }

        public DataTable Asientos()
        {
            SqlDataAdapter da;
            var tabla = new DataTable();
            da = new SqlDataAdapter("SELECT * from Asientos", cn);
            da.Fill(tabla);
            return tabla;

        }

        //public DataTable ClientesNombre()
        //{

        //}

        public DataTable IdentificadorCliente(string nombre)
        {
            var consulta = new DataTable();
            cn.Open();
            try
            {
                using (var tabla = new SqlCommand("SELECT * from Clientes WHERE Nombre LIKE '@Nombre%'", cn))
                {
                    tabla.Parameters.AddWithValue("@Nombre", nombre);
                    SqlDataReader dr = tabla.ExecuteReader();
                    consulta.Load(dr);

                }
            }

            finally
            {
                cn.Close();
            }
         
               

            
            return consulta;
        }
    }
}
