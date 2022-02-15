using System;
using System.Collections.Generic;

namespace CalculatorProject.TheCalculator
{
    //IEnumarable sarqi
    class Calculator
    {
        private  readonly List<IOperation> _operations;
        public static List<double> Memory;
        public static Dictionary<string,double> History;
        private static int _historySize;

        static Calculator()
        {
            _historySize = 100;
            History = new Dictionary<string, double>();
            Memory = new List<double>();
        } 
        public Calculator(List<IOperation> operations)
        {
            this._operations = operations;
        }

        //Linqov poxi
        public double Operate(OpSign opsign, double num1, double num2)
        {
            for(int i = 0; i < _operations.Count; i++)
            {
                if(opsign == _operations[i].OpSign)
                {
                    return _operations[i].Operate(num1, num2);
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
