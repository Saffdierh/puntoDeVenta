using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace puntoDeVenta
{
    public class N_productos
    {
        readonly D_productos objCiudades = new D_productos();

        public static DataTable mostrarRegistros()
        {
            return new D_productos().mostrarRegistros();
        }

        public void insertarRegistros(E_productos productos)
        {
            objCiudades.insertarRegistros(productos);
        }

        public void editarRegistros(E_productos productos)
        {
            objCiudades.editarRegistros(productos);
        }

        public void eliminarRegsitros(E_productos productos)
        {
            objCiudades.eliminarRegistros(productos);
        }
    }
}
