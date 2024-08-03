using MVP;
using UnityEngine;
using Zenject;

namespace Installers
{
    public sealed class MVPInstaller: MonoInstaller
    {
        [SerializeField] private MVPView _view;
        
        public override void InstallBindings()
        {
            Container.Bind<MVPModel>().AsSingle().NonLazy();
            Container.Bind<MVPPresenter>().AsSingle().NonLazy();
            Container.Bind<MVPView>().FromInstance(_view).AsSingle().NonLazy();
        }
    }
}