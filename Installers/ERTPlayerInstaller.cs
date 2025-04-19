using EmoteRainToggle.UI;
using Zenject;

namespace EmoteRainToggle.Installers
{
    internal class ERTPlayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ERTPauseMenuManager>().AsSingle();
        }
    }
}
