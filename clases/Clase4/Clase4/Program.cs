using Microsoft.VisualBasic;

static void Valores()
{
    Console.WriteLine("Ingrese ingresos de los ultimos 3 meses \n");

    Console.WriteLine("\nIngrese ingresos del primer mes \n");
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

}

static void temperatura()
{ 
    Console.WriteLine("Ingrese la temperatura actual");

    string temperatura = Console.ReadLine();
    int numTemperatura = int.Parse(temperatura);

    if(numTemperatura < 20)
    {
        Console.WriteLine("Abrigate bien");
    }
    if (numTemperatura == 20)
    {
        Console.WriteLine("La temperatura es ideal");
    }
    if(numTemperatura > 20)
    {
        Console.WriteLine("No te abrigues tanto");
    }
}

static void ifElse()
{
    Console.WriteLine("Ingrese su edad");
    int edad = int.Parse(Console.ReadLine());
    if (edad < 18)
    {
        Console.WriteLine("Eres menor de edad");
    }
    else
    {
        Console.WriteLine("Eres mayor de edad");
    }
}

//Llamar a los metodos

//Valores();
//temperatura();
//ifElse();
