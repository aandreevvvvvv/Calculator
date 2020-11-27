﻿using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Model.Actions;
using Calculator.Model.Translators;

namespace Calculator.Model.Loggers
{
    public class LogEntry
    {
        public string[] CalculatorInputs { get; set; }
        public IAction Action { get; set; }
        public string CalculatorOutput { get; set; }
        public string TranslatorInput { get; set; }
        public ITranslator Translator { get; set; }
        public string TranslatorOutput { get; set; }
        public LogEntry(string[] calculatorInputs, IAction action, string calculatorOuput)
        {
            CalculatorInputs = calculatorInputs;
            Action = action;
            CalculatorOutput = calculatorOuput;
        }
        public LogEntry(string translatorInput, ITranslator translator, string translatorOutput)
        {
            TranslatorInput = translatorInput;
            Translator = translator;
            TranslatorOutput = TranslatorOutput;
        }
        public LogEntry(string[] calculatorInputs, IAction action, string calculatorOutput, string translatorInput, ITranslator translator, string translatorOuput)
        {
            CalculatorInputs = calculatorInputs;
            Action = action;
            CalculatorOutput = calculatorOutput;
            TranslatorInput = translatorInput;
            Translator = translator;
            TranslatorOutput = TranslatorOutput;
        }
        public LogEntry()
        {
        }
        public override string ToString()
        {
            string str = "";
            foreach(string input in CalculatorInputs)
            {
                str += input + ";";
            }
            str += Action.ToString() + ";";
            str += CalculatorOutput + ";";
            str += TranslatorInput + ";";
            str += Translator.ToString() + ";";
            str += TranslatorOutput + ";";
            return str;
        }
    }
}
