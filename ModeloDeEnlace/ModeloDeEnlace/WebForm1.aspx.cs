using ModeloDeEnlace.ModeloDeDatos;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ModeloDeEnlace
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            using (var bd = new ContextoTutorias())
            {
                Database.SetInitializer<ContextoTutorias>(new IniciarBaseDeDatos());
            }
        }

        public IQueryable<Profesor> ObtenerProfesores()
        {
            ContextoTutorias bd = new ContextoTutorias();
            var consulta = bd.Profesors;
            return consulta;
        }


        public void ModificarProfesores(int IdProfesor)
        {

            using (ContextoTutorias db = new ContextoTutorias())
            {
                ModeloDeEnlace.ModeloDeDatos.Profesor objProfesor = null;
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                objProfesor = db.Profesors.Find(IdProfesor);
                if (objProfesor == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("El elemento con id {0} no fue encontrado", IdProfesor));
                    return;
                }
                TryUpdateModel(objProfesor);
                // Se elimina la siguiente linea del if porque se añadieron los Annotation [Required] a las propiedades
                // Nombre y Apellidos de la Entidad Profesor
                //if (string.IsNullOrEmpty(objProfesor.Nombre) || string.IsNullOrEmpty(objProfesor.Apellidos)) return;
                if (ModelState.IsValid)
                {
                    // Save changes here, e.g. MyDataLayer.SaveChanges();
                    db.SaveChanges();
                }
            }
        }


        public void BorrarProfesores(int IdProfesor)
        {
            using (ContextoTutorias db = new ContextoTutorias())
            {
                var profesor = new Profesor { IdProfesor = IdProfesor };
                db.Entry(profesor).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", string.Format("El elemento con id {0} no fue encontrado", IdProfesor));
                }
            }
        }


        public void InsertarProfesor()
        {
            using (ContextoTutorias db = new ContextoTutorias())
            {
                Profesor objProfesor = new Profesor();
                TryUpdateModel(objProfesor);
                // Se elimina la siguiente linea del if porque se añadieron los Annotation [Required] a las propiedades
                // Nombre y Apellidos de la Entidad Profesor
                //if (string.IsNullOrEmpty(objProfesor.Nombre) || string.IsNullOrEmpty(objProfesor.Apellidos)) return;

                // Guardar cambios
                db.Profesors.Add(objProfesor);
                db.SaveChanges();

                // Recargar el GridView
                gvProfes.DataBind();
            }
        }
    }
}