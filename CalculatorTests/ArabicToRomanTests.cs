using NUnit.Framework;
using System.IO;

namespace CalculatorTests
{
    
    public class ArabicToRomanTests
    {
        private Calculator.Model.CalculatorModel _model;
        private string[] correct;
        private string _correctPath = @"C:\Users\Andre\source\repos\Calculator\CalculatorTests\Romans.txt";
        [SetUp]
        public void Setup()
        {
            _model = new Calculator.Model.CalculatorModel();
            _model.Translator = new Calculator.Model.Translators.ArabicToRomanTranslator();
            using (StreamReader sr = new StreamReader(_correctPath))
            {
                correct = sr.ReadToEnd().Split(',');
            }
        }

        [Test]
        public void Test1()
        {
            for(int i=1; i<4000; ++i)
            {
                string answer = _model.Translate(i.ToString());
                if (answer != correct[i-1])
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }
    }
}