using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model.Translators
{
    public interface ITranslator
    {
        public string Translate(string number);
    }
}
