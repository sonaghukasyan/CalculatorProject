using Library;
using System;
using System.Collections;
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

        public IEnumerable<IOperation> GetOperations()
        {
            
            Assembly assembly = Assembly.Load("Library");
            var types = assembly.GetTypes();
            int count = (from t in types where t.IsClass select t).Count();

            var operations = from t in types where t.IsClass && typeof(IOperation).IsAssignableFrom(t) select t;


            return operations.OfType<IOperation>();
        }

    }
}
