static void BucleFor()
{
    for (int i = 0; i <= 5; i++)
    {
        Console.WriteLine(i);
    }

    for (int i = 5; i >=1; i--)
    {
        Console.WriteLine(i); 
    }
}

static void BucleWhile()
{
    int i = 1;
    while(i <=10)
    {
        Console.WriteLine(i);
        i++;
    }
}

static void BucleDoWhile()
{
    string opcion;

    do
    {
        Console.WriteLine("1 calcular suma");
        Console.WriteLine("2 calcular multiplicacion");
        Console.WriteLine("3 calcular division");
        Console.WriteLine("4 salir");
        Console.WriteLine("Ingrese la opcion: ");
        opcion = Console.ReadLine();

    } while(opcion != "4");
}

static void BucleConBreak()
{
    for (int i = 0; i <= 5; i++)
    {
        if (i == 5)
        {
            break;
        }
        Console.WriteLine(i);
    }
}

static void BucleConContinue()
{
    for (int i = 0; i <= 10; i++)
    {
        if(i % 2 == 0)
        {
            continue;
        }
        Console.WriteLine(i);
    }
}


//Desafio 1
static void Pares()
{
    Console.WriteLine("Ingrese un numero entero positivo: ");
    int numero = int.Parse(Console.ReadLine());

    for(int i = 0; i <= numero; i++)
    {
        if(i %2 > 0)
        {
            continue;
        }

        Console.WriteLine(i);
    }
}

//Desafio 2
static void Primos()
{
    Console.WriteLine("Ingrese un numero entero positivo: ");
    int numero = int.Parse(Console.ReadLine());

    int i;
    for (i = 2; i < numero; i++)
    {
        if (numero % i == 0)
        {
            Console.WriteLine("El numero: " + numero + " NO es primo");
            break;
        }
    }

    for (; i == numero;)
    {
        Console.WriteLine("El numero: " + numero + " es primo");
        break;
    }
}


Primos();