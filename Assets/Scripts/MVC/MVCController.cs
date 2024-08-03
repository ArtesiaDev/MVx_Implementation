using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVC
{
    public class MVCController: MonoBehaviour
    {
        [SerializeField] private Button _minusButton;
        [SerializeField] private Button _plusButton;
        [SerializeField] private TMP_InputField _field;

        private MVCModel _model;

        [Inject]
        private void Construct(MVCModel model) =>
            _model = model;

        private void OnEnable()
        {
            _minusButton.onClick.AddListener(OnMinusButton);
            _plusButton.onClick.AddListener(OnPlusButton);
            _field.onValueChanged.AddListener(FieldInput);
        }

        private void OnDisable()
        {
            _minusButton.onClick.RemoveAllListeners();
            _plusButton.onClick.RemoveAllListeners();
            _field.onValueChanged.RemoveAllListeners();
        }

        private void OnMinusButton() =>
            _model.IntValueChange(_model.IntValue - 1);

        private void OnPlusButton() =>
            _model.IntValueChange(_model.IntValue + 1);

        private void FieldInput(string input) =>
            _model.StringValueChange(input);
    }
}