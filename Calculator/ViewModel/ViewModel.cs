using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Calculator.Model;
using System.Collections.ObjectModel;
using Calculator.Model.Actions;
using System.Collections;

namespace Calculator.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private CalculatorModel _model;
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
        public ICommand ClearCommand { protected set; get; }
        public ViewModel(IAction[] actions, ITranslator[] translators)
        {
            _model = new CalculatorModel();
            Translators = translators;
            CalculateCommand = new DelegateCommand(ExecuteCalculate);
            TranslateCommand = new DelegateCommand(ExecuteTranslate);
            ClearCommand = new DelegateCommand(ExecuteClear);
            Actions = new ActionsCollection(actions);
            CalculatorInput = new string[2];
            TranslatorChosen = new bool[Translators.Length];
        }
        private void ExecuteTranslate(object param)
        {
            _model.Translator = (ITranslator)param;
            try
            {
                TranslatorOutput = _model.Translate(TranslatorInput);
            }
            catch
            {
                TranslatorOutput = "Неправильный ввод";
            }
        }
        private void ExecuteCalculate(object param)
        {
            try
            {
                CalculatorOutput = (_model.Calculate(Array.ConvertAll(CalculatorInput, int.Parse))).ToString();
            }
            catch
            {
                CalculatorOutput = "Неправильный ввод";
            }
        }
        private void ExecuteClear(object param)
        {
            CalculatorInput = new string[2];
            TranslatorChosen = new bool[Translators.Length];
            CalculatorOutput = "";
            TranslatorInput = "";
            TranslatorOutput = "";
            CurrentAction = null;
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
