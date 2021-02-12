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
    public partial class FrmPrincipal : Form
    {
        FrmAutenticacion frmAutenticacion;
        public FrmPrincipal(FrmAutenticacion frmAutenticacion)
        {
            this.frmAutenticacion = frmAutenticacion;
            InitializeComponent();
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            new FrmEstudiantes().ShowDialog();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            new FrmEmpleados().ShowDialog();
        }

        private void btmUsuario_Click(object sender, EventArgs e)
        {
           // Usuario usuario = new Usuario();
            //usuario.usuario = "fhuallpa";
            //usuario.clave = Util.Encrypt("123456");
           // usuario.idEmpleados = 1;
           // usuario.usuarioRegistro = "usrBiblioteca";
           // usuario.fechaRegistro = DateTime.Now;
           // usuario.registroActivo = true;
            //UsuarioCln.insertar(usuario);
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAutenticacion.Visible = true;

            }

        private void btmPrestamos_Click(object sender, EventArgs e)
        {
            new FrmPrestamos().ShowDialog();
        }

        private void btmLibros_Click(object sender, EventArgs e)
        {
            new FrmLibros().ShowDialog();
        }
    }
}
