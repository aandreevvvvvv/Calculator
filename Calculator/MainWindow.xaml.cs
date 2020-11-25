using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Calculator.Model;
using Calculator.Model.Actions;
using Calculator.Model.Translators;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IAction[] ActionsAvailable = new IAction[]
        {
            new SumAction(),
            new SubtractAction(),
            new MultiplyAction(),
            new DivideAction(),
            new ModAction()
        };
        ITranslator[] TranslatorsAvailable = new ITranslator[]
        {
            new RomanToArabicTranslator(),
            new ArabicToRomanTranslator()
        };
        Dictionary<string, ITranslator> CheckersAvailable = new Dictionary<string, ITranslator>
        {
            { new RomanToArabicTranslator().ToString(), new ArabicToRomanTranslator() },
            { new ArabicToRomanTranslator().ToString(), new RomanToArabicTranslator() }
        };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.ViewModel(ActionsAvailable, TranslatorsAvailable, CheckersAvailable);
        }
    }
}
