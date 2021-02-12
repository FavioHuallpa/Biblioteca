using CadBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnBiblioteca
{
    public class AutoresCln
    {
        public static int insertar(Autores autores)
        {
            using (var db = new BibliotecaEntities())
            {
                db.Autores.Add(autores);
                db.SaveChanges();
                return autores.id;
            }
        }
        public static int actualizar(Autores autores)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Autores.Find(autores.id);
                actual.nombre = autores.nombre;
                actual.apellido = autores.apellido;
                actual.nacionalidad = autores.nacionalidad;
                return db.SaveChanges();
            }
        }

        public static int eliminar(int idAutores, string usuario)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Autores.Find(idAutores);
                actual.usuarioRegistro = usuario;
                actual.registroActivo = false;
                return db.SaveChanges();
            }
        }

        public static Autores get(int idAutores)
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Autores.Find(idAutores);
            }
        }

        public static List<Autores> listar()
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Autores.Where(x => x.registroActivo == true).ToList();
            }
        }
    }
}
