using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model
{
    public sealed class CalculatorModel
    {
        public IAction Action { get;  set; }
        public ITranslator Translator { get; set; }
        public ITranslator TranslationChecker { private get; set; }

        public int Calculate(int[] operands)
        {
            return Action.Calculate(operands);
        }
        public string Translate(string number)
        {
            string answer = Translator.Translate(number);
            if (number != TranslationChecker.Translate(answer))
            {
                throw new Exception();
            }
            return answer;
        }
        
    }
}
