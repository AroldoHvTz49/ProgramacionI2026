using System.Linq.Expressions;

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
Console.WriteLine("La aplicacion termino");
