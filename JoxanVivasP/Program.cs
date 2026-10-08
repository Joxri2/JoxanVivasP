using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoxanVivasP
{
    internal class Program
    {
        static readonly int n = 13;
        static string[] nombres = new string[n];
        static string[] cedulas = new string[n];
        static int index = -1;

        // agregar pacientes
        static void agregarPaciente()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Se sobreescribiran los pacientes ya existentes");
            Console.ResetColor();
            Console.WriteLine("------------------------------");
            Console.WriteLine("Agregar Paciente (máximo 13): ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Ingrese el nombre del paciente {0}: ", i + 1);
                nombres[i] = Console.ReadLine();
                Console.WriteLine("Ingrese la cédula del paciente {0}: ", i + 1);
                cedulas[i] = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Paciente agregado correctamente.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Desea agregar otro paciente? (s/n): ");
                string respuesta = Console.ReadLine();
                Console.ResetColor();
                if (respuesta != "s" && respuesta != "S") // agregue esta linea simplemente para que el usuario pueda salir del bucle si no desea agregar otro paciente
                {
                    Console.WriteLine("Presione una tecla para ir al menu principal...");
                    break;
                }
                else if (i == n - 1)
                {
                    Console.WriteLine("Se ha alcanzado el límite de pacientes.");
                }
            }
        }

        static bool buscar(string ced)
        {
            index = -1;
            for (int i = 0; i < n; i++)
            {
                if (ced.Equals(cedulas[i]))
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }

        //utilizando un solo metodo para gestionar las opciones de buscar, modificar y eliminar pacientes

        static void gestionar(int op, string accion)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Ingrese la cédula del paciente a {accion}: ");
            string cedula = Console.ReadLine();
            for (int index = 0; index < n; index++) // se recorre el arreglo de cedulas para buscar la cédula ingresada
            {
                if (buscar(cedula) == true) // si el paciente fue encontrado, se mostrará la información del paciente
                {
                    if (op == 2) // si la opción es 2, se mostrará la información del paciente
                    {
                        if (cedula.Equals(cedulas[index])) // se compara la cédula ingresada con la cédula del paciente encontrado
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Paciente encontrado:");
                            Console.WriteLine("Nombre: {0}", nombres[index]);
                            Console.WriteLine("Cédula: {0}", cedulas[index]);
                            Console.ResetColor();
                            break;
                        }

                    }
                    else
                    {
                        if (op == 3) // si la opción es 3, se modificará la información del paciente
                        {
                            if (cedula.Equals(cedulas[index])) // se compara la cédula ingresada con la cédula del paciente encontrado
                            {
                                Console.WriteLine("Ingrese el nuevo nombre del paciente: ");
                                nombres[index] = Console.ReadLine();
                                Console.WriteLine("Ingrese la nueva cédula del paciente: ");
                                cedulas[index] = Console.ReadLine();
                                Console.WriteLine("Paciente modificado correctamente.");
                                break;
                            }
                        }
                        else
                        {
                            if (op == 4) // si la opción es 4, se eliminará el paciente
                            {
                                if (cedula.Equals(cedulas[index])) // se compara la cédula ingresada con la cédula del paciente encontrado
                                {
                                    nombres[index] = null;
                                    cedulas[index] = null;
                                    Console.WriteLine("Paciente eliminado correctamente.");
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Paciente no encontrado.");
                    break;
                }
            }
        }

        static void menu()
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Agregar Paciente.");
                Console.WriteLine("2. Buscar Paciente.");
                Console.WriteLine("3. Modificar Paciente.");
                Console.WriteLine("4. Eliminar Paciente.");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese una opción: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        agregarPaciente();
                        break;
                    case 2:
                        gestionar(2, "buscar");
                        break;
                    case 3:
                        gestionar(3, "modificar");
                        break;
                    case 4:
                        gestionar(4, "eliminar");
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
                Console.ReadKey();
            } while (opcion != 5);
        }

        static void Main(string[] args)
        {
            menu();
        }
    }
}
