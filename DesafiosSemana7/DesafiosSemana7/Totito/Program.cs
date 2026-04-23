static void Totito()
{
    string[,] tablero = new string[,]
    {
            {"-","-","-"},
            {"-","-","-"},
            {"-","-","-"}
    };

    string jugador = "X";

    for (int turno = 0; turno < 9; turno++)
    {
        // Mostrar tablero
        for (int i = 0; i < tablero.GetLength(dimension: 0); i++)
        {
            for (int j = 0; j < tablero.GetLength(dimension: 1); j++)
            {
                Console.Write(tablero[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Turno: " + jugador);

        Console.Write("Fila (0-2): ");
        int fila = int.Parse(Console.ReadLine());

        Console.Write("Columna (0-2): ");
        int col = int.Parse(Console.ReadLine());

        // Colocar jugada
        if (tablero[fila, col] == "-")
        {
            tablero[fila, col] = jugador;

            // Cambiar jugador
            if (jugador == "X")
                jugador = "O";
            else
                jugador = "X";
        }
        else
        {
            Console.WriteLine("Ya ocupado");
            turno--;
            Console.ReadKey();
        }
    }

    Console.WriteLine("Fin del juego");
}

Totito();