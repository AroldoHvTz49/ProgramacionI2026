using EjercicioCRUD;
using Npgsql;


string connectionString = "Server=db.mhuqtduxjggfkukapwcz.supabase.co;Database=postgres;User Id=postgres;Password=G3F4@TbNpv7Xzf8;Port=5432;";


ProbarConexionBD(connectionString);

BDAlumno bd = new BDAlumno(connectionString);

string opcion = "";

do
{
    Console.WriteLine("\nSeleccione una opcion:");
    Console.WriteLine("1. Listar alumnos");
    Console.WriteLine("2. Buscar alumno por carnet");
    Console.WriteLine("3. Crear nuevo alumno");
    Console.WriteLine("4. Eliminar alumno");
    Console.WriteLine("5. Actualizar alumno");
    Console.WriteLine("6. Salir");

    opcion = Console.ReadLine();

    if (opcion == "1")
    {
        List<Alumno> alumnos = bd.Get();
        foreach (Alumno alumno in alumnos)
        {
            Console.WriteLine("Carnet: " + alumno.Carnet + " Nombres: " + alumno.Nombres + " Apellidos: " + alumno.Apellidos + " DPI: " + alumno.DPI + " Telefono: " + alumno.Telefono);
        }
    }
    if (opcion == "2")
    {
        Console.WriteLine("Ingrese el carnet del alumno a buscar:");
        string carnet = Console.ReadLine();
        Alumno alumno = bd.Get(carnet);
        if (alumno != null)
        {
            Console.WriteLine("Alumno encontrado: Carnet: " + alumno.Carnet + " Nombres: " + alumno.Nombres + " Apellidos: " + alumno.Apellidos + " DPI: " + alumno.DPI + " Telefono: " + alumno.Telefono);
        }
        else
        {
            Console.WriteLine("Alumno no encontrado");
        }
    }
    if (opcion == "3")
    {
        Console.WriteLine("Ingrese el carnet del nuevo alumno:");
        string carnet = Console.ReadLine();
        Console.WriteLine("Ingrese los nombres del nuevo alumno:");
        string nombres = Console.ReadLine();
        Console.WriteLine("Ingrese los apellidos del nuevo alumno:");
        string apellidos = Console.ReadLine();
        Console.WriteLine("Ingrese el DPI del nuevo alumno:");
        long dpi = long.Parse(Console.ReadLine()); // Cambiado a long
        Console.WriteLine("Ingrese el telefono del nuevo alumno:");
        long telefono = long.Parse(Console.ReadLine()); // Cambiado a long

        Alumno NuevosAlumnos = new Alumno
        {
            Carnet = carnet,
            Nombres = nombres,
            Apellidos = apellidos,
            DPI = dpi,
            Telefono = telefono,
        };

        bd.Crear(NuevosAlumnos);
    }
    if (opcion == "4")
    {
        Console.WriteLine("Ingrese el carnet del alumno a eliminar:");
        string carnet = Console.ReadLine();
        bd.Eliminar(carnet);
    }
    if (opcion == "5")
    {
        Console.WriteLine("Ingrese el carnet del alumno a actualizar:");
        string carnet = Console.ReadLine();
        Console.WriteLine("Ingrese los nuevos nombres del alumno:");
        string nombres = Console.ReadLine();
        Console.WriteLine("Ingrese los nuevos apellidos del alumno:");
        string apellidos = Console.ReadLine();
        Console.WriteLine("Ingrese el nuevo DPI del alumno:");
        long dpi = long.Parse(Console.ReadLine()); 
        Console.WriteLine("Ingrese el nuevo telefono del alumno:");
        long telefono = long.Parse(Console.ReadLine());

        Alumno AlumnoActualizado = new Alumno
        {
            Carnet = carnet,
            Nombres = nombres,
            Apellidos = apellidos,
            DPI = dpi,
            Telefono = telefono,
        };
        bd.Update(AlumnoActualizado);
    }
}
while (opcion != "6");

static void ProbarConexionBD(string connectionString)
{
    try
    {
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();
        Console.WriteLine("¡Conectado exitosamente a Supabase!");
        connection.Close();
    }
    catch (NpgsqlException ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Conexion a Supabase fallo");
    }
}