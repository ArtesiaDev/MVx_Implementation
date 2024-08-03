using Zenject;

namespace MVP
{
    public class MVPPresenter
    {
        private MVPModel _model;
       
        [Inject]
        private void Construct(MVPModel model) =>
            _model = model;

        public void OnMinusButton()
        {
            _model.SaveIntValueState();
            _model.IntValueChange(_model.IntValue - 1);
        }

        public void OnPlusButton()
        {
            _model.SaveIntValueState();
            _model.IntValueChange(_model.IntValue + 1);
        }

        public void OnFieldInput(string input)
        {
            _model.SaveStringValueState();
            _model.StringValueChange(input);
        }

        public void OnBackButton() =>
            _model.ReturnBackState();
    }
}