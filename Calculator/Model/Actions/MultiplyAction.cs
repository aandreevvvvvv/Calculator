using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model.Actions
{
    public class MultiplyAction : IAction
    {
        public int Calculate(int[] operands)
        {
            int _product = 1;
            foreach(int multiplier in operands)
            {
                _product *= multiplier;
            }
            return _product;
        }
        public override string ToString()
        {
            return "*";
        }
    }
}
