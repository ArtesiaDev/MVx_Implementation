using TMPro;
using R3;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVVM_React
{
    public class View : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _intView;
        [SerializeField] private TextMeshProUGUI _stringView;
        [SerializeField] private TextMeshProUGUI _statusView;

        [SerializeField] private Button _minusButton;
        [SerializeField] private Button _plusButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private TMP_InputField _field;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        
        private ViewModel _viewModel;

        [Inject]
        private void Construct(ViewModel viewModel) =>
            _viewModel = viewModel;

        private void OnEnable()
        {
            _minusButton.OnClickAsObservable().Subscribe(_ => _viewModel.OnMinusButton()).AddTo(_disposable);
            _plusButton.OnClickAsObservable().Subscribe(_ => _viewModel.OnPlusButton()).AddTo(_disposable);
            _backButton.OnClickAsObservable().Subscribe(_ => _viewModel.OnBackButton()).AddTo(_disposable);
            _saveButton.OnClickAsObservable().Subscribe(_ => _viewModel.OnSaveButton()).AddTo(_disposable);
            _field.onValueChanged.AddListener(_viewModel.OnFieldInput);

            _viewModel.IntValueView.Subscribe(value => { _intView.text = value.ToString(); }).AddTo(_disposable);
            _viewModel.StringValueView.Subscribe(value => { _stringView.text = value; }).AddTo(_disposable);
            _viewModel.Status.Subscribe(value => { _field.text = value; }).AddTo(_disposable);
        }

        private void OnDisable()
        {
            _field.onValueChanged.RemoveAllListeners();
            _disposable.Clear();
        }
    }
}