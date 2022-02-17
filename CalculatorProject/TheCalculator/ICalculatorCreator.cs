using Library;
using System.Collections.Generic;

namespace CalculatorProject.TheCalculator
{
     interface ICalculatorCreator
    {
        IEnumerable<IOperation> GetOperations();
        Calculator CreateCalculator();
    }
}
