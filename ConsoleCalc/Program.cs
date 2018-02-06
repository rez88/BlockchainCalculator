using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор");


            /*var oper = args[0];
            var x = Convert.ToInt32(args[1]);
            var y = Convert.ToInt32(args[2]);*/
            Console.WriteLine("Введите название операций(sum, del, umn, vych, sqrt)");
            var oper = Console.ReadLine();
            Console.WriteLine("Введите значение x");
            var x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение y");
            var y = double.Parse(Console.ReadLine());
            double result;
            switch (oper)
            {
                case "sum":

                    {
                        result = x + y;
                        Console.WriteLine($"SUM({x},{y})= {result}");
                    };
                    break;
                case "del":
                    {
                        result = x / y;
                        Console.WriteLine($"DEL({x},{y})= {result}");
                    };
                    break;
                case "umn":
                    {
                        result = x * y;
                        Console.WriteLine($"UMN({x},{y})= {result}");
                    };
                    break;
                case "vych":
                    {
                        result = x - y;
                        Console.WriteLine($"Vych({x},{y})= {result}");
                    }; break;
                case "": { Console.WriteLine("null"); }; break;
                case "sqrt": {
                       result = x*x;
                        Console.WriteLine($"sqrt({x})= {result}");
                    }; break;
            }
            
            Console.ReadKey();
        }
    }
}
