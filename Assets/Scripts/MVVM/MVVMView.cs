using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVVM
{
    public class MVVMView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _intView;
        [SerializeField] private TextMeshProUGUI _stringView;
        [SerializeField] private TextMeshProUGUI _statusView;
        
        [SerializeField] private Button _minusButton;
        [SerializeField] private Button _plusButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private TMP_InputField _field;
        
        private MVVMViewModel _viewModel;

        [Inject]
        private void Construct(MVVMViewModel viewModel) =>
            _viewModel = viewModel;
        
        private void OnEnable()
        {
            _minusButton.onClick.AddListener(_viewModel.OnMinusButton);
            _plusButton.onClick.AddListener(_viewModel.OnPlusButton); 
            _backButton.onClick.AddListener(_viewModel.OnBackButton);
            _saveButton.onClick.AddListener(_viewModel.OnSaveButton);
            _field.onValueChanged.AddListener(_viewModel.OnFieldInput);
            _viewModel.IntValueViewChanged += IntViewUpdate;
            _viewModel.StringValueViewChanged += StringViewUpdate;
            _viewModel.StatusChanged += StatusUpdate;
        }

        private void OnDisable()
        {
            _minusButton.onClick.RemoveAllListeners();
            _plusButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
            _saveButton.onClick.RemoveAllListeners();
            _field.onValueChanged.RemoveAllListeners();
            _viewModel.IntValueViewChanged -= IntViewUpdate;
            _viewModel.StringValueViewChanged -= StringViewUpdate;
            _viewModel.StatusChanged -= StatusUpdate;
        }

        private void IntViewUpdate(int value) =>
            _intView.text = value.ToString();

        private void StringViewUpdate(string value) =>
            _stringView.text = value;

        private void StatusUpdate(string status) =>
            _statusView.text = status;
    }
}