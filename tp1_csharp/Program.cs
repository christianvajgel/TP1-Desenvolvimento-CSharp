using System;
using System.Reflection;
using System.Threading;

namespace tp1_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                var operation = ReadOperation();

                if (operation == 5)
                {
                    break;
                }
                else
                {
                    Console.Write("Enter with the first number: ");
                    var firstInput = ReadNumber();
                    Console.Write("Enter with the second number: ");
                    var secondInput = ReadNumber();
                    Console.WriteLine("\n" + ExecuteOperations(operation, firstInput, secondInput));
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }

        private static string ExecuteOperations(Decimal operation, Decimal firstInput, Decimal secondInput)
        {
            return operation switch
            {
                1 => firstInput + " + " + secondInput + " = " + Sum.Calculate(firstInput, secondInput),
                2 => firstInput + " - " + secondInput + " = " + Subtraction.Calculate(firstInput, secondInput),
                3 => firstInput + " * " + secondInput + " = " + Multiplication.Calculate(firstInput, secondInput),
                4 => firstInput + " / " + secondInput + " = " + Division.Calculate(firstInput, secondInput),
                _ => "Invalid operation.",
            };
        }

        private static Decimal ReadNumber()
        {
            while (true)
            {
                var inputNumber = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(inputNumber) || Parsing.ValidateNumber(inputNumber) == false)
                {
                    Console.WriteLine("Invalid number.\n" +
                                      "Try again.");
                    Thread.Sleep(1000);
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Console.Clear();
                    Environment.Exit(0);
                }
                else
                {
                    var converted = Parsing.StringToDecimal(inputNumber);
                    if (converted != null)
                    {
                        return converted[0];
                    }
                }
            }
        }

        private static int ReadOperation()
        {
            while (true)
            {
                var inputNumber = Console.ReadLine().Trim();
                if (!String.IsNullOrEmpty(inputNumber) && Parsing.ValidateNumber(inputNumber) == true)
                {
                    var converted = Parsing.StringToInt(inputNumber);
                    if (converted != null && (converted[0] > 0 && converted[0] < 6))
                    {
                        return converted[0];
                    }
                    else
                    {
                        Console.WriteLine("Invalid operation number.\n" +
                                          "It must be an interger number between 1 and 5.\n" +
                                          "Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Whitespace or characters detected.\n" +
                                      "Try again.");
                }
                Thread.Sleep(1000);
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Console.Clear();
                Environment.Exit(0);
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n*** C# CALCULATOR ***\n\n  " +
                                        "Select an option:\n    " +
                                        "1- Sum\n    " +
                                        "2- Subtraction\n    " +
                                        "3- Multiplication\n    " +
                                        "4- Division\n    " +
                                        "5- EXIT\n\n" +
                                        "PS:\n    Decimal Example: 1.2345\n" +
                                        "    Positive and Negative numbers are accepted.\n");
            Console.Write("Choose an operation: ");
        }
    }
}
