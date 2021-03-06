﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model.Actions
{
    public class SumAction : IAction
    {
        public int Calculate(int[] operands)
        {

            int _sum = 0;
            checked
            {
                foreach (int summand in operands)
                {
                    _sum += summand;
                }
            }
            return _sum;
        }
        public override string ToString()
        {
            return "+";
        }
    }
}
