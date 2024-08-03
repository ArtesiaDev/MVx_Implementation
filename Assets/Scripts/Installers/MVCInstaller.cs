using MVC;
using UnityEngine;
using Zenject;

namespace Installers
{
    public sealed class MVCInstaller: MonoInstaller
    {
        [SerializeField] private MVCView _view;
        
        public override void InstallBindings()
        {
            Container.Bind<MVCModel>().AsSingle().NonLazy();
            Container.Bind<MVCView>().FromInstance(_view).AsSingle().NonLazy();
        }
    }
}