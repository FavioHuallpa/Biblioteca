﻿
namespace CpBiblioteca
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.c1Ribbon1 = new C1.Win.C1Ribbon.C1Ribbon();
            this.ribbonApplicationMenu1 = new C1.Win.C1Ribbon.RibbonApplicationMenu();
            this.ribbonConfigToolBar1 = new C1.Win.C1Ribbon.RibbonConfigToolBar();
            this.ribbonQat1 = new C1.Win.C1Ribbon.RibbonQat();
            this.ribbonTab1 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup1 = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnEstudiantes = new C1.Win.C1Ribbon.RibbonButton();
            this.btnAutores = new C1.Win.C1Ribbon.RibbonButton();
            this.btnEmpleados = new C1.Win.C1Ribbon.RibbonButton();
            this.btmUsuario = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTab2 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup2 = new C1.Win.C1Ribbon.RibbonGroup();
            this.btmPrestamos = new C1.Win.C1Ribbon.RibbonButton();
            this.btmLibros = new C1.Win.C1Ribbon.RibbonButton();
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Ribbon1
            // 
            this.c1Ribbon1.ApplicationMenuHolder = this.ribbonApplicationMenu1;
            this.c1Ribbon1.ConfigToolBarHolder = this.ribbonConfigToolBar1;
            this.c1Ribbon1.Name = "c1Ribbon1";
            this.c1Ribbon1.QatHolder = this.ribbonQat1;
            this.c1Ribbon1.Tabs.Add(this.ribbonTab1);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab2);
            // 
            // ribbonApplicationMenu1
            // 
            this.ribbonApplicationMenu1.LargeImage = global::CpBiblioteca.Properties.Resources.iconfinder_weather_26_26828251;
            this.ribbonApplicationMenu1.Name = "ribbonApplicationMenu1";
            // 
            // ribbonConfigToolBar1
            // 
            this.ribbonConfigToolBar1.Name = "ribbonConfigToolBar1";
            // 
            // ribbonQat1
            // 
            this.ribbonQat1.Name = "ribbonQat1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Groups.Add(this.ribbonGroup1);
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "CATALOGOS";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Items.Add(this.btnEstudiantes);
            this.ribbonGroup1.Items.Add(this.btnAutores);
            this.ribbonGroup1.Items.Add(this.btnEmpleados);
            this.ribbonGroup1.Items.Add(this.btmUsuario);
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "Group";
            // 
            // btnEstudiantes
            // 
            this.btnEstudiantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstudiantes.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEstudiantes.LargeImage")));
            this.btnEstudiantes.Name = "btnEstudiantes";
            this.btnEstudiantes.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnEstudiantes.SmallImage")));
            this.btnEstudiantes.Text = "Estudiantes";
            this.btnEstudiantes.ToolTip = "Lista de estudiantes";
            this.btnEstudiantes.Click += new System.EventHandler(this.btnEstudiantes_Click);
            // 
            // btnAutores
            // 
            this.btnAutores.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutores.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAutores.LargeImage")));
            this.btnAutores.Name = "btnAutores";
            this.btnAutores.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAutores.SmallImage")));
            this.btnAutores.Text = "Autores";
            this.btnAutores.ToolTip = "Lista de autores";
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleados.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmpleados.LargeImage")));
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnEmpleados.SmallImage")));
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.ToolTip = "Lista de empleados";
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btmUsuario
            // 
            this.btmUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmUsuario.LargeImage = ((System.Drawing.Image)(resources.GetObject("btmUsuario.LargeImage")));
            this.btmUsuario.Name = "btmUsuario";
            this.btmUsuario.SmallImage = ((System.Drawing.Image)(resources.GetObject("btmUsuario.SmallImage")));
            this.btmUsuario.Text = "Usuario";
            this.btmUsuario.Click += new System.EventHandler(this.btmUsuario_Click);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Groups.Add(this.ribbonGroup2);
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Text = "VENTAS";
            // 
            // ribbonGroup2
            // 
            this.ribbonGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonGroup2.Items.Add(this.btmPrestamos);
            this.ribbonGroup2.Items.Add(this.btmLibros);
            this.ribbonGroup2.Name = "ribbonGroup2";
            this.ribbonGroup2.Text = "Un libro es un sueño";
            // 
            // btmPrestamos
            // 
            this.btmPrestamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmPrestamos.Name = "btmPrestamos";
            this.btmPrestamos.SmallImage = ((System.Drawing.Image)(resources.GetObject("btmPrestamos.SmallImage")));
            this.btmPrestamos.Text = "Prestamos";
            this.btmPrestamos.Click += new System.EventHandler(this.btmPrestamos_Click);
            // 
            // btmLibros
            // 
            this.btmLibros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmLibros.Name = "btmLibros";
            this.btmLibros.SmallImage = ((System.Drawing.Image)(resources.GetObject("btmLibros.SmallImage")));
            this.btmLibros.Tag = "Libros";
            this.btmLibros.Text = "Libros";
            this.btmLibros.ToolTip = "Lista de libros";
            this.btmLibros.Click += new System.EventHandler(this.btmLibros_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CpBiblioteca.Properties.Resources.biblio;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 484);
            this.Controls.Add(this.c1Ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Biblioteca-Principal :::";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Ribbon.C1Ribbon c1Ribbon1;
        private C1.Win.C1Ribbon.RibbonApplicationMenu ribbonApplicationMenu1;
        private C1.Win.C1Ribbon.RibbonConfigToolBar ribbonConfigToolBar1;
        private C1.Win.C1Ribbon.RibbonQat ribbonQat1;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab1;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup1;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab2;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup2;
        private C1.Win.C1Ribbon.RibbonButton btnEstudiantes;
        private C1.Win.C1Ribbon.RibbonButton btnAutores;
        private C1.Win.C1Ribbon.RibbonButton btnEmpleados;
        private C1.Win.C1Ribbon.RibbonButton btmUsuario;
        private C1.Win.C1Ribbon.RibbonButton btmPrestamos;
        private C1.Win.C1Ribbon.RibbonButton btmLibros;
    }
}