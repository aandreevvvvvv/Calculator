using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model
{
    public sealed class CalculatorModel
    {
        public IAction Action { get;  set; }
        public ITranslator Translator { private get; set; }

        public int Calculate(int[] operands)
        {
            return Action.Calculate(operands);
        }
        public string Translate(string number)
        {
            return Translator.Translate(number);
        }
        
    }
}
