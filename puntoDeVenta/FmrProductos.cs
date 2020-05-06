using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puntoDeVenta
{
    public partial class FmrProductos : Form
    {
        E_productos objEntidad = new E_productos();
        N_productos objNegocios = new N_productos();
        public FmrProductos()
        {
            InitializeComponent();
        }

        private bool editar = false;

        private void mensajeConfirmacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Curso Csharp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Curso Csharp", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void mostrarRegistros()
        {
            dataproductos.DataSource = N_productos.mostrarRegistros();
        }

        private void limpiarCaja()
        {
            editar = false;
            txtIdProducto.Text = "";
            txtnombre.Text = "";
            txtprecio.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarRegistros();
        }

        private void pb_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            limpiarCaja();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (dataproductos.SelectedRows.Count > 0)
            {
                editar = true;
                txtnombre.Text = dataproductos.CurrentRow.Cells[0].Value.ToString();
                txtprecio.Text = dataproductos.CurrentRow.Cells[1].Value.ToString();
            }
            else
            {
                mensajeError("Seleccione una fila");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dataproductos.SelectedRows.Count > 0)
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar el registro?", "Curso Csharp", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    objEntidad.idProducto = Convert.ToInt32(dataproductos.CurrentRow.Cells[0].Value.ToString());
                    objNegocios.eliminarRegsitros(objEntidad);
                    mensajeConfirmacion("Se elimino correctamente el registro");

                    mostrarRegistros();
                }
            }
            else
            {
                mensajeError("Seleccione primero una fila");
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    objEntidad.nombre = txtnombre.Text.ToUpper();

                    objNegocios.insertarRegistros(objEntidad);

                    mensajeConfirmacion("Se inserto correctamente el registro");
                    mostrarRegistros();
                    limpiarCaja();
                }
                catch (Exception err)
                {
                    mensajeError("No se pudo insertar el registro");
                    MessageBox.Show(err.Message + "+");
                }
            }

            if (editar == true)
            {
                try
                {
                    objEntidad.idProducto = Convert.ToInt32(txtnombre.Text);
                    objEntidad.nombre = txtnombre.Text.ToUpper();

                    objNegocios.editarRegistros(objEntidad);

                    mensajeConfirmacion("Se edito correctamente el registro");
                    mostrarRegistros();
                    limpiarCaja();
                }
                catch (Exception err)
                {
                    mensajeError("No se pudo editar el registro");
                    MessageBox.Show(err.Message + "-");
                }
            }
        }
    }
}
