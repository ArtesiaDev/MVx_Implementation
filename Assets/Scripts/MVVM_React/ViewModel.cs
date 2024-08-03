using System.Collections.Generic;
using ModestTree;
using UniRx;
using Zenject;

namespace MVVM_React
{
    public class ViewModel
    {
        public ReactiveProperty<int> IntValueView { get; } = new ReactiveProperty<int>();
        public ReactiveProperty<string> StringValueView { get; } = new ReactiveProperty<string>(string.Empty);
        public ReactiveProperty<string> Status { get; } = new ReactiveProperty<string>("Unsaved");
      
        private readonly Stack<int> _intValueViewMemory  = new Stack<int>();
        private readonly Stack<string> _stringValueViewMemory  = new Stack<string>();
        
        private Model _model;
       
        [Inject]
        private void Construct(Model model) =>
            _model = model;
        
        public void OnMinusButton() =>
            IntValueViewChange(IntValueView.Value - 1);

        public void OnPlusButton() =>
            IntValueViewChange(IntValueView.Value + 1);

        public void OnFieldInput(string input) =>
            StringValueViewChange(input);

        public void OnBackButton() =>
            ReturnBackState();

        public void OnSaveButton() =>
            ChangeModel();

        private void IntValueViewChange(int newValue)
        {
            SaveIntValueViewState();
            IntValueView.Value = newValue;
            Status.Value = "Unsaved";
        }

        private void StringValueViewChange(string newValue)
        {
            SaveStringValueViewState();
            StringValueView.Value = newValue;
            Status.Value = "Unsaved";
        }

        private void ChangeModel()
        {
            _model.IntValueChange(IntValueView.Value); 
            _model.StringValueChange(StringValueView.Value);
            _intValueViewMemory.Clear();
            _stringValueViewMemory.Clear();
            Status.Value = "Saved";
        }

        private void SaveIntValueViewState() =>
            _intValueViewMemory.Push(IntValueView.Value);

        private void SaveStringValueViewState() =>
            _stringValueViewMemory.Push(StringValueView.Value);

        private void ReturnBackState()
        {
            if (!_intValueViewMemory.IsEmpty())
                IntValueView.Value = _intValueViewMemory.Pop();
            
            if (!_stringValueViewMemory.IsEmpty())
                StringValueView.Value = _stringValueViewMemory.Pop();
        }
    }
}