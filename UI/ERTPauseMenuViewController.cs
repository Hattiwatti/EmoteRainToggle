using System;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.FloatingScreen;
using BeatSaberMarkupLanguage.ViewControllers;
using BeatSaberPlus_ChatEmoteRain;
using ChatPlexMod_ChatEmoteRain;
using HMUI;
using IPA.Config;
using UnityEngine;
using Zenject;

namespace EmoteRainToggle.UI
{
    [HotReload(@"C:\Users\Hattiwatti\source\repos\EmoteRainToggle\UI\PauseMenu.bsml")]
    internal class ERTPauseMenuViewController : BSMLAutomaticViewController
    {
        public FloatingScreen _FloatingScreen { get; set; }
        public ERTPauseMenuViewController()
        {
        }

        [UIValue("EmoteRainEnabled")]
        private bool EmoteRainEnabled
        {
            get => ChatEmoteRain.Instance.IsEnabled;
            set => ChatEmoteRain.Instance.SetEnabled(value);
        }  

        [UIValue("YPos")]
        private float YPos
        {
            get
            {
                return _FloatingScreen.transform.position.y;
            }
            set
            {
                Vector3 currentPos = _FloatingScreen.transform.position;
                currentPos.y = value;
                _FloatingScreen.transform.position = currentPos;
            }
        }

        [UIValue("ZPos")]
        private float ZPos
        {
            get
            {
                return _FloatingScreen.transform.position.y;
            }
            set
            {
                Vector3 currentPos = _FloatingScreen.transform.position;
                currentPos.z = value;
                _FloatingScreen.transform.position = currentPos;
            }
        }

    }
}
