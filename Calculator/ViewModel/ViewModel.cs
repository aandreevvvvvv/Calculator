using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Calculator.Model;
using System.Collections.ObjectModel;
using Calculator.Model.Actions;
using Calculator.Model.Translators;
using Calculator.Model.Loggers;
using System.Collections;

namespace Calculator.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private CalculatorModel _model;
        private ILogger _logger;
        private string[] _calculatorInput;
        public string[] CalculatorInput
        {
            get { return _calculatorInput;  }
            set
            {
                _calculatorInput = value;
                onPropertyChanged();
            }
        }
        private string _translatorInput;
        public string TranslatorInput
        {
            get { return _translatorInput; }
            set
            {
                _translatorInput = value;
                onPropertyChanged();
            }
        }
        private string _translatorOutput;
        public string TranslatorOutput
        {
            get { return _translatorOutput; }
            set
            {
                _translatorOutput = value;
                onPropertyChanged();
            }
        }
        private bool[] _translatorChosen;
        public bool[] TranslatorChosen
        {
            get { return _translatorChosen; }
            set
            {
                _translatorChosen = value;
                onPropertyChanged();
            }
        }
        private Dictionary<string, ITranslator> checkers;
        public ITranslator[] Translators { get; set; }
        private string _calculatorOutput;
        public string CalculatorOutput
        {
            get { return _calculatorOutput; }
            set
            {
                _calculatorOutput = value;
                onPropertyChanged();
            }
        }

        public ActionsCollection Actions { get; set; }

        public IAction CurrentAction
        {
            get
            {
                return _model.Action;
            }
            set
            {
                _model.Action = value;
                onPropertyChanged();
            }
        }
        public ICommand CalculateCommand { protected set; get; }
        public ICommand TranslateCommand { protected set; get; }
        public ICommand ClearCalculateCommand { protected set; get; }
        public ICommand ClearTranslateCommand { protected set; get; }
        public ViewModel(IAction[] actions, ITranslator[] translators, Dictionary<string, ITranslator> checkers, ILogger logger)
        {
            _model = new CalculatorModel();
            Translators = translators;
            this.checkers = checkers;
            CalculateCommand = new DelegateCommand(ExecuteCalculate);
            TranslateCommand = new DelegateCommand(ExecuteTranslate);
            ClearCalculateCommand = new DelegateCommand(ExecuteClearCalculate);
            ClearTranslateCommand = new DelegateCommand(ExecuteClearTranslate);
            Actions = new ActionsCollection(actions);
            CalculatorInput = new string[2];
            TranslatorChosen = new bool[Translators.Length];
            _logger = logger;
        }
        private void ExecuteTranslate(object param)
        {
            if(_model.Translator == null)
            {
                return;
            }
            _model.Translator = (ITranslator)param;
            _model.TranslationChecker = checkers[((ITranslator)param).ToString()];
            if(TranslatorInput == null)
            {
                TranslatorOutput = "Неправильный ввод";
                return;
            }

            try
            {
                TranslatorOutput = _model.Translate(TranslatorInput);
            }
            catch
            {
                TranslatorOutput = "Неправильный ввод";
            }
            _logger.Write(new LogEntry(_translatorInput, _model.Translator, _translatorOutput));
        }
        private void ExecuteCalculate(object param)
        {
            if (_model.Action == null) return;
            try
            {
                CalculatorOutput = (_model.Calculate(Array.ConvertAll(CalculatorInput, int.Parse))).ToString();
            }
            catch
            {
                CalculatorOutput = "Неправильный ввод";
            }
            _logger.Write(new LogEntry(_calculatorInput, _model.Action, _calculatorOutput));
        }
        private void ExecuteClearCalculate(object param)
        {
            CalculatorInput = new string[2];
            CalculatorOutput = "";
            CurrentAction = null;
        }
        private void ExecuteClearTranslate(object param)
        {
            TranslatorInput = "";
            TranslatorOutput = "";
            TranslatorChosen = new bool[Translators.Length];
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void onPropertyChanged([CallerMemberName]string prop="")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
