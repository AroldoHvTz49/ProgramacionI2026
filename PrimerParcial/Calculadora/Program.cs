//Crear una calculadora que sume, reste, multiplique y divida, debe crearse en una clase llamada calculadora
//Y cada operacion debe ser un metodo

Calculadora calculadora = new Calculadora();

Console.WriteLine("La suma es: " + calculadora.Sumar(5, 3));
Console.WriteLine("La resta es: " + calculadora.Restar(13, 3));
Console.WriteLine("La multi es: " + calculadora.Multiplicar(5, 3));
Console.WriteLine("La division es: " + calculadora.Dividir(15, 3));


class Calculadora
{
    public double Sumar(double a, double b)
    {
        return a + b;
    }
    public double Restar(double a, double b)
    {
        return a - b;
    }
    public double Multiplicar(double a, double b)
    {
        return a * b;
    }
    public double Dividir(double a, double b)
    {
        return a / b;
    }
}
