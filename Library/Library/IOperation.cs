using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface IOperation
    {
        OpSign OpSign { get; set; }
        int Operate(int firstParam, int secondParam);
        double Operate(double firstParam, double secondParam);

    }
}
