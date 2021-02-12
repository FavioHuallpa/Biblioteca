using CadBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnBiblioteca
{
    public class EditorialesCln
    {
        public static int insertar(Editoriales editoriales)
        {
            using (var db = new BibliotecaEntities())
            {
                db.Editoriales.Add(editoriales);
                db.SaveChanges();
                return editoriales.id;
            }
        }
        public static int actualizar(Editoriales editoriales)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Editoriales.Find(editoriales.id);
                actual.nombre = editoriales.nombre;
                return db.SaveChanges();
            }
        }

        public static int eliminar(int idEditoriales, string usuario)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Editoriales.Find(idEditoriales);
                actual.usuarioRegistro = usuario;
                actual.registroActivo = false;
                return db.SaveChanges();
            }
        }

        public static Editoriales get(int idEditoriales)
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Editoriales.Find(idEditoriales);
            }
        }

        public static List<Editoriales> listar()
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Editoriales.Where(x => x.registroActivo == true).ToList();
            }
        }
    }
}
