using System.Collections;
static void ListaTareas()
    {
        ArrayList tareas = new ArrayList();
        int opcion = 0;

        do
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1. Mostrar tareas");
            Console.WriteLine("2. Agregar tarea");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opcion: ");
            opcion = int.Parse(Console.ReadLine());


            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Lista de tareas:");
                    if (tareas.Count == 0)
                    {
                        Console.WriteLine("No hay tareas.");
                    }
                    else
                    {
                        for (int i = 0; i < tareas.Count; i++)
                        {
                            Console.WriteLine(i + ". " + tareas[i]);
                        }
                    }
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Write("Ingrese nueva tarea: ");
                    string tarea = Console.ReadLine();
                    tareas.Add(tarea);
                    break;

                case 3:
                    Console.Write("Ingrese posicion a eliminar: ");
                    int pos = int.Parse(Console.ReadLine());

                    if (pos >= 0 && pos < tareas.Count)
                    {
                        tareas.RemoveAt(pos);
                        Console.WriteLine("Tarea eliminada.");
                    }
                    else
                    {
                        Console.WriteLine("Posicion invalida.");
                    }
                    Console.ReadKey();
                    break;

                default:
                Console.WriteLine("Escribe una opcion valida.");
                    Console.ReadKey();
                    break;
            }

        } while (opcion != 4);
    }

ListaTareas();