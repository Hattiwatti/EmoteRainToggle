using System;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.FloatingScreen;
using BeatSaberMarkupLanguage.ViewControllers;
using HarmonyLib;
using ChatPlexMod_ChatEmoteRain;
using CP_SDK.XUI;
using System.Reflection;

namespace EmoteRainToggle.UI
{
    [HotReload(@"C:\Users\Hattiwatti\source\repos\EmoteRainToggle\UI\PauseMenu.bsml")]
    internal class ERTPauseMenuViewController : BSMLAutomaticViewController
    {
        public FloatingScreen _FloatingScreen { get; set; }
        private Traverse _enableSong;
        private XUIToggle _playingRain;

        public ERTPauseMenuViewController()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(ChatEmoteRain));

            Type t = assembly.GetType("ChatPlexMod_ChatEmoteRain.CERConfig", true).BaseType;
            MethodInfo mi = t.GetMethod("get_Instance", BindingFlags.Static | BindingFlags.Public);

            object cerConfig = mi.Invoke(null, null);
            _enableSong = Traverse.Create(cerConfig).Field("EnableSong");

            t = assembly.GetType("ChatPlexMod_ChatEmoteRain.UI.SettingsMainView", true).BaseType;
            object settingsMainView = Traverse.Create(t).Field("Instance").GetValue();

            _playingRain = Traverse.Create(settingsMainView).Field("m_GeneralTab_PlayingRain").GetValue() as XUIToggle;
        }

        [UIValue("EmoteRainEnabled")]
        private bool EmoteRainEnabled
        {
            get
            {
                return _enableSong?.GetValue<bool>() ?? false;
            }
            set
            {
                _enableSong?.SetValue(value);
                _playingRain?.SetValue(value);
            }
        }  
    }
}
