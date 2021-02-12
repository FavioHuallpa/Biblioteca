using CadBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnBiblioteca
{
    public class LibrosCln
    {
        public static int insertar(Libros libros)
        {
            using (var db = new BibliotecaEntities())
            {
                db.Libros.Add(libros);
                db.SaveChanges();
                return libros.cod_libro;
            }
        }
        public static int actualizar(Libros libros)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Libros.Find(libros.cod_libro);
                actual.titulo = libros.titulo;
                actual.idEditoriales = libros.idEditoriales;
                actual.idAutores = libros.idAutores;
                return db.SaveChanges();
            }
        }

        public static int eliminar(int cod_libroLibros, string usuario)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Libros.Find(cod_libroLibros);
                actual.usuarioRegistro = usuario;
                actual.registroActivo = false;
                return db.SaveChanges();
            }
        }

        public static Libros get(int cod_libroLibros)
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Libros.Find(cod_libroLibros);
            }
        }

        public static List<Libros> listar(string parametro)
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Libros.Where(x => x.registroActivo == true).ToList();
            }
        }
    }
}
