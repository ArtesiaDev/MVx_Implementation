using System.Collections.Generic;
using ModestTree;
using Zenject;

namespace MVP
{
    public class MVPModel
    {
        public int IntValue { get; private set; }
        private string _stringValue  = string.Empty;
        private readonly Stack<int> _intValueMemory  = new Stack<int>();
        private readonly Stack<string> _stringValueMemory  = new Stack<string>();

        private MVPView _view;

        [Inject]
        private void Construct(MVPView view) =>
            _view = view;

        public void IntValueChange(int newValue)
        {
            IntValue = newValue;
            _view.IntViewUpdate(IntValue);
        }

        public void StringValueChange(string newValue)
        {
            _stringValue = newValue;
            _view.StringValueUpdate(_stringValue);
        }

        public void SaveIntValueState() =>
            _intValueMemory.Push(IntValue);

        public void SaveStringValueState() =>
            _stringValueMemory.Push(_stringValue);

        public void ReturnBackState()
        {
            if (!_intValueMemory.IsEmpty())
                IntValue = _intValueMemory.Pop();
            if (!_stringValueMemory.IsEmpty())
                _stringValue = _stringValueMemory.Pop();
            _view.IntViewUpdate(IntValue);
            _view.StringValueUpdate(_stringValue);
        }
    }
}