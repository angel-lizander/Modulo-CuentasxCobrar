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
        public int IDAsientos { get; set; }

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

        public Asientos(string Descripcion, int IDCliente, int Cuenta, string TipoMovimiento, DateTime Fecha, bool Estado, decimal Monto, int IDAsientos)
        {
            this.Descripcion = Descripcion;
            this.IDCliente = IDCliente;
            this.Cuenta = Cuenta;
            this.TipoMovimiento = TipoMovimiento;
            this.Fecha = Fecha;
            this.Estado = Estado;
            this.Monto = Monto;
            this.IDAsientos = IDAsientos;
        }
        public bool Registrar()
        {
            try
            {

                cn.Open();
                string quety = "INSERT INTO Asientos (Descripcion, IDClientes, Cuenta, TipoMovimiento, FechaAsiento, MontoAsiento, Estado)";
                   quety+= "Values (@Descripcion, @IDClientes, @Cuenta, @TipoMovimiento, @FechaAsiento, @MontoAsiento, @Estado)";

                SqlCommand myCommand = new SqlCommand(quety, cn);
                myCommand.Parameters.AddWithValue("@Descripcion", Descripcion);
                myCommand.Parameters.AddWithValue("@IDClientes", IDCliente);
                myCommand.Parameters.AddWithValue("@Cuenta", Cuenta);
                myCommand.Parameters.AddWithValue("@TipoMovimiento", TipoMovimiento);
                myCommand.Parameters.AddWithValue("@FechaAsiento", Fecha);
                myCommand.Parameters.AddWithValue("@MontoAsiento", Monto);
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
                string quety = ("Update Asientos  Set @Descripcion=Descripcion, @IDCliente= IDClientes, @Cuenta= Cuenta, @TipoMovimiento= TipoMovimiento, @Fecha= FechaAsiento, @Estado= Estado, @Monto=MontoAsiento WHERE IDAsientos=@IDAsientos");
                SqlCommand myCommand = new SqlCommand(quety, cn);
                myCommand.Parameters.AddWithValue("@Descripcion", Descripcion);
                myCommand.Parameters.AddWithValue("@IDCliente", IDCliente);
                myCommand.Parameters.AddWithValue("@Cuenta", Cuenta);
                myCommand.Parameters.AddWithValue("@TipoMovimiento", TipoMovimiento);
                myCommand.Parameters.AddWithValue("@Fecha", Fecha);
                myCommand.Parameters.AddWithValue("@Monto", Monto);
                myCommand.Parameters.AddWithValue("@IDAsientos", IDAsientos);
                myCommand.Parameters.AddWithValue("@Estado", Estado);

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




