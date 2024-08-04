using System.Collections.Generic;
using ModestTree;
using R3;
using Zenject;

namespace MVVM_React
{
    public class ViewModel
    {
        public Observable<int> IntValueView => _intValueView;
        private readonly ReactiveProperty<int> _intValueView  = new ReactiveProperty<int>();
        public Observable<string> StringValueView => _stringValueView;
        private readonly ReactiveProperty<string> _stringValueView  = new ReactiveProperty<string>(string.Empty);
        public Observable<string> Status => _status;
        private readonly ReactiveProperty<string> _status = new ReactiveProperty<string>("Unsaved");
      
        private readonly Stack<int> _intValueViewMemory  = new Stack<int>();
        private readonly Stack<string> _stringValueViewMemory  = new Stack<string>();
        
        private Model _model;
       
        [Inject]
        private void Construct(Model model) =>
            _model = model;
        
        public void OnMinusButton() =>
            IntValueViewChange(_intValueView.Value - 1);

        public void OnPlusButton() =>
            IntValueViewChange(_intValueView.Value + 1);

        public void OnFieldInput(string input) =>
            StringValueViewChange(input);

        public void OnBackButton() =>
            ReturnBackState();

        public void OnSaveButton() =>
            ChangeModel();

        private void IntValueViewChange(int newValue)
        {
            SaveIntValueViewState();
            _intValueView.Value = newValue;
            _status.Value = "Unsaved";
        }

        private void StringValueViewChange(string newValue)
        {
            SaveStringValueViewState();
            _stringValueView.Value = newValue;
            _status.Value = "Unsaved";
        }

        private void ChangeModel()
        {
            _model.IntValueChange(_intValueView.Value); 
            _model.StringValueChange(_stringValueView.Value);
            _intValueViewMemory.Clear();
            _stringValueViewMemory.Clear();
            _status.Value = "Saved";
        }

        private void SaveIntValueViewState() =>
            _intValueViewMemory.Push(_intValueView.Value);

        private void SaveStringValueViewState() =>
            _stringValueViewMemory.Push(_stringValueView.Value);

        private void ReturnBackState()
        {
            if (!_intValueViewMemory.IsEmpty())
                _intValueView.Value = _intValueViewMemory.Pop();
            
            if (!_stringValueViewMemory.IsEmpty())
                _stringValueView.Value = _stringValueViewMemory.Pop();
        }
    }
}