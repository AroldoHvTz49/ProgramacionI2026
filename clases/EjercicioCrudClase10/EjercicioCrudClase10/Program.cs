using EjercicioCrudClase10;
using Microsoft.Data.Sqlite;

BDAlumno bd = new BDAlumno("Data Source=\"C:\\Users\\arowa\\Downloads\\Progra1A.db\"");


string opcion = "";
do
{
    Console.WriteLine("1. Crear Alumno");
    Console.WriteLine("2. Listar Alumnos");
    Console.WriteLine("3. Buscar Alumno");
    Console.WriteLine("4. Eliminar Alumno");
    Console.WriteLine("5. Actualizar Alumno");
    Console.WriteLine("6. Salir");
    Console.WriteLine("Elija una opcion");

    opcion = Console.ReadLine();

    if (opcion == "1")
    {
        Alumno alumno = new Alumno();
        Console.WriteLine("Ingrese el Carnet");
        alumno.Carnet = Console.ReadLine();
        Console.WriteLine("Ingrese los Nombres");
        alumno.Nombres = Console.ReadLine();
        Console.WriteLine("Ingrese el Apellidos");
        alumno.Apellidos = Console.ReadLine();
        Console.WriteLine("Ingrese el Telefono");
        alumno.Telefono = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el DPI");
        alumno.DPI = int.Parse(Console.ReadLine());
        bd.Crear(alumno);
    }

    if (opcion == "2")
    {
        List<Alumno> alumnos = bd.Get();
        foreach (var alumno in alumnos)
        {
            Console.WriteLine("El Carnet: " + alumno.Carnet + " El nombre: " + alumno.Nombres + " El apellido: " + alumno.Apellidos + " El telefono: " + alumno.Telefono + " El DPI: " + alumno.DPI);
        }
    }

    if (opcion == "3")
    {
        Console.WriteLine("Ingrese el Carnet del Alumno a Buscar");
        string carnet = Console.ReadLine();
        Alumno alumno = bd.Get(carnet);
        if (alumno != null)
        {
            Console.WriteLine("El Carnet: " + alumno.Carnet + " El nombre: " + alumno.Nombres + " El apellido: " + alumno.Apellidos + " El telefono: " + alumno.Telefono + " El DPI: " + alumno.DPI);
        }
        else
        {
            Console.WriteLine("Alumno no encontrado");
        }
    }

    if (opcion == "4")
    {
        Console.WriteLine("Ingrese el Carnet del Alumno a Eliminar");
        string carnet = Console.ReadLine();
        bd.Eliminar(carnet);
    }

    if (opcion == "5")
    {
        Alumno alumno = new Alumno();
        Console.WriteLine("Ingrese el Carnet del Alumno a Actualizar");
        alumno.Carnet = Console.ReadLine();
        Console.WriteLine("Ingrese los Nombres");
        alumno.Nombres = Console.ReadLine();
        Console.WriteLine("Ingrese el Apellidos");
        alumno.Apellidos = Console.ReadLine();
        Console.WriteLine("Ingrese el Telefono");
        alumno.Telefono = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el DPI");
        alumno.DPI = int.Parse(Console.ReadLine());
        bd.Update(alumno);
    }

} while (opcion != "6");
