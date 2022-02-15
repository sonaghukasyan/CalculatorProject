using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsLibrary
{
    class SumOperation : IOperation
    {
        
        public OpSign OpSign { get { return (OpSign)0; } set { } }

        public int Operate(int firstParam, int secondParam)
        {
            return firstParam + secondParam;
        }

        public double Operate(double firstParam, double secondParam)
        {
            return firstParam + secondParam;
        }

        public long Operate(long firstParam, long secondParam)
        {
            return firstParam + secondParam;
        }
    }
}
