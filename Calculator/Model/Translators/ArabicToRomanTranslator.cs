using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model.Translators
{
    public class ArabicToRomanTranslator : ITranslator
    {
        private Dictionary<int, char> _symbols = new Dictionary<int, char> { 
            { 1, 'I' },
            { 5, 'V' },
            { 10, 'X' },
            { 50, 'L' },
            { 100, 'C' },
            { 500, 'D' },
            { 1000, 'M' }
        };
        private string rankTranslator(int numeral, int multiplier)
        {
            int[] numeralAnswer = new int[] { };
            switch (numeral)
            {
                case 1:
                    numeralAnswer = new int[]{ 1 };
                    break;
                case 2:
                    numeralAnswer = new int[] { 1, 1 };
                    break;
                case 3:
                    numeralAnswer = new int[] { 1, 1, 1 };
                    break;
                case 4:
                    numeralAnswer = new int[] { 1, 5 };
                    break;
                case 5:
                    numeralAnswer = new int[] { 5 };
                    break;
                case 6:
                    numeralAnswer = new int[] { 5, 1 };
                    break;
                case 7:
                    numeralAnswer = new int[] { 5, 1, 1 };
                    break;
                case 8:
                    numeralAnswer = new int[] { 5, 1, 1, 1 };
                    break;
                case 9:
                    numeralAnswer = new int[] { 1, 10 };
                    break;
            }
            string answer = "";
            for(int i=0; i<numeralAnswer.Length; ++i)
            {
                numeralAnswer[i] *= multiplier;
            }
            foreach(int arabic in numeralAnswer)
            {
                answer += _symbols[arabic];
            }
            return answer;
        }
        public string Translate(string operand)
        {
            int number = int.Parse(operand);
            string answer = "";
            int multiplier = 1;
            while (number > 0)
            {
                answer = answer.Insert(0, rankTranslator(number % 10, multiplier));
                multiplier *= 10;
                number /= 10;
            }
            return answer;
        }
        public override string ToString()
        {
            return "Арабские в римские";
        }
    }
}
    