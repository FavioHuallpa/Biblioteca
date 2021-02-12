using CadBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnBiblioteca
{
    public class EstudiantesCln
    {
        public static int insertar(Estudiantes estudiantes)
        {
            using (var db = new BibliotecaEntities())
            {
                db.Estudiantes.Add(estudiantes);
                db.SaveChanges();
                return estudiantes.ci;
            }
        }
        public static int actualizar(Estudiantes estudiantes)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Estudiantes.Find(estudiantes.ci);
                actual.nombre = estudiantes.nombre;
                actual.apellido = estudiantes.apellido;
                actual.direccion = estudiantes.direccion;
                actual.edad = estudiantes.edad;
                actual.carrera = estudiantes.carrera;
                actual.usuarioRegistro = estudiantes.usuarioRegistro;
                return db.SaveChanges();
            }
        }

        public static int eliminar(int ciEstudiantes, string usuario)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Estudiantes.Find(ciEstudiantes);
                actual.usuarioRegistro = usuario;
                actual.registroActivo = false;
                return db.SaveChanges();
            }
        }

        public static Estudiantes get(int ciEstudiantes)
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Estudiantes.Find(ciEstudiantes);
            }
        }

        public static List<Estudiantes> listar()
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Estudiantes.Where(x => x.registroActivo == true).ToList();
            }
        }
       public static List<paEstudiantesListar_Result> listarPa(string parametro)
       {
            using (var db = new BibliotecaEntities())
            {

                return db.paEstudiantesListar(parametro).ToList();
            }
        }
    }
}
