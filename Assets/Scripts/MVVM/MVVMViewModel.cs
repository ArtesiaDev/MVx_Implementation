using System;
using System.Collections.Generic;
using ModestTree;
using UniRx;
using Zenject;

namespace MVVM
{
    public class MVVMViewModel
    {
        public event Action<int> IntValueViewChanged;
        public event Action<string> StringValueViewChanged;
        public event Action<string> StatusChanged;
        
        private int _intValueView;
        private string _stringValueView  = string.Empty;
        private readonly string[] _statuses = new string[] { "Saved", "Unsaved" };
        private readonly Stack<int> _intValueViewMemory  = new Stack<int>();
        private readonly Stack<string> _stringValueViewMemory  = new Stack<string>();
        
        private MVVMModel _model;
       
        [Inject]
        private void Construct(MVVMModel model) =>
            _model = model;

        public void OnMinusButton() =>
            IntValueViewChange(_intValueView - 1);

        public void OnPlusButton() =>
            IntValueViewChange(_intValueView + 1);

        public void OnFieldInput(string input) =>
            StringValueViewChange(input);

        public void OnBackButton() =>
            ReturnBackState();

        public void OnSaveButton() =>
            ChangeModel();

        private void IntValueViewChange(int newValue)
        {
            SaveIntValueViewState();
            _intValueView = newValue;
            IntValueViewChanged?.Invoke(newValue);
            StatusChanged?.Invoke(_statuses[1]);
        }

        private void StringValueViewChange(string newValue)
        {
            SaveStringValueViewState();
            _stringValueView = newValue;
            StringValueViewChanged?.Invoke(newValue);
            StatusChanged?.Invoke(_statuses[1]);
        }

        private void ChangeModel()
        {
            _model.IntValueChange(_intValueView); 
            _model.StringValueChange(_stringValueView);
            _intValueViewMemory.Clear();
            _stringValueViewMemory.Clear();
            StatusChanged?.Invoke(_statuses[0]);
        }

        private void SaveIntValueViewState() =>
            _intValueViewMemory.Push(_intValueView);

        private void SaveStringValueViewState() =>
            _stringValueViewMemory.Push(_stringValueView);

        private void ReturnBackState()
        {
            if (!_intValueViewMemory.IsEmpty())
                _intValueView = _intValueViewMemory.Pop();
            if (!_stringValueViewMemory.IsEmpty())
                _stringValueView = _stringValueViewMemory.Pop();
            IntValueViewChanged?.Invoke(_intValueView);
            StringValueViewChanged?.Invoke(_stringValueView);
        }
    }
}