using EmoteRainToggle.Installers;
using IPA;
using IPALogger = IPA.Logging.Logger;
using SiraUtil.Zenject;

namespace EmoteRainToggle
{
    [Plugin(RuntimeOptions.DynamicInit), NoEnableDisable]
    public class Plugin
    {
        /// <summary>
        /// Use to send log messages through BSIPA.
        /// </summary>
        internal static IPALogger Log { get; private set; }

        [Init]
        public Plugin(IPALogger logger, Zenjector zenject)
        {
            Log = logger;

            zenject.Install<ERTPlayerInstaller>(Location.Player);
        }
    }
}
