//Declaracion de arreglos
int[] arreglo = new int[10];
//Declaracion con los valores que posee
int[] arreglo2 = new int[] { 1, 3, 4, 5 };
//Tercera forma de declaracion
int[] arreglo3 = [3,5,9,8];
//Cuarta forma
int[] arreglo4 = {3,9,8,7,6};

//arreglo[0] = 90;
//arreglo[1] = 13;
//arreglo[2] = 5;

//Console.WriteLine(arreglo[0]);

for(int i = 0; i < arreglo.Length; i++)
{
    //Console.WriteLine("Posicion {0} Valor {1}", i, arreglo[i]);
}

foreach (int valor in arreglo)
{
    //Console.WriteLine(valor);
}
return;

static void ArregloMultidimensional()
{
    string[,] matriz2D = new string[,]
    {
        {"A","B","C" },
        {"D","E","F" },
        {"G","H","I" },
    };

    string[,,] matriz3D = new string[,,]
    {
        {
            {"A","B","C" },
            {"D","E","F" },
        },
        {
            {"J","K","L" },
            {"M","N","O" },
        }
    };

    //Recuperar Valores
    Console.WriteLine(matriz2D[2, 1]);
    //Modificar Valores
    matriz2D[2, 2] = "X";
    for(int i = 0; i < matriz2D.GetLength(dimension:0); i++)
    {
        for(int j = 0; j < matriz2D.GetLength(dimension:1); j++)
        {
            Console.WriteLine(matriz2D[i, j]);
        }
    }
}

