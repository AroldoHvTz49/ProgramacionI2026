using Clase9;
using Microsoft.Data.Sqlite;

ProbarConexionBD();

BDAlumno bd = new BDAlumno("Data Source=\"C:\\Users\\arowa\\Downloads\\Progra1A.db\"");

//Console.WriteLine(bd.Get());
Alumno pedro = new Alumno
{
    Carnet = "1203",
    Nombres = "Pedro",
    Apellidos = "Vasquez",
    DPI = 230302303,
    Telefono = 20123932,
};
bd.Crear(pedro);
//bd.Eliminar(pedro.Carnet);
pedro.Nombres = "Pedro";
pedro.Apellidos = "Perez";
pedro.DPI = 40934043;
pedro.Telefono = 40394039;
bd.Update(pedro);

Alumno pedroModificado = bd.Get(pedro.Carnet);
Console.WriteLine(pedroModificado.Carnet + " " + pedroModificado.Nombres + " " + pedroModificado.DPI + " " + pedroModificado.Telefono);



static void ProbarConexionBD()
{
    try
    {
        using SqliteConnection connection = new SqliteConnection("Data Source=\"C:\\Users\\arowa\\Downloads\\Progra1A.db\"");
        connection.Open();
        Console.WriteLine("Conectado");
        connection.Close();
    }
    catch (SqliteException ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Conexion fallo");
    }
}
