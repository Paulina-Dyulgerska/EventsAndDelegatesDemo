using ExerciseDemo.P03_DependencyInversion;
using P03_DependencyInversion;
using System;
using System.Linq;

namespace ExerciseDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IStrategy strategy = new AdditionStrategy();

            while (true)
            {
                var commandLine = Console.ReadLine().Split().ToList();

                if (commandLine[0] == "End")
                {
                    break;
                }

                if (commandLine[0] == "mode")
                {
                    var @operator = char.Parse(commandLine[1]);

                    switch (@operator)
                    {
                        case '-':
                            strategy = new SubtractionStrategy();
                            break;
                        case '/':
                            strategy = new DivisionStrategy();
                            break;
                        case '*':
                            strategy = new MultiplyStrategy();
                            break;
                        case '^':
                            strategy = new PowerStrategy();
                            break;
                        default:
                            strategy = new AdditionStrategy();
                            break;
                    }
                    
                    continue;
                }

                var firstOperand = int.Parse(commandLine[0]);
                var secondOperand = int.Parse(commandLine[1]);
                var calculator = new PrimitiveCalculator(strategy);
                var result = calculator.performCalculation(firstOperand, secondOperand);

                Console.WriteLine(result);
            }
        }
    }
}
