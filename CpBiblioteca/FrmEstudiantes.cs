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
    public partial class FrmEstudiantes : Form
    {
        bool esNuevo;
        public FrmEstudiantes()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = EstudiantesCln.listarPa(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["ci"].Visible = false;
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
            if (lista.Count > 0) dgvLista.Columns["nombre"].Selected = true;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
        private void btnGuardar_Click_1(object sender, EventArgs e)
        { 
            if(validar()) { 
            Estudiantes estudiantes = new Estudiantes();
            estudiantes.nombre = txtNombre.Text.Trim();
            estudiantes.apellido = txtApellido.Text.Trim();
            estudiantes.direccion = txtDireccion.Text.Trim();
            estudiantes.edad = txtEdad.Text.Trim();
            estudiantes.carrera = txtCarrera.Text.Trim();
            estudiantes.usuarioRegistro = Util.usuario.usuario;

            if(esNuevo)
            {
                estudiantes.fechaRegistro = DateTime.Now;
                estudiantes.registroActivo = true;
                EstudiantesCln.insertar(estudiantes);
            }
            else
            {
                var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
                estudiantes.ci = Convert.ToInt32(row.Cells["ci"].Value);
                EstudiantesCln.actualizar(estudiantes);
            }
            MessageBox.Show($"Estudiante guardado correctamente.",":::Biblioteca-Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listar();
            btnCancelar.PerformClick();
            }
        }

        private bool validar()
        {
            bool esValido = true;
            erpNombre.SetError(txtNombre, string.Empty);
            erpApellido.SetError(txtApellido, string.Empty);
            erpCarrera.SetError(txtCarrera, string.Empty);

            if (string.IsNullOrEmpty(txtNombre.Text)) { erpNombre.SetError(txtNombre, "Nombre obligatorio"); esValido = false;}
            if (string.IsNullOrEmpty(txtApellido.Text)) { erpApellido.SetError(txtApellido, "Apellido obligatorio"); esValido = false; }
            if (string.IsNullOrEmpty(txtCarrera.Text)) { erpCarrera.SetError(txtCarrera, "Carrera obligatorio"); esValido = false; }

            return esValido;
        }
        private void limpiar()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtCarrera.Text = string.Empty;
         }

        private void cargarDatos()
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            txtNombre.Text = row.Cells["nombre"].Value.ToString();
            txtApellido.Text = row.Cells["apellido"].Value.ToString();
            txtDireccion.Text = row.Cells["direccion"].Value.ToString();
            txtEdad.Text = row.Cells["edad"].Value.ToString();
            txtCarrera.Text = row.Cells["carrera"].Value.ToString();

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
            var msg = MessageBox.Show($"¿Esta seguro que desea eliminar el Estudiante con nombre {nombre}?", "::: Biblioteca - consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == msg)
            {
                EstudiantesCln.eliminar(Convert.ToInt32(row.Cells["ci"].Value), Util.usuario.usuario);
                MessageBox.Show($"Estudiante guardado correctamente.", ":::Biblioteca-Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
            }
        }

        private void FrmEstudiantes_Load(object sender, EventArgs e)
        {
            this.Size = new Size(872, 274);
        }
    }
}
