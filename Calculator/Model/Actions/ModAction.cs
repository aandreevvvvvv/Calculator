using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model.Actions
{
    public class ModAction : IAction
    {
        public int Calculate(int[] operands)
        {
            return operands[0] % operands[1];
        }
        public override string ToString()
        {
            return "%";
        }
    }
}
