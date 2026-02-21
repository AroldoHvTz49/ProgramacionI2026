// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Console.WriteLine("Ingresa tu nombre");
//string nombre = Console.ReadLine();

//Console.WriteLine("Hola " + nombre);

//int numero1 = 5;
//int numero2 = 2;

//int suma = numero1 + numero2;
//Console.WriteLine("Suma: " + suma);
//int multi = numero1 * numero2;
//Console.WriteLine("Multi: " + multi);
//int divi = numero1 / numero2;
//Console.WriteLine("Divi: " + divi);
//int resta = numero1 - numero2;
//Console.WriteLine("Resta: " + resta);
//double potencia = Math.Pow(numero1, numero2);
//Console.WriteLine("Potencia: " + potencia);

Console.WriteLine("Ingresa el primer numero");
string valor1 = Console.ReadLine();
Console.WriteLine("Ingresa el segundo numero");
string valor2 = Console.ReadLine();

int numero1 = int.Parse(valor1);
int numero2 = int.Parse(valor2);

int suma = numero1 + numero2;
int multi = numero1 * numero2;
int divi = numero1 / numero2;
int resta = numero1 - numero2;

Console.WriteLine("Suma: " + suma);
Console.WriteLine("Multi: " + multi);
Console.WriteLine("Divi: " + divi);
Console.WriteLine("Resta: " + resta);