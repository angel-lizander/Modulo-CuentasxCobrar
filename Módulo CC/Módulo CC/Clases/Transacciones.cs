using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Módulo_CC.Clases
{
    class Transacciones : Ifunciones
    {
        public string Nombre { get; set; }
        public bool  Tipo{ get; set; }
        public int Cuentas { get; set; }
        public int IDDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public int IDCliente { get; set; }
        public float Monto { get; set; }


        public bool Editar()
        {
            throw new NotImplementedException();
        }

        public bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public bool Registrar()
        {
            throw new NotImplementedException();
        }
    }
}
