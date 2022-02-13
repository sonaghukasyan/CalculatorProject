using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject.Operations
{
    class SubstractOperation :IOperation
    {
        public int Operate(int firstParam, int secondParam)
        {
            return firstParam - secondParam;
        }

        public double Operate(double firstParam, double secondParam)
        {
            return firstParam - secondParam;
        }

    }
}
