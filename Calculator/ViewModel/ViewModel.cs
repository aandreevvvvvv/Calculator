using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Calculator.Model;

namespace Calculator.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private CalculatorModel _model;
        public string[] Input
        {
            get;
            set;
        }
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

        public ICommand CalculateCommand { protected set; get; }
        public ViewModel()
        {
            _model = new CalculatorModel();
            _model.Action = new Model.Actions.SumAction();
            CalculateCommand = new DelegateCommand(ExecuteCalculate);
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
