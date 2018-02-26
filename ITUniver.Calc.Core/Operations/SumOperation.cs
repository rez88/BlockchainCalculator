using ITUniver.Calc.Core.Interfaces;
using System;
using System.Linq;
using System.Threading;

namespace ITUniver.Calc.Core.Operations
{
    public class SumOperation : SuperOperation
    {
        public override string Description => "Арифметическое действие, посредством которого из двух или нескольких чисел получают новое, содержащее столько единиц, сколько было во всех данных числах вместе.";

        public override string Name => "sum";

        public override double Exec(double[] args)
        {
            Thread.Sleep(new Random().Next(1, 3) * new Random().Next(100, 3000));

            return args.Sum();
        }
    }
}