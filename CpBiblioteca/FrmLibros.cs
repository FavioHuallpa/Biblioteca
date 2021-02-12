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
    public partial class FrmLibros : Form
    {
        bool esNuevo;
        public FrmLibros()
        {
            InitializeComponent();
        }
        private void listar()
        {
            var lista = LibrosCln.listar(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["cod_libro"].Visible = false;
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
            if (lista.Count > 0) dgvLista.Columns["titulo"].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            gbxDatos.Enabled = true;
            gbxLista.Enabled = false;
            txtTitulo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            gbxDatos.Enabled = false;
            gbxLista.Enabled = true;
            limpiar();
            txtParametro.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Libros libros = new Libros();
                libros.titulo = txtTitulo.Text.Trim();
                libros.idEditoriales = Convert.ToInt32(txtEditorial.Text);
                libros.idAutores = Convert.ToInt32(txtAutor.Text);
                libros.usuarioRegistro = Util.usuario.usuario;

                if (esNuevo)
                {
                    libros.fechaRegistro = DateTime.Now;
                    libros.registroActivo = true;
                    LibrosCln.insertar(libros);
                }
                else
                {
                    var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
                    libros.cod_libro = Convert.ToInt32(row.Cells["cod_libro"].Value);
                    LibrosCln.actualizar(libros);
                }
                MessageBox.Show($"Libros guardado correctamente.", "::: Biblioteca - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
                btnCancelar.PerformClick();
            }
        }
        private bool validar()
        {
            bool esValido = true;
            erpTitulo.SetError(txtTitulo, string.Empty);

            if (string.IsNullOrEmpty(txtTitulo.Text)) { erpTitulo.SetError(txtTitulo, "El titulo es obligatorio"); esValido = false; }

            return esValido;
        }

        private void limpiar()
        {
            txtTitulo.Text = string.Empty;
            txtEditorial.Text = string.Empty;
            txtAutor.Text = string.Empty;
        }

        private void cargarDatos()
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            txtTitulo.Text = row.Cells["titulo"].Value.ToString();
            txtEditorial.Text = row.Cells["idEditoriales"].Value.ToString();
            txtAutor.Text = row.Cells["idAutores"].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            gbxDatos.Enabled = true;
            gbxLista.Enabled = false;
            cargarDatos();
            txtTitulo.Focus();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var row = dgvLista.Rows[dgvLista.CurrentRow.Index];
            var titulo = row.Cells["titulo"].Value.ToString();
            var msg = MessageBox.Show($"¿Está seguro que sea eliminar el libro con titulo {titulo}?", "::: Biblioteca - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == msg)
            {
                LibrosCln.eliminar(Convert.ToInt32(row.Cells["cod_libro"].Value), Util.usuario.usuario);
                MessageBox.Show($"Libro eliminado.", "::: Biblioteca - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
            }
        }
    }
}
