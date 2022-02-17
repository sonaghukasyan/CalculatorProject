using Library;
using CalculatorProject.TheCalculator;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CalculatorProject.UIConsole
{
    
    class UI
    {
        private Calculator Calculator { get; set; }
        private ICalculatorCreator CalculatorCreator { get; set; }
        private double Num1;
        private double Num2;

        public UI()
        {
            CalculatorCreator = new CalculatorCreator();
            this.Calculator = CalculatorCreator.CreateCalculator();
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
                case ConsoleKey.M:
                    Console.Clear();
                    Memory();
                    break;
            }
        }

        public void Memory()
        {
            foreach(double num in Calculator.Memory)
            {
                Console.WriteLine(num);
            }
            Start();
        }

        public void Calculate()
        {
            Console.WriteLine("First number: ");
            Num1 = int.Parse(Console.ReadLine());

            Calculate(Num1);
        }

        public void Calculate(double num1)
        {

            Console.WriteLine("Second number: ");
            Num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Click on operation (+,-,*,/): ");
            ConsoleKey key = Console.ReadKey().Key;
            OpSign opSign = OpSign.Plus;
            string sign = "";

            switch (key)
            {
                case ConsoleKey.Add:
                    opSign = OpSign.Plus;
                    sign = "+";
                    break;
                case ConsoleKey.Divide:
                    opSign = OpSign.Divide;
                    sign = "/";
                    break;
                case ConsoleKey.Multiply:
                    opSign = OpSign.Multiply;
                    sign = "*";
                    break;
                case ConsoleKey.Subtract:
                    opSign = OpSign.Minus;
                    sign = "-";
                    break;
                default:
                    Console.WriteLine("Invalid operator;");
                    Console.Clear();
                    Start();
                    break;
            }
            Console.WriteLine();
            double answer;
            try
            {
                answer = Calculator.Operate(opSign, Num1, Num2);
                Console.WriteLine(answer);
            }
            catch(Exception ex)
            {
                answer = 0;
                Console.WriteLine(ex.Message);
                Console.Clear();
                Start();
            }


            Calculator.UpdateHistory(Num1 + sign + Num2 + " = ", answer);
            ToMemorise(answer);
            Start();
        }

        public void ToMemorise(double answer)
        {
            Console.WriteLine("M.Memorise answer    C.Continue");
            ConsoleKey key = Console.ReadKey().Key;
            Console.Clear();

            switch (key)
            {
                case ConsoleKey.M:
                    Calculator.Memory.Add(answer);
                    break;
                case ConsoleKey.C:
                    Start();
                    break;
            }
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
