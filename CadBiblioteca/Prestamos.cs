//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CadBiblioteca
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prestamos
    {
        public int no_prestamo { get; set; }
        public int idEmpleados { get; set; }
        public int ciEstudiantes { get; set; }
        public int cod_libroLibros { get; set; }
        public int codDevoluciones { get; set; }
        public string fechaprestamo { get; set; }
        public string fechadevolucion { get; set; }
        public string usuarioRegistro { get; set; }
        public Nullable<System.DateTime> fechaRegistro { get; set; }
        public Nullable<bool> registroActivo { get; set; }
    
        public virtual Devoluciones Devoluciones { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Libros Libros { get; set; }
        public virtual Estudiantes Estudiantes { get; set; }
    }
}
