using CadBiblioteca;
using ClnBiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpBiblioteca
{
    public partial class FrmEmpleados : Form
    {
        bool esNuevo;
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = EmpleadosCln.listar(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
            if(lista.Count > 0) dgvLista.Columns["nombre"].Selected = true;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            this.Size = new Size(872, 489);
            gbxDatos.Enabled = true;
            gbxLista.Enabled = false;
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(872, 274);
            gbxDatos.Enabled = false;
            gbxLista.Enabled = true;
            limpiar();
            txtParametro.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Empleados empleados = new Empleados();
                empleados.nombre = txtNombre.Text.Trim();
                empleados.apellido = txtApellido.Text.Trim();
                empleados.direccion = txtDireccion.Text.Trim();
                empleados.email = txtEmail.Text.Trim();
                empleados.telfono = Convert.ToDecimal(txtTelefono.Text);
                empleados.usuarioRegistro = Util.usuario.usuario;

                if (esNuevo)
                {
                    empleados.fechaRegistro = DateTime.Now;
                    empleados.registroActivo = true;
                    EmpleadosCln.insertar(empleados);
                }
                else
                {
                    var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
                    empleados.id = Convert.ToInt32(row.Cells["id"].Value);
                    EmpleadosCln.actualizar(empleados);
                }
                MessageBox.Show($"Empleado guardado correctamente.", ":::Biblioteca-Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
                btnCancelar.PerformClick();
            }
        }

        private bool validar()
            {
                bool esValido = true;
                erpNombre.SetError(txtNombre, string.Empty);
                erpApellido.SetError(txtApellido, string.Empty);
                erpEmail.SetError(txtEmail, string.Empty);

                if (string.IsNullOrEmpty(txtNombre.Text)) { erpNombre.SetError(txtNombre, "Nombre obligatorio"); esValido = false; }
                if (string.IsNullOrEmpty(txtApellido.Text)) { erpApellido.SetError(txtApellido, "Apellido obligatorio"); esValido = false; }
                if (string.IsNullOrEmpty(txtEmail.Text)) { erpEmail.SetError(txtEmail, "Email obligatorio"); esValido = false; }

                return esValido;
            }
            private void limpiar()
            {
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtEmail.Text = string.Empty;
            }

        private void cargarDatos()
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            txtNombre.Text = row.Cells["nombre"].Value.ToString();
            txtApellido.Text = row.Cells["apellido"].Value.ToString();
            txtDireccion.Text = row.Cells["direccion"].Value.ToString();
            txtTelefono.Text = row.Cells["telfono"].Value.ToString();
            txtEmail.Text = row.Cells["email"].Value.ToString();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            gbxDatos.Enabled = true;
            gbxLista.Enabled = false;
            cargarDatos();
            txtNombre.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            var nombre = row.Cells["nombre"].Value.ToString();
            var msg = MessageBox.Show($"¿Esta seguro que desea eliminar el Empleado con nombre {nombre}?", "::: Biblioteca - consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == msg)
            {
                EstudiantesCln.eliminar(Convert.ToInt32(row.Cells["id"].Value), Util.usuario.usuario);
                MessageBox.Show($"Empleado guardado correctamente.", ":::Biblioteca-Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
            }
        }
    }
}
