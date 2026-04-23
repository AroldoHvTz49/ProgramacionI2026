static void Descuentos()
    {
        double[,] compras = new double[,]
        {
            {50, 20, 10, 12, 7},         // Cliente 1
            {40, 39, 10, 10, 1},         // Cliente 2
            {40, 40, 10, 10, 1},         // Cliente 3
            {100, 200, 500, 100, 99},    // Cliente 4
            {600, 200, 100, 30, 70}      // Cliente 5
        };

        CalcularDescuento(compras);
    }

    static void CalcularDescuento(double[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(dimension:0); i++)
        {
            double total = 0;

            // sumar compras del cliente
            for (int j = 0; j < matriz.GetLength(dimension:1); j++)
            {
                total += matriz[i, j];
            }

            double descuento = 0;

            // reglas
            if (total >= 100 && total <= 1000)
                descuento = total * 0.10;
            else if (total > 1000)
                descuento = total * 0.20;

            double totalFinal = total - descuento;

            Console.WriteLine("Cliente " + (i + 1));
            Console.WriteLine("Total: " + total);
            Console.WriteLine("Descuento: " + descuento);
            Console.WriteLine("Total a pagar: " + totalFinal);
            Console.WriteLine();
        }
    }

Descuentos();