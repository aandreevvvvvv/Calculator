using NUnit.Framework;
using System.IO;

namespace CalculatorTests
{

    public class RomanToArabicTests
    {
        private Calculator.Model.Translators.ArabicToRomanTranslator _toRoman;
        private Calculator.Model.Translators.RomanToArabicTranslator _toArabic;
        [SetUp]
        public void Setup()
        {
            _toRoman = new Calculator.Model.Translators.ArabicToRomanTranslator();
            _toArabic = new Calculator.Model.Translators.RomanToArabicTranslator();
        }

        [Test]
        public void Test1()
        {
            for (int i = 1; i < 4000; ++i)
            {
                if (i != int.Parse(_toArabic.Translate(_toRoman.Translate(i.ToString()))))
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }
    }
}