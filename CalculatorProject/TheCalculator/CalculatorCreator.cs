using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CalculatorProject.TheCalculator
{
    class CalculatorCreator : ICalculatorCreator
    {

        private List<IOperation> _defaultOperations;

        public Calculator CreateCalculator()
        {
            var operations = GetOperations();
            _defaultOperations.AddRange(operations);
            return new Calculator(_defaultOperations);
        }

        public List<IOperation> GetOperations()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(assembly.GetType().Name);
            var ops = assembly.GetTypes().Where(op => op.IsClass && typeof(IOperation).IsAssignableFrom(op));
            
   
            return (List<IOperation>)ops;
        }

    }
}
