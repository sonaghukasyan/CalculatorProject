using CalculatorProject.Operations;
using CalculatorProject.TheCalculator;
using System;
using System.Collections.Generic;

namespace CalculatorProject.UIConsole
{
    class UI
    {
        private Calculator Calculator { get; set; }

        public UI()
        {
            this.Calculator = new Calculator();
        }
        public void Start()
        {
            Console.WriteLine("C.Calculate  H.History   M.Memory  Esc.Clear");
            ConsoleKey key = Console.ReadKey().Key;
            Console.Clear();

            switch (key)
            {
                case ConsoleKey.C:
                    Calculate();
                    Start();
                    break;
                case ConsoleKey.H:
                    History();
                    Start();
                    break;

            }
        }

        public void Calculate()
        {
            Console.WriteLine("First number: ");
            double num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Second number: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Click on operation (+,-,*,/): ");
            ConsoleKey key = Console.ReadKey().Key;
            IOperation op = new SumOperation();
            string opSign = "";

            switch (key)
            {
                case ConsoleKey.Add:
                    op = new SumOperation();
                    opSign = " + ";
                    break;
                case ConsoleKey.Divide:
                    op = new DivideOperation();
                    opSign = " / ";
                    break;
                case ConsoleKey.Multiply:
                    op = new MultiplyOperation();
                    opSign = " * ";
                    break;
                case ConsoleKey.Subtract:
                    op = new SubstractOperation();
                    opSign = " - ";
                    break;
                default:
                    Console.WriteLine("Invalid operator;");
                    Console.Clear();
                    Start();
                    break;
            }
            Console.WriteLine();

            this.Calculator.SetOperation(op);
            double answer = Calculator.Operate(num1, num2);
            Console.WriteLine(Calculator.Operate(num1, num2));
            Calculator.UpdateHistory(num1 + opSign + num2 + " = ", answer);
        }

        public void History()
        {
             foreach (KeyValuePair<string, double> entry in Calculator.History)
             {
                    Console.WriteLine(entry.Key + entry.Value);
             }
        }
    }
}
