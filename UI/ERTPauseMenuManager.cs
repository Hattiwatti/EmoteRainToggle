using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.FloatingScreen;
using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace EmoteRainToggle.UI
{
    internal class ERTPauseMenuManager : IInitializable, IDisposable
    {
        private ERTPauseMenuViewController _viewController;
        private FloatingScreen _floatingScreen;

        private PauseController _pauseController;


        private ERTPauseMenuManager(PauseController pauseController)
        {
            _pauseController = pauseController;
        }

        public void Initialize()
        {
            _viewController = BeatSaberUI.CreateViewController<ERTPauseMenuViewController>();

            _floatingScreen = FloatingScreen.CreateFloatingScreen(
                new Vector2(100, 50),
                false,
                new Vector3(0, 0.8f, 1.9f),
                Quaternion.identity,
                0,
                true);

            _viewController._FloatingScreen = _floatingScreen;

            _floatingScreen.SetRootViewController(_viewController, HMUI.ViewController.AnimationType.None);

            _pauseController.didPauseEvent += OnPause;
            _pauseController.didResumeEvent += OnResume;
            _pauseController.didReturnToMenuEvent += OnReturnToMenu;

            _floatingScreen.gameObject.SetActive(false);
        }

        private void OnReturnToMenu()
        {
            _floatingScreen.gameObject.SetActive(false);
        }

        private void OnResume()
        {
            _floatingScreen.gameObject.SetActive(false);
        }

        private void OnPause()
        {
            _floatingScreen.gameObject.SetActive(true);
        }

        public void Dispose() 
        {
            _pauseController.didPauseEvent -= OnPause;
            _pauseController.didResumeEvent -= OnResume;
            _pauseController.didReturnToMenuEvent -= OnReturnToMenu;
        }
    }
}
