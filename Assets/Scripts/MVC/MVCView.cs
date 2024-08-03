using TMPro;
using UnityEngine;
using Zenject;

namespace MVC
{
    public class MVCView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _intView;
        [SerializeField] private TextMeshProUGUI _stringView;

        private MVCModel _model;

        [Inject]
        private void Construct(MVCModel model) =>
            _model = model;

        private void OnEnable()
        {
            _model.IntValueChanged += IntViewUpdate;
            _model.StringValueChanged += StringValueUpdate;
        }

        private void OnDisable()
        {
            _model.IntValueChanged -= IntViewUpdate;
            _model.StringValueChanged -= StringValueUpdate;
        }

        private void IntViewUpdate(int value) =>
            _intView.text = value.ToString();

        private void StringValueUpdate(string value) =>
            _stringView.text = value;
    }
}