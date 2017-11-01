using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Módulo_CC.Clases
{
    class Asientos: Ifunciones
    {
        public string Descripcion { get; set; }
        public string IDCliente { get; set; }
        public int Cuenta { get; set; }
        public bool TipooMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public double Monto { get; set; }

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
