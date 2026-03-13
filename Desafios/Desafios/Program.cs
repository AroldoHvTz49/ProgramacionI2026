static void Desafio1()
{
    Console.WriteLine("Ingrese ingresos de los ultimos 3 meses");
    Console.WriteLine("Ingrese ingresos del primer mes \n");
    var mes1 = Console.ReadLine();

    Console.WriteLine("\nIngrese ingresos del segundo mes \n");
    var mes2 = Console.ReadLine();

    Console.WriteLine("\nIngrese ingresos del tercer mes \n");
    var mes3 = Console.ReadLine();

    Console.WriteLine("\nIngrese nombre de usuario \n");
    var nombre = Console.ReadLine();


    Console.WriteLine("\nHola Usuario: " + nombre);
    double suma = double.Parse(mes1) + double.Parse(mes2) + double.Parse(mes3);
    Console.WriteLine("\nGanaste en 3 meses: Q" + suma);
    double promedio = suma / 3;
    Console.WriteLine("\nPromediaste en 3 meses: Q" + promedio);

    Console.WriteLine("Desafio 1 termino \n");

}

static void Desafio2()
{
    Console.WriteLine("Ingresa el primer numero");
    int numero1 = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingresa el segundo numero");
    int numero2 = int.Parse(Console.ReadLine());

    int suma = numero1 + numero2;
    int multi = numero1 * numero2;
    int divi = numero1 / numero2;
    int resta = numero1 - numero2;

    Console.WriteLine("Suma: " + suma);
    Console.WriteLine("Multi: " + multi);
    Console.WriteLine("Divi: " + divi);
    Console.WriteLine("Resta: " + resta);

    Console.WriteLine("Desafio 2 termino \n");
}
static void Desafio3()
{
    try
    {
        Console.WriteLine("Ingrese un numero");
        string numero = Console.ReadLine();
        //Convertimos a double
        double numero1 = double.Parse(numero);
        Console.WriteLine("Ingrese otro numero");
        numero = Console.ReadLine();
        double numero2 = double.Parse(numero);
        double suma = numero1 + numero2;
        Console.WriteLine("La suma es: " + suma);
    }
    catch (Exception ex)
    {
        Console.WriteLine("La aplicacion fallo debido a  " + ex.Message);
    }
    finally
    {

    }
    Console.WriteLine("Desafio 3 termino \n");
}

static void Desafio4()
{
    Console.WriteLine("Registro de Usuario");

    Console.WriteLine("Crea un nombre de usuario");
    string nuevoUsuario = Console.ReadLine();

    Console.WriteLine("Crea una contraseña:");
    string nuevaPassword = Console.ReadLine();

    Console.WriteLine("\nInicio de Sesion");

    Console.WriteLine("Ingrese su usuario:");
    string usuario = Console.ReadLine();

    Console.WriteLine("Ingrese su contraseña:");
    string password = Console.ReadLine();

    if (usuario == nuevoUsuario && password == nuevaPassword)
    {
        Console.WriteLine("Inicio de sesion correcto, bienvenido " + usuario);
    }
    else
    {
        Console.WriteLine("Usuario o contraseña incorrectos.");
    }

    Console.WriteLine("Desafio 4 termino \n");
}


int record = 1000;
string jugadorRecord = "Aroldo";
void Desafio5(int puntaje, string jugador)
{
    if (puntaje > record)
    {
        record = puntaje;
        jugadorRecord = jugador;

        Console.WriteLine("El puntaje mas alto ahora es de: " + record);
        Console.WriteLine("Y fue alcanzado por: " + jugadorRecord);
    }
    else
    {
        Console.WriteLine("El puntaje mas alto sigue siendo de " + record + " y no se ha podido superar");
        Console.WriteLine("Y aun esta en el poder de: " + jugadorRecord);
    }

    Console.WriteLine("Desafio 5 termino \n");
}


//Llamar a los metodos
Desafio1();
Desafio2();
Desafio3();
Desafio4();
Desafio5(800, "Fer");
Desafio5(1800, "Eve");
Desafio5(1500, "Chinchi");

