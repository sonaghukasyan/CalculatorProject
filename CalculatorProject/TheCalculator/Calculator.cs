using System;
using System.Collections.Generic;
using System.Linq;
using Library;
namespace CalculatorProject.TheCalculator
{
    class Calculator
    {
        private  readonly IEnumerable<IOperation> _operations;
        public static List<double> Memory;
        public static Dictionary<string,double> History;
        private static int _historySize;

        static Calculator()
        {
            _historySize = 100;
            History = new Dictionary<string, double>();
            Memory = new List<double>();
        } 

        public Calculator(IEnumerable<IOperation> operations)
        {
            this._operations = operations;
        }

        public double Operate(OpSign opsign, double num1, double num2)
        {
            foreach(IOperation op in _operations)
            {
                if(op.OpSign == opsign)
                {
                    return op.Operate(num1, num2);
                }
            }
           
            throw new Exception("Unrecognizable operation");
        }

        public void UpdateHistory(string operation, double answer)
        {
            if(History.Count == _historySize)
            {
                History = new Dictionary<string, double>();
            }

            History.Add(operation, answer);
        }
    }
}
