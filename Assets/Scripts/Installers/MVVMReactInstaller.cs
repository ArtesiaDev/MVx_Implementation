using MVVM_React;
using Zenject;

namespace Installers
{
    public class MVVMReactInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Model>().AsSingle().NonLazy();
            Container.Bind<ViewModel>().AsSingle().NonLazy();
        }
    }
}