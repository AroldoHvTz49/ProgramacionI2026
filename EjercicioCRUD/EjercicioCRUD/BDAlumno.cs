using EjercicioCRUD;
using Dapper;
using Npgsql;

namespace EjercicioCRUD;

public class BDAlumno
{

    private readonly string _connectionString;

    public BDAlumno(string connectionString)
    {
        _connectionString = connectionString;
    }

    private NpgsqlConnection ObtenerConexion()
    {
        return new NpgsqlConnection(_connectionString);
    }

    public List<Alumno> Get()
    {
        List<Alumno> alumnos = new List<Alumno>();
        using var connection = ObtenerConexion();
        try
        {
            connection.Open();
            string sql = "SELECT id, carnet, nombres, apellidos, telefono, dpi FROM alumno";
            alumnos = connection.Query<Alumno>(sql).ToList();
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine("Error al listar: " + ex.Message);
        }
        return alumnos;
    }

    public Alumno Get(string carnet)
    {
        Alumno alumno = null;
        using var connection = ObtenerConexion();
        try
        {
            connection.Open();
            string sql = "SELECT id, carnet, nombres, apellidos, telefono, dpi FROM alumno WHERE carnet = @Carnet";
            alumno = connection.QueryFirstOrDefault<Alumno>(sql, new { Carnet = carnet });
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine("Error al buscar: " + ex.Message);
        }
        return alumno;
    }

    public void Crear(Alumno alumno)
    {
        using var connection = ObtenerConexion();
        try
        {
            connection.Open();
            string sql = "INSERT INTO alumno(carnet, nombres, apellidos, telefono, dpi) VALUES (@Carnet, @Nombres, @Apellidos, @Telefono, @DPI)";
            connection.Execute(sql, alumno);
            Console.WriteLine("El alumno ha sido creado exitosamente en Supabase.");
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine("Error al crear: " + ex.Message);
        }
    }

    public void Eliminar(string carnet)
    {
        using var connection = ObtenerConexion();
        try
        {
            connection.Open();
            string sql = "DELETE FROM alumno WHERE carnet = @Carnet";
            connection.Execute(sql, new { Carnet = carnet });
            Console.WriteLine("El alumno ha sido eliminado.");
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine("Error al eliminar: " + ex.Message);
        }
    }

    public void Update(Alumno alumno)
    {
        using var connection = ObtenerConexion();
        try
        {
            connection.Open();
            string sql = "UPDATE alumno SET nombres=@Nombres, apellidos=@Apellidos, telefono=@Telefono, dpi=@DPI WHERE carnet=@Carnet";
            connection.Execute(sql, alumno);
            Console.WriteLine("El alumno ha sido modificado.");
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine("Error al actualizar: " + ex.Message);
        }
    }
}