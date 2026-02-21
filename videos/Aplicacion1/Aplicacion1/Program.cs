//Video 3
Console.WriteLine("Video 3 Introduccion");
Console.WriteLine(87);
Console.WriteLine("Informacion");
Console.WriteLine(7 + 10);

//Video 4
Console.WriteLine("Video 4 Tipos de datos");
int entero = 87;
double decima = 2.14;
bool booleano = true; // true o false
char caracter = 'a'; // solo 2 caracteres, se usan comillas simples
float decimales32bit = 1.50f; // se le agrega la letra f al final para indicar que es un float
string cadena = "Informacion"; // se usan comillas dobles para las cadenas de texto

//Video 5
Console.WriteLine("Video 5 Variables");
string nombre = "Aroldo";
int edad = 19;
bool activo = true;
DateTime fecha = DateTime.Now;
float precio = 1.986f;
decimal descuento = 10.50m; // se usa m para definir decimal
double descuento2= 10.50; // el tipo double es el predeterminado para los números decimales, no necesita un sufijo

Console.WriteLine(nombre);
Console.WriteLine(edad);
Console.WriteLine(activo);
Console.WriteLine(fecha);
Console.WriteLine(precio);
Console.WriteLine(descuento);
Console.WriteLine(descuento2);

//Console.ReadKey(); // Detiene la ejecución del programa hasta que se presione una tecla, útil para ver el resultado antes de que la consola se cierre.


// Video 6
Console.WriteLine("Video 6 Concatenacion de Valores");
edad = 50;
Console.WriteLine(edad); //actualizacion de valores

string nombre1 = "Angel";
int edad1 = 25;
Console.WriteLine("Nombre de usuario: " + nombre1 + "edad: " + edad1);
Console.WriteLine($"Nombre de usuario: {nombre1} edad: {edad1}");
Console.WriteLine("Nombre de usuario:\n" + nombre1 + "Edad mas 10" + edad1 + 10);


//Video 7
Console.WriteLine("Video 7 Comentarios");

// Este es un comentario de una sola línea

/*
 Este es un comentario de varias líneas
 Se puede usar para explicar partes del código o para desactivar temporalmente código que no queremos ejecutar.
*/


//Video 8
Console.WriteLine("Video 8 Constantes");
var variedaDeDatos = "Hola";
var variedaDeDatos2 = 123;

const int numero2 = 150;
Console.WriteLine("Valor de constante:" + numero2);
//numero2 = 200; // Esto generará un error porque las constantes no pueden ser modificadas después de su declaración.
const double PI = 3.14;
const string mensaje = "Bienvenido a C#";


//Video 9
Console.WriteLine("Video 9 Casting");
// conversion de un numero entero a un numero decimal
int valor = 200;
double total = valor; // El valor entero se convierte automáticamente a un valor decimal, esto se llama "casting implícito" o "conversión implícita".
Console.WriteLine(total);

//casting explicito
double precio1 = 500.23;
int descuento1 = (int)precio1; // El valor decimal se convierte a un valor entero, esto se llama "casting explícito" o "conversión explícita". Se pierde la parte decimal.
Console.WriteLine("Explicito: " + descuento1);

char letra = 'A';
int codigoAscii = letra;
Console.WriteLine(codigoAscii);// transforma a ascii mediante el casting implícito

string palabra = "12356";
int numero = Convert.ToInt32(palabra); // Convierte la cadena de texto a un número entero, si la cadena no es un número válido, se generará una excepción.
Console.WriteLine(numero);

string textoDecimal = "150.32";
double numeroDecimal = double.Parse(textoDecimal); // Convierte la cadena de texto a un número decimal, si la cadena no es un número válido, se generará una excepción.
Console.WriteLine(numeroDecimal);


//Video 10
Console.WriteLine("Video 10 Operadores Aritmeticos");
int valor1 = 30, valor2 = 10, valor3 = 20;

int suma = valor1 + valor2; // Suma de dos números
Console.WriteLine("Total de la Suma: " + suma);
Console.WriteLine(valor1 + valor2);

int resta = valor1 - valor2; // Resta de dos números
Console.WriteLine("Total de la Resta: " + resta);

int multiplicacion = valor1 * valor2; // Multiplicación de dos números
Console.WriteLine("Total de la Multiplicacion: " + multiplicacion);

int division = valor1 / valor2; // División de dos números
Console.WriteLine("Total de la Division: " + division);

var modulo = valor1 % valor2; // Módulo de dos números, devuelve el resto de la división
Console.WriteLine("Total del Modulo: " + modulo);

