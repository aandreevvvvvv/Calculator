using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model
{
    public interface IAction
    {
        public int Calculate(int[] operands);
    }
}
