using CadBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnBiblioteca
{
    public class DevolucionesCln
    {
        public static int insertar(Devoluciones devoluciones)
        {
            using (var db = new BibliotecaEntities())
            {
                db.Devoluciones.Add(devoluciones);
                db.SaveChanges();
                return devoluciones.cod;
            }
        }
        public static int actualizar(Devoluciones devoluciones)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Devoluciones.Find(devoluciones.cod);
                actual.fecha = devoluciones.fecha;
                return db.SaveChanges();
            }
        }

        public static int eliminar(int codDevoluciones, string usuario)
        {
            using (var db = new BibliotecaEntities())
            {
                var actual = db.Devoluciones.Find(codDevoluciones);
                actual.usuarioRegistro = usuario;
                actual.registroActivo = false;
                return db.SaveChanges();
            }
        }

        public static Devoluciones get(int codDevoluciones)
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Devoluciones.Find(codDevoluciones);
            }
        }

        public static List<Devoluciones> listar()
        {
            using (var db = new BibliotecaEntities())
            {

                return db.Devoluciones.Where(x => x.registroActivo == true).ToList();
            }
        }
    }
}
