using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model.Actions
{
    public class DivideAction : IAction
    {
        public int Calculate(int[] operands)
        {
            return operands[0] / operands[1];
        }
    }
}
