using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model.Actions
{
    public class DivideAction : IAction
    {
        public int Calculate(int[] operands)
        {
            int answer;
            checked
            {
                answer = operands[0] / operands[1];
            }
            return answer;
        }
        public override string ToString()
        {
            return "/";
        }
    }
}
