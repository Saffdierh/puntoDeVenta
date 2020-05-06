using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puntoDeVenta
{
    public class main
    {
        private bool editar = false;
        readonly E_Ciudades objEntidad = new E_Ciudades();
        readonly N_Ciudades objNegocios = new N_Ciudades();

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
            data_listado.DataSource = N_Ciudades.mostrarRegistros();
        }

        private void limpiarCaja()
        {
            editar = false;
            txt_codigo.Text = "";
            txt_descripcion.Text = "";
            txt_descripcion.Focus();
        }

        public Form1()
        {
            InitializeComponent();
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
            if (data_listado.SelectedRows.Count > 0)
            {
                editar = true;
                txt_codigo.Text = data_listado.CurrentRow.Cells[0].Value.ToString();
                txt_descripcion.Text = data_listado.CurrentRow.Cells[1].Value.ToString();
            }
            else
            {
                mensajeError("Seleccione una fila");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (data_listado.SelectedRows.Count > 0)
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar el registro?", "Curso Csharp", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    objEntidad.IdCiudades = Convert.ToInt32(data_listado.CurrentRow.Cells[0].Value.ToString());
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
                    objEntidad.Description = txt_descripcion.Text.ToUpper();

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
                    objEntidad.IdCiudades = Convert.ToInt32(txt_codigo.Text);
                    objEntidad.Description = txt_descripcion.Text.ToUpper();

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
