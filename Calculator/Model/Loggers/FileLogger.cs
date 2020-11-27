using Calculator.Model.Actions;
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
        private ActionsCollection _actionsCollection;
        private ITranslator[] _translatorsCollection;
        private const int STATIC_FIELDS_LEN = 5;
        public FileLogger(string path, ActionsCollection actionsCollection, ITranslator[] translatorsCollection)
        {
            _path = path;
            _actionsCollection = actionsCollection;
            _translatorsCollection = translatorsCollection;
        }
        public void Write(LogEntry entry)
        {
            if (!File.Exists(_path))
            {
                File.Create(_path);
            }
            using(StreamWriter writer = new StreamWriter(_path))
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
            using(StreamReader reader = new StreamReader(_path))
            {
                string str = "";
                for(int i=0; i<idx; ++i)
                {
                    if ((str = reader.ReadLine()) == null)
                    {
                        return new LogEntry();
                    }
                }
                int currentProperty = 0;
                string[] properties = str.Split(';');

                string[] calculatorInputs = new string[properties.Length - STATIC_FIELDS_LEN];
                for(currentProperty=0; currentProperty<calculatorInputs.Length; ++currentProperty)
                {
                    calculatorInputs[currentProperty] = properties[currentProperty];
                }
                currentProperty++;
                IAction action = null;
                foreach(IAction actionFromCollection in _actionsCollection)
                {
                    if (actionFromCollection.ToString() == properties[currentProperty])
                    {
                        action = actionFromCollection;
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
                foreach(ITranslator translatorFromCollection in _translatorsCollection)
                {
                    if (translatorFromCollection.ToString() == properties[currentProperty])
                    {
                        translator = translatorFromCollection;
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