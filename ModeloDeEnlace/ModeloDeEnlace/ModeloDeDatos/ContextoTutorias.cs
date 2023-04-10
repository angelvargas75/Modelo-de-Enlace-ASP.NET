using System.Data.Entity;

namespace ModeloDeEnlace.ModeloDeDatos
{
    public class ContextoTutorias : DbContext
    {
        public ContextoTutorias() : base("conStrContext")
        {
        }

        public DbSet<Profesor> Profesors { get; set; }
    }
}