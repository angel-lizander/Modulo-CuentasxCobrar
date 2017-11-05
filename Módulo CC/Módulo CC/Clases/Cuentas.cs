using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Módulo_CC
{
    class Cuentas:Ifunciones
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int Cuentacontable { get; set; }
        public bool Estado { get; set; }


        public Cuentas(string Descripcion, int Cuentacontable, bool Estado)
        {
            this.Descripcion = Descripcion;
            this.Cuentacontable = Cuentacontable;
            this.Estado = Estado;
        }


        public bool Registrar()
        {
            try
            {

                cn.Open();
                string quety = "INSERT INTO Cuentas (Descripcion, Cuentacontable, Estado)";
                   quety += "Values (@Descripcion, @Cuentacontable, @Estado)";
                SqlCommand myCommand = new SqlCommand(quety, cn);
                myCommand.Parameters.AddWithValue("@Descripcion", Descripcion);
                myCommand.Parameters.AddWithValue("@Cuentacontable", Cuentacontable);
                myCommand.Parameters.AddWithValue("@Estado", Estado);
                myCommand.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Datos insertados correctamente");
            }

            catch (SqlException p)
            {

                MessageBox.Show(p.Message);
            }
            return true;

        }

    public bool Editar()
        {
            try
            {

                cn.Open();
                string quety = ("Update Clientes set Descripcion=@Descripcion, Cuentacontable=@Cuentacontable, Estado=@Estado WHERE CuentaID=@CuentaID");
                SqlCommand myCommand = new SqlCommand(quety, cn);
                myCommand.Parameters.AddWithValue("@Descripcion", Descripcion);
                myCommand.Parameters.AddWithValue("@Cuentacontable", Cuentacontable);
                myCommand.Parameters.AddWithValue("@Estado", Estado);
                myCommand.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Datos actualizados correctamente");
            }

            catch (SqlException p)
            {

                MessageBox.Show(p.Message);
            }
            return true;
        }

        public bool Eliminar()
        {
            throw new NotImplementedException();
        }

      
    }
}
