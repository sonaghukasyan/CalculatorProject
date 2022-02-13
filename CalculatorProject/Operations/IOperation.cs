using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject.Operations
{
    public interface IOperation
    {
        int Operate(int firstParam, int secondParam);
        double Operate(double firstParam, double secondParam);

    }
}
