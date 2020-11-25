using System.Collections;

namespace Calculator.Model.Actions
{
    public class ActionsCollection : IEnumerable
    {
        private IAction[] _actions;
        
        public ActionsCollection(IAction[] actions)
        {
            _actions = actions;
        }
        public IEnumerator GetEnumerator()
        {
            return _actions.GetEnumerator();
        }
    }
    
}
