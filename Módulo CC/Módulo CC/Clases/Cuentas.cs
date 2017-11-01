using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Módulo_CC
{
    class Cuentas:Ifunciones
    {

        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int Cuentacontable { get; set; }
        public bool Estado { get; set; }

        public bool Registrar(int ID, string Descripcion, int Cuentacontable, bool Estado)
        {
            this.ID = ID;
            this.Descripcion = Descripcion;
            this.Cuentacontable = Cuentacontable;
            this.Estado = Estado;

            return true; 
        }

        public bool Registrar()
        {


            return true;
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
