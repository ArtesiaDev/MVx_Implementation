using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVP
{
    public class MVPView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _intView;
        [SerializeField] private TextMeshProUGUI _stringView;
        
        [SerializeField] private Button _minusButton;
        [SerializeField] private Button _plusButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_InputField _field;
        
        private MVPPresenter _presenter;

        [Inject]
        private void Construct(MVPPresenter presenter) =>
            _presenter = presenter;

        public void IntViewUpdate(int value) =>
            _intView.text = value.ToString();

        public void StringValueUpdate(string value) =>
            _stringView.text = value;

        private void OnEnable()
        {
            _minusButton.onClick.AddListener(_presenter.OnMinusButton);
            _plusButton.onClick.AddListener(_presenter.OnPlusButton);
            _backButton.onClick.AddListener(_presenter.OnBackButton);
            _field.onValueChanged.AddListener(_presenter.OnFieldInput);
        }

        private void OnDisable()
        {
            _minusButton.onClick.RemoveAllListeners();
            _plusButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
            _field.onValueChanged.RemoveAllListeners();
        }
    }
}