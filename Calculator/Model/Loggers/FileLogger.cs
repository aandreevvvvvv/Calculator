﻿using Calculator.Model.Actions;
using Calculator.Model.Translators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calculator.Model.Loggers
{
    class FileLogger : ILogger
    {
        private string _path;
        private IAction[] _actionsAvailable;
        private ITranslator[] _translatorsAvailable;
        private const int STATIC_FIELDS_LEN = 5;
        public FileLogger(string path, IAction[] actionsAvailable, ITranslator[] translatorsAvailable)
        {
            _path = path;
            _actionsAvailable = actionsAvailable;
            _translatorsAvailable = translatorsAvailable;
        }
        public void Write(LogEntry entry)
        {
            using (StreamWriter writer = new StreamWriter(_path))
            {
                writer.WriteLine(entry.ToString());
            }
        }
        public LogEntry Read(int idx)
        {
            if (!File.Exists(_path))
            {
                return new LogEntry();
            }
            using (StreamReader reader = new StreamReader(_path))
            {
                string str = "";
                for (int i = 0; i < idx; ++i)
                {
                    if ((str = reader.ReadLine()) == null)
                    {
                        return new LogEntry();
                    }
                }
                int currentProperty = 0;
                string[] properties = str.Split(';');

                string[] calculatorInputs = new string[properties.Length - STATIC_FIELDS_LEN];
                for (currentProperty = 0; currentProperty < calculatorInputs.Length; ++currentProperty)
                {
                    calculatorInputs[currentProperty] = properties[currentProperty];
                }
                currentProperty++;
                IAction action = null;
                foreach (IAction actionAvailable in _actionsAvailable)
                {
                    if (actionAvailable.ToString() == properties[currentProperty])
                    {
                        action = actionAvailable;
                        currentProperty++;
                        break;
                    }
                }
                if (action == null)
                {
                    return new LogEntry();
                }
                string calculatorOutput = properties[currentProperty++];
                string translatorInput = properties[currentProperty++];
                ITranslator translator = null;
                foreach (ITranslator translatorAvailable in _translatorsAvailable)
                {
                    if (translatorAvailable.ToString() == properties[currentProperty])
                    {
                        translator = translatorAvailable;
                        currentProperty++;
                        break;
                    }
                }
                if (translator == null)
                {
                    return new LogEntry();
                }
                string translatorOutput = properties[currentProperty++];
                return new LogEntry(calculatorInputs, action, calculatorOutput, translatorInput, translator, translatorOutput);
            }
        }
    }
}