using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UniversidadContext
{
    public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    public List<Profesor> Profesores { get; set; } = new List<Profesor>();
    public List<Curso> Cursos { get; set; } = new List<Curso>();

    public void agregar(Estudiante estudiante)
    {
        estudiante.Id = Estudiantes.Count + 1;
        Estudiantes.Add(estudiante);
    }

    public bool ActualizarUnidadesValorativas(int cursoId, int nuevasUnidades)
    {
        if (nuevasUnidades < 1 || nuevasUnidades > 4)
        {
            Console.WriteLine("Las unidades valorativas deben estar entre 1 y 4.");
            return false;
        }

        var curso = Cursos.FirstOrDefault(c => c.Id == cursoId);
        if (curso == null)
        {
            Console.WriteLine("No se encontró un curso con ese ID.");
            return false;
        }

        curso.UnidadesValorativas = nuevasUnidades;
        Console.WriteLine($"El curso '{curso.Nombre}' fue actualizado a {nuevasUnidades} unidades valorativas.");
        return true;
    }

    public Estudiante ObtenerEstudiantePorEmail(string email)
    {
        return Estudiantes.FirstOrDefault(e =>
            e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public Profesor ObtenerProfesorPorEmail(string email)
    {
        return Profesores.FirstOrDefault(p =>
            p.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }



    public List<Profesor> ObtenerProfesoresPorEspecializacion(string especializacion)
    {
        return Profesores
            .Where(p => p.Especializacion != null &&
                        p.Especializacion.Contains(especializacion, StringComparison.OrdinalIgnoreCase))
            .OrderBy(p => p.Nombre)
            .ToList();
    }
    
}