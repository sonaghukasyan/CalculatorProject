﻿using CalculatorProject.Operations;
using System.Collections.Generic;

namespace CalculatorProject.TheCalculator
{
    internal interface ICalculatorCreator
    {
        List<IOperation> GetOperations();
        Calculator CreateCalculator();
    }
}
