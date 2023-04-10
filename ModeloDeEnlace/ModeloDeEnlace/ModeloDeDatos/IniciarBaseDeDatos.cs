using System.Collections.Generic;
using System.Data.Entity;

namespace ModeloDeEnlace.ModeloDeDatos
{
    public class IniciarBaseDeDatos : DropCreateDatabaseIfModelChanges<ContextoTutorias>
    {
        protected override void Seed(ContextoTutorias context)
        {
            ObtenerProfesores().ForEach(p => context.Profesors.Add(p));
        }

        private static List<Profesor> ObtenerProfesores()
        {
            var profesores = new List<Profesor>
            {
                new Profesor
                {
                    IdProfesor = 1,
                    Nombre = "Fco Javier",
                    Apellidos = "Ceballos Sierra"
                },
                new Profesor
                {
                    IdProfesor = 2,
                    Nombre = "Inmaculada",
                    Apellidos = "Rodriguez Santiago"
                },
                new Profesor
                {
                    IdProfesor = 3,
                    Nombre = "Concha",
                    Apellidos = "Batanero Ochaita"
                },
                new Profesor
                {
                    IdProfesor = 4,
                    Nombre = "Maria del Mar",
                    Apellidos = "Lendinez Chica"
                },
                new Profesor
                {
                    IdProfesor = 5,
                    Nombre = "Martin",
                    Apellidos = "Knoblauch Revuelta"
                }
            };
            return profesores;
        }
    }
}