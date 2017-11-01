using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Módulo_CC.Clases
{
    class Clientes : Ifunciones
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int  Cedula { get; set; }
        public float Limite { get; set; }
        public bool Estado { get; set; }

        public bool Registrar()
        {
            throw new NotImplementedException();
        }
        public bool Editar()
        {
            throw new NotImplementedException();
        }

        public bool Eliminar()
        {
            throw new NotImplementedException();
        }

       
    }
}
