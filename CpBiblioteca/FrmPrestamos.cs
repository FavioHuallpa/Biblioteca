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
    public partial class FrmPrestamos : Form
    {
        bool esNuevo;
        public FrmPrestamos()
        {
            InitializeComponent();
        }
        private void listar()
        {
            var lista = PrestamosCln.listar(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["no_prestamo"].Visible = false;
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
            if (lista.Count > 0) dgvLista.Columns["idEmpleados"].Selected = true;
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
            txtEmpleado .Focus();
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
                Prestamos prestamos = new Prestamos();
                prestamos.idEmpleados = Convert.ToInt32(txtEmpleado.Text);
                prestamos.ciEstudiantes  = Convert.ToInt32(txtEstudiante.Text);
                prestamos.cod_libroLibros = Convert.ToInt32(txtLibro.Text);
                prestamos.codDevoluciones  = Convert.ToInt32(txtDevolucion.Text);
                prestamos.fechaprestamo = txtPrestamo.Text.Trim();
                prestamos.fechadevolucion = txtDevoluvion.Text.Trim();
                prestamos.usuarioRegistro = Util.usuario.usuario;

                if (esNuevo)
                {
                    prestamos.fechaRegistro = DateTime.Now;
                    prestamos.registroActivo = true;
                    PrestamosCln.insertar(prestamos);
                }
                else
                {
                    var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
                    prestamos.no_prestamo = Convert.ToInt32(row.Cells["no_prestamo"].Value);
                    PrestamosCln.actualizar(prestamos);
                }
                MessageBox.Show($"Lista de prestamos guardado correctamente.", ":::Biblioteca-Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
                btnCancelar.PerformClick();
            }
        }
        private bool validar()
        {
            bool esValido = true;
            erpLibro.SetError(txtLibro, string.Empty);
            erpDevolucion.SetError(txtDevolucion, string.Empty);
            if (string.IsNullOrEmpty(txtLibro.Text)) { erpLibro.SetError(txtLibro, "codigo de libro obligatorio"); esValido = false; }
            if (string.IsNullOrEmpty(txtDevolucion.Text)) { erpDevolucion.SetError(txtDevolucion, "codigo de devolucion obligatorio"); esValido = false; }
            return esValido;
        }
        private void limpiar()
        {
            txtEmpleado.Text = string.Empty;
            txtEstudiante.Text = string.Empty;
            txtLibro.Text = string.Empty;
            txtPrestamo.Text = string.Empty;
            txtDevoluvion.Text = string.Empty;
            txtDevolucion.Text = string.Empty;
        }

        private void cargarDatos()
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            txtEmpleado.Text = row.Cells["idEmpleados"].Value.ToString();
            txtEstudiante.Text = row.Cells["ciEstudiantes"].Value.ToString();
            txtLibro.Text = row.Cells["cod_libroLibros"].Value.ToString();
            txtPrestamo.Text = row.Cells["fechaprestamo"].Value.ToString();
            txtDevoluvion.Text = row.Cells["fechadevolucion"].Value.ToString();
            txtDevolucion.Text = row.Cells["codDevoluciones"].Value.ToString();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            gbxDatos.Enabled = true;
            gbxLista.Enabled = false;
            cargarDatos();
            txtEmpleado.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            var idEmpleados = row.Cells["idEmpleados"].Value.ToString();
            var msg = MessageBox.Show($"¿Esta seguro que desea eliminar prestamos con idEmpleados {idEmpleados}?", "::: Biblioteca - consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == msg)
            {
                PrestamosCln.eliminar(Convert.ToInt32(row.Cells["no_prestamo"].Value), Util.usuario.usuario);
                MessageBox.Show($"Prestamo guardado correctamente.", ":::Biblioteca-Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
            }
        }
    }
}
