using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Model.Actions;
using Calculator.Model.Translators;

namespace Calculator.Model.Loggers
{
    public class LogEntry
    {
        public string[] CalculatorInput { get; set; } = new string[0];
        public IAction Action { get; set; } = null;
        public string CalculatorOutput { get; set; } = "";
        public string TranslatorInput { get; set; } = "";
        public ITranslator Translator { get; set; } = null;
        public string TranslatorOutput { get; set; } = "";
        public LogEntry(string[] calculatorInputs, IAction action, string calculatorOuput)
        {
            CalculatorInput = calculatorInputs;
            Action = action;
            CalculatorOutput = calculatorOuput;
        }
        public LogEntry(string translatorInput, ITranslator translator, string translatorOutput)
        {
            TranslatorInput = translatorInput;
            Translator = translator;
            TranslatorOutput = translatorOutput;
        }
        public LogEntry(string[] calculatorInputs, IAction action, string calculatorOutput, string translatorInput, ITranslator translator, string translatorOutput)
        {
            CalculatorInput = calculatorInputs;
            Action = action;
            CalculatorOutput = calculatorOutput;
            TranslatorInput = translatorInput;
            Translator = translator;
            TranslatorOutput = translatorOutput;
        }
        public LogEntry()
        {
        }
        public override string ToString()
        {
            string str = "";
            str += CalculatorInput.Length + ";";
            foreach(string input in CalculatorInput)
            {
                str += input + ";";
            }
            if (Action == null)
            {
                str += ";";
            }
            else
            {
                str += Action.ToString() + ";";
            }
            str += CalculatorOutput + ";";
            str += TranslatorInput + ";";
            if (Translator == null)
            {
                str += ";";
            }
            else
            {
                str += Translator.ToString() + ";";
            }
            str += TranslatorOutput + ";";
            return str;
        }
    }
}
