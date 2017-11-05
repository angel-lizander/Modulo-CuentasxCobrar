﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Módulo_CC.Clases
{
    class Clientes : Ifunciones
    {
     SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public int ID { get; set; }
        public string Nombre { get; set; }
        public int  Cedula { get; set; }
        public double Limite { get; set; }
        public bool Estado { get; set; }


        public Clientes(string Nombre, int Cedula, Double Limite, bool Estado)
        {
           // this.ID = ID;
            this.Nombre = Nombre;
            this.Cedula = Cedula;
            this.Limite = Limite;
            this.Estado = Estado;
        }
        public bool Registrar()
        {

            try
            {

                cn.Open();
                string quety = "INSERT INTO Clientes (Nombre, Cedula, Limite, Estado)";
                quety += " VALUES (@Nombre, @Cedula, @Limite, @Estado)";
                SqlCommand myCommand = new SqlCommand(quety, cn);
                myCommand.Parameters.AddWithValue("@Nombre", Nombre);
                myCommand.Parameters.AddWithValue("@Cedula", Cedula);
                myCommand.Parameters.AddWithValue("@Limite", Limite);
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
                string quety = ("Update Clientes set Nombre=@Nombre, Cedula=@Cedula, Limite=@Limite, Estado=@Estado) Values @Nombre, @Cedula, @Limite, @Estado");
                SqlCommand myCommand = new SqlCommand(quety, cn);
                myCommand.Parameters.AddWithValue("@Nombre", Nombre);
                myCommand.Parameters.AddWithValue("@Cedula", Cedula);
                myCommand.Parameters.AddWithValue("@Limite", Limite);
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
