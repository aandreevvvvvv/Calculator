using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model.Translators
{
    public class RomanToArabicTranslator : ITranslator
    {
        private Dictionary<char, int> _symbols = new Dictionary<char, int> {
            {'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
        public string Translate(string number)
        {
            int answer = 0;
            for(int i=0; i<number.Length-1; ++i)
            {
                if (_symbols[number[i]] < _symbols[number[i + 1]])
                {
                    answer -= _symbols[number[i]];
                }
                else
                {
                    answer += _symbols[number[i]];
                }
            }
            answer += _symbols[number[number.Length - 1]];
            return answer.ToString();
        }
    }
}
