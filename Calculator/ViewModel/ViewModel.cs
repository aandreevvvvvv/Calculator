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
        public string[] Input { get; set; }
        public string TranslatorInput { get; set; }
        public string TranslatorOutput { get; set; }
        private string _output;
        public string Output
        {
            get { return _output; }
            set
            {
                _output = value;
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
            }
        }
        public ICommand CalculateCommand { protected set; get; }
        public ViewModel(IAction[] actions)
        {
            _model = new CalculatorModel();
            CalculateCommand = new DelegateCommand(ExecuteCalculate);
            Actions = new ActionsCollection(actions);
            Input = new string[2];
        }
        
        private void ExecuteCalculate(object param)
        {
            Output = (_model.Calculate(Array.ConvertAll(Input, int.Parse))).ToString();
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
