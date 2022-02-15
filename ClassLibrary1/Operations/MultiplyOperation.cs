using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject.Operations
{
    class MultiplyOperation : IOperation
    {
        public OpSign OpSign { get { return (OpSign)1; } set { } }

        public int Operate(int firstParam, int secondParam)
        {
            return firstParam * secondParam;
        }

        public double Operate(double firstParam, double secondParam)
        {
            return firstParam * secondParam;
        }

        public long Operate(long firstParam, long secondParam)
        {
            return firstParam * secondParam;
        }
    }
}
