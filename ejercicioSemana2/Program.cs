using System;

class Program
{
    static void Main(string[] args)
    {
        var contexto = new UniversidadContext();

        var estudiante1 = new Estudiante
        {
            Nombre = "Juan Perez",
            Email = "juan@test.com",
            Activo = true
        };
        contexto.agregar(estudiante1);

        var estudiante2 = new Estudiante
        {
            Nombre = "Carlos Valderrama",
            Email = "carlos@test.com",
            Activo = false
        };
        contexto.agregar(estudiante2);

        Console.WriteLine($"Total de estudiantes registrados: {contexto.Estudiantes.Count}");

        var profesor1 = new Profesor
        {
            Nombre = "Ana Torres",
            Email = "ana.torres@uni.edu",
            Especializacion = "Física Cuántica"
        };
        contexto.Profesores.Add(profesor1);

        var profesor2 = new Profesor
        {
            Nombre = "Luis Mendoza",
            Email = "luis.mendoza@uni.edu",
            Especializacion = "Programación Orientada a Objetos"
        };
        contexto.Profesores.Add(profesor2);

        var profesor3 = new Profesor
        {
            Nombre = "Sofía Ramírez",
            Email = "sofia.ramirez@uni.edu",
            Especializacion = "Programación Funcional"
        };
        contexto.Profesores.Add(profesor3);

        Console.WriteLine($"Total de profesores registrados: {contexto.Profesores.Count}");

        contexto.Cursos.Add(new Curso { Id = 1, Nombre = "Programación I", UnidadesValorativas = 3 });
        contexto.Cursos.Add(new Curso { Id = 2, Nombre = "Matemáticas", UnidadesValorativas = 2 });

        contexto.ActualizarUnidadesValorativas(1, 4);
        contexto.ActualizarUnidadesValorativas(2, 5);

        var estudianteBuscado = contexto.ObtenerEstudiantePorEmail("juan@test.com");
        if (estudianteBuscado != null)
        {
            Console.WriteLine($"Estudiante encontrado: {estudianteBuscado.Nombre}");
        }

        var profesorBuscado = contexto.ObtenerProfesorPorEmail("sofia.ramirez@uni.edu");
        if (profesorBuscado != null)
        {
            Console.WriteLine($"Profesor encontrado: {profesorBuscado.Nombre} - {profesorBuscado.Especializacion}");
        }


        Console.WriteLine();
        Console.WriteLine("Profesores con especialización que contiene 'programación':");
        var resultado = contexto.ObtenerProfesoresPorEspecializacion("programación");

        foreach (var profesor in resultado)
        {
            Console.WriteLine($"{profesor.Nombre} - {profesor.Especializacion}");
        }
    }
}
