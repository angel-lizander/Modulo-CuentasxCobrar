using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Módulo_CC.Clases
{
    class Transacciones : Ifunciones
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public int IDTransaccion { get; set; }
        public string Nombre { get; set; }
        public string  Tipo{ get; set; }
        public int Cuentas { get; set; }
        public int IDDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public int IDCliente { get; set; }
        public decimal Monto { get; set; }


        public Transacciones(string Tipo, int IDDocumento, DateTime Fecha, int IDCliente, decimal Monto )
        {

            //this.Nombre = Nombre;
            this.Tipo = Tipo;
            this.IDDocumento = IDDocumento;
            this.Fecha = Fecha;
            this.IDCliente = IDCliente;
            this.Monto = Monto;
        }

        public bool Registrar()
        {
            try
            {

                cn.Open();
                string quety = "INSERT INTO Transacciones (TipoMovimiento, IDTipoDocumento, Fecha, IDCliente, Monto)"; 
                   quety += "Values (@Tipo, @IDDocumento, @Fecha, @IDCliente, @Monto)";
                SqlCommand myCommand = new SqlCommand(quety, cn);
               // myCommand.Parameters.AddWithValue("@Nombre", Nombre);
                myCommand.Parameters.AddWithValue("@Tipo", Tipo);
                myCommand.Parameters.AddWithValue("@Cuentas", Cuentas);
                myCommand.Parameters.AddWithValue("@IDDocumento", IDDocumento);
                myCommand.Parameters.AddWithValue("@Fecha", Fecha);
                myCommand.Parameters.AddWithValue("@IDCliente", IDCliente);
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
                string quety = ("Update Transacciones set Nombre=@Nombre, Tipo=@Tipo, Cuentas=@Cuentas IDDocumento=@IDDocumento, Fecha=@Fecha, IDCliente@IDCliente, Cuentas=@Cuenta WHERE IDTransaccion=@IDTransaccion");
                SqlCommand myCommand = new SqlCommand(quety, cn);
                myCommand.Parameters.AddWithValue("@Nombre", Nombre);
                myCommand.Parameters.AddWithValue("@Tipo", Tipo);
                myCommand.Parameters.AddWithValue("@Cuentas", Cuentas);
                myCommand.Parameters.AddWithValue("@IDDocumento", IDDocumento);
                myCommand.Parameters.AddWithValue("@Fecha", Fecha);
                myCommand.Parameters.AddWithValue("@IDCliente", IDCliente);
                myCommand.Parameters.AddWithValue("@Cuentas", Cuentas);
                myCommand.Parameters.AddWithValue("@IDTransaccion", IDTransaccion);
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
