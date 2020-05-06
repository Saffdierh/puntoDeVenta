using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace puntoDeVenta
{
    public class D_productos
    {
        readonly SqlConnection conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public DataTable mostrarRegistros()
        {
            DataTable dtResultado = new DataTable();
            SqlCommand sqlCmd = new SqlCommand("spmostrar_productos", conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
            sqlDat.Fill(dtResultado);

            return dtResultado;
        }

        public void insertarRegistros(E_productos productos)
        {
            SqlCommand sqlCmd = new SqlCommand("spinsertar_productos", conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            conectar.Open();

            sqlCmd.Parameters.AddWithValue("@nombre", productos.nombre);
            sqlCmd.Parameters.AddWithValue("@precio", productos.precio);

            sqlCmd.ExecuteNonQuery();

            conectar.Close();
        }

        public void editarRegistros(E_productos productos)
        {
            SqlCommand sqlCmd = new SqlCommand("speditar_productos", conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            conectar.Open();
            sqlCmd.Parameters.AddWithValue("@idproductos", productos.idProducto);
            sqlCmd.Parameters.AddWithValue("@nombre", productos.nombre);
            sqlCmd.Parameters.AddWithValue("@precio", productos.precio);

            sqlCmd.ExecuteNonQuery();

            conectar.Close();
        }

        public void eliminarRegistros(E_productos productos)
        {
            SqlCommand sqlCmd = new SqlCommand("speliminar_productos", conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            conectar.Open();

            sqlCmd.Parameters.AddWithValue("@idproductos", productos.idProducto);

            sqlCmd.ExecuteNonQuery();

            conectar.Close();
        }
    }
}
