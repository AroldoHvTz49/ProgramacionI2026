//Programa que solicite al usuario la cantidad de numeros que desea ingresar
//luego el programa debe solicitar al usuario que ingrese cada numero, despues
//de recibir todos los numeros el programa debe calcular y mostrar:
//Cuantos numeros son pares y cuantos son impares
//La suma de todos los pares
//La suma de todos los impares

Console.WriteLine("Ingrese la cantidad de números que desea ingresar:");
int cantidad = int.Parse(Console.ReadLine());

int i;
int numero;

int numerosPares = 0;
int contadorPares = 0;

int numerosImpares = 0;
int contadorImpares = 0;

for (i = 1; i <= cantidad; i++)
{
    Console.WriteLine("Ingrese un numero");
    numero = int.Parse(Console.ReadLine());

    if (numero % 2 > 0)
    {
        numerosImpares = numerosImpares + numero;
        contadorImpares++;

    }
    else
    {
        numerosPares = numerosPares + numero;
        contadorPares++;
    }
}

Console.WriteLine("La cantidad de numeros pares es: " + contadorPares);
Console.WriteLine("La cantidad de numeros impares es: " + contadorImpares);
Console.WriteLine("La suma de los numeros pares es: " + numerosPares);
Console.WriteLine("La suma de los numeros impares es: " + numerosImpares);