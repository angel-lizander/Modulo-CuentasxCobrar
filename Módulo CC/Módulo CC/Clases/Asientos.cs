using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Módulo_CC.Clases
{
    class Asientos : Ifunciones
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public string Descripcion { get; set; }
        public int IDCliente { get; set; }
        public int Cuenta { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public decimal Monto { get; set; }

        public Asientos(string Descripcion, int IDCliente, int Cuenta, string TipoMovimiento, DateTime Fecha, bool Estado, decimal Monto)
        {
            this.Descripcion = Descripcion;
            this.IDCliente = IDCliente;
            this.Cuenta = Cuenta;
            this.TipoMovimiento = TipoMovimiento;
            this.Fecha = Fecha;
            this.Estado = Estado;
            this.Monto = Monto;
        }

        public bool Registrar()
        {
            try
            {

                cn.Open();
                string quety = "INSERT INTO Asientos (Descripcion, IDCliente, Cuentas, TipoMovimiento, Fecha, Estado, Monto)";
                   quety+= "Values @Descripcion, @IDCliente, @Cuenta, @TipoMovimiento, @Fecha, @Monto)";
                SqlCommand myCommand = new SqlCommand(quety, cn);
                myCommand.Parameters.AddWithValue("@Descripcion", Descripcion);
                myCommand.Parameters.AddWithValue("@IDCliente", IDCliente);
                myCommand.Parameters.AddWithValue("@Cuenta", Cuenta);
                myCommand.Parameters.AddWithValue("@TipoMovimiento", TipoMovimiento);
                myCommand.Parameters.AddWithValue("@Fecha", Fecha);
                myCommand.Parameters.AddWithValue("@Monto", Monto);
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
                string quety = ("Update Asientos  Set @Descripcion=Descripcion, @IDCliente= IDCliente, @Cuenta= Cuenta, @TipoMovimiento= TipoMovimiento, @Fecha= Fecha, @Estado= Estado, @Monto=Monto WHERE AsientoID=@AsientoID");
                SqlCommand myCommand = new SqlCommand(quety, cn);
                myCommand.Parameters.AddWithValue("@Descripcion", Descripcion);
                myCommand.Parameters.AddWithValue("@IDCliente", IDCliente);
                myCommand.Parameters.AddWithValue("@Cuenta", Cuenta);
                myCommand.Parameters.AddWithValue("@TipoMovimiento", TipoMovimiento);
                myCommand.Parameters.AddWithValue("@Fecha", Fecha);
                myCommand.Parameters.AddWithValue("@Monto", Monto);
                myCommand.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Datos Actualizados");
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




