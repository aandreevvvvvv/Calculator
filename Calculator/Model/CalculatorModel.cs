using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Model.Translators;
using Calculator.Model.Actions;

namespace Calculator.Model
{
    public sealed class CalculatorModel
    {
        public IAction Action { get; set; } = null;
        public ITranslator Translator { get; set; } = null;
        public ITranslator TranslationChecker { private get; set; } = null;

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
