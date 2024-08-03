using MVVM;
using Zenject;

namespace Installers
{
    public sealed class MVVMInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MVVMModel>().AsSingle().NonLazy();
            Container.Bind<MVVMViewModel>().AsSingle().NonLazy();
        }
    }
}