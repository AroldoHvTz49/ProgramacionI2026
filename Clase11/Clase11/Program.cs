using Clase11;
using Microsoft.Data.Sqlite;

BDAlumno bd = new BDAlumno("Data Source=\"C:\\Users\\arowa\\Downloads\\Progra1A.db\"");


static Alumno pedirDatos(string carnet)
{
    Alumno alumno = new Alumno();
    alumno.Carnet = carnet;
    Console.WriteLine("Ingrese los Nombres");
    alumno.Nombres = Console.ReadLine();
    Console.WriteLine("Ingrese el Apellidos");
    alumno.Apellidos = Console.ReadLine();
    Console.WriteLine("Ingrese el Telefono");
    alumno.Telefono = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el DPI");
    alumno.DPI = long.Parse(Console.ReadLine());
    return alumno;
}

string opcion = "";
do
{
    Console.WriteLine("1. Crear Alumno");
    Console.WriteLine("2. Listar Alumnos");
    Console.WriteLine("3. Actualizar");
    Console.WriteLine("4. Carga masiva desde directorio");
    Console.WriteLine("Elija una opcion");
    opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1": // Crear alumno
            Alumno alumno = new Alumno();
            Console.WriteLine("Ingrese el Carnet");
            alumno.Carnet = Console.ReadLine();
            alumno = pedirDatos(alumno.Carnet);

            bd.Crear(alumno);
            break;
        case "2": //Listar alumnos
            List<Alumno> alumnos = bd.Listar();
            foreach (Alumno a in alumnos)
            {
                Console.WriteLine("{0}: {1}-{2}", a.Carnet, a.Nombres, a.Apellidos);
            }
            break;
        case "3": //Actualizar
            Console.WriteLine("Ingrese el carnet que desea modificar");
            string carnet = Console.ReadLine();
            Alumno encontrado = bd.Obtener(carnet);
            if (encontrado == null)
            {
                Console.WriteLine("El alumno no existe");
            }
            else
            {
                try
                {
                    encontrado = pedirDatos(encontrado.Carnet);
                    bd.Actualizar(encontrado);
                    Console.WriteLine("Los datos han sido actualizados");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrio un error al ingresar los datos" + e.Message);
                }
            }
            break;
        case "4": //Carga masiva
            try
            {
                Console.WriteLine("Ingrese la ruta donde se encuentra su archivo");
                string ruta = Console.ReadLine();
                string[] archivos = Directory.GetFiles(ruta);

                Console.WriteLine("Archivos encontrados");
                for (int i = 0; i < archivos.Length; i++)
                {
                    Console.WriteLine("numero: " + i + " " + archivos[i]);
                }

                Console.WriteLine("Ingrese el indice del archivo que desea cargar");
                int archivoElegido = int.Parse(Console.ReadLine());
                string[] lineas = System.IO.File.ReadAllLines(archivos[archivoElegido]);
                for (int i = 0; i < lineas.Length; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }
                    string[] valores = lineas[i].Split(",");
                    Alumno alumnoActual = new Alumno
                    {
                        Carnet = valores[0],
                        Nombres = valores[1],
                        Apellidos = valores[2],
                        Telefono = int.Parse(valores[3]),
                        DPI = long.Parse(valores[4])
                    };
                    bd.Crear(alumnoActual);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrio un error al cargar los datos de forma masiva " + e.Message);
            }

            break;
        default:
            Console.WriteLine("No entiendo ese comando");
            break;
    }
} while (opcion != "5");