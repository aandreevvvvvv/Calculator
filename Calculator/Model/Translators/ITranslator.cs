using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model
{
    public interface ITranslator
    {
        public string Translate(string number);
    }
}
