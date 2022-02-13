using CalculatorProject.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject.TheCalculator
{
    class Calculator
    {
        protected  IOperation _operation;
        public List<double> Memory { get; set; }
        public Dictionary<string,double> History;
        private int _historySize;

        public Calculator()
        {
            this._historySize = 100;
            this.History = new Dictionary<string, double>();
            this.Memory = new List<double>();
        } 
        public Calculator(IOperation operation)
        {
            this._operation = operation;
        }

        public void SetOperation(IOperation operation)
        {
            this._operation = operation;
        }

        public int Operate(int num1, int num2)
        {
            return this._operation.Operate(num1, num2);
        }

        public double Operate(double num1, double num2)
        {
           return this._operation.Operate(num1, num2);
        }

        public void UpdateHistory(string operation, double answer)
        {
            if(History.Count == _historySize)
            {
                History = new Dictionary<string, double>();
            }

            this.History.Add(operation, answer);
        }
    }
}
