using CadBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnBiblioteca
{
    public class EmpleadosCln
    {
        public static int insertar(Empleados empleados)
        {
            using (var db = new BibliotecaEntities())
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return empleados.id;
            }
        }
        public static int actualizar(Empleados empleados)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Empleados.Find(empleados.id);
                actual.nombre = empleados.nombre;
                actual.apellido = empleados.apellido;
                actual.email = empleados.email;
                actual.telfono = empleados.telfono;
                actual.direccion = empleados.direccion;
                return db.SaveChanges();
            }
        }

        public static int eliminar(int idEmpleados, string usuario)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Empleados.Find(idEmpleados);
                actual.usuarioRegistro = usuario;
                actual.registroActivo = false;
                return db.SaveChanges();
            }
        }

        public static Empleados get(int idEmpleados)
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Empleados.Find(idEmpleados);
            }
        }

        public static List<Empleados> listar(string parametro)
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Empleados.Where(x => x.registroActivo == true).ToList();
            }
        }
    }
}
