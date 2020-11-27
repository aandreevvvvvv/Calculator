using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model.Actions
{
    public interface IAction
    {
        public int Calculate(int[] operands);
    }
}
