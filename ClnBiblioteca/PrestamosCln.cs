using CadBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnBiblioteca
{
    public class PrestamosCln
    {
        public static int insertar(Prestamos prestamos)
        {
            using (var db = new BibliotecaEntities())
            {
                db.Prestamos.Add(prestamos);
                db.SaveChanges();
                return prestamos.no_prestamo;
            }
        }
        public static int actualizar(Prestamos prestamos)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Prestamos.Find(prestamos.no_prestamo);
                actual.idEmpleados = prestamos.idEmpleados;
                actual.ciEstudiantes = prestamos.ciEstudiantes;
                actual.cod_libroLibros = prestamos.cod_libroLibros;
                actual.codDevoluciones = prestamos.codDevoluciones;
                actual.fechaprestamo = prestamos.fechaprestamo;
                actual.fechadevolucion = prestamos.fechadevolucion;
                return db.SaveChanges();
            }
        }

        public static int eliminar(int no_prestamoPrestamos, string usuario)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Prestamos.Find(no_prestamoPrestamos);
                actual.usuarioRegistro = usuario;
                actual.registroActivo = false;
                return db.SaveChanges();
            }
        }

        public static Prestamos get(int no_prestamoPrestamos)
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Prestamos.Find(no_prestamoPrestamos);
            }
        }

        public static List<Prestamos> listar(string parametro)
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Prestamos.Where(x => x.registroActivo == true).ToList();
            }
        }
    }
}
