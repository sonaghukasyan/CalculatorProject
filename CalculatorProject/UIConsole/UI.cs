using CalculatorProject.Operations;
using CalculatorProject.TheCalculator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorProject.UIConsole
{
    
    class UI
    {
        private Calculator Calculator { get; set; }
        private double Num1;
        private double Num2;

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
                    Console.WriteLine("First number: ");
                    Num1 = int.Parse(Console.ReadLine());

                    Calculate(Num1);
                    Start();
                    break;
                case ConsoleKey.H:
                    History();
                    Start();
                    break;

            }
        }

        public void Calculate(double num1)
        {

            Console.WriteLine("Second number: ");
            Num2 = double.Parse(Console.ReadLine());

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
            double answer = Calculator.Operate(Num1, Num2);
            Console.WriteLine(Calculator.Operate(Num1, Num2));
            Calculator.UpdateHistory(Num1 + opSign + Num2 + " = ", answer);
        }

        public void History()
        {
             foreach (KeyValuePair<string, double> entry in Calculator.History)
             {
                    Console.WriteLine(entry.Key + entry.Value);
             }
            Console.WriteLine("Write the line to get answer of a calculation from history or write 0 to go back");
            int lineIndex = int.Parse(Console.ReadLine());
            if(lineIndex == 0)
            {
                Console.Clear();
                Start();
            }
            else
            {
                Num1 = Calculator.History.ElementAt(lineIndex).Value;
                Calculate(Num1);
            }
        }
    }
}
