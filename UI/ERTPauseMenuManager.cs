using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.FloatingScreen;
using System;
using UnityEngine;
using Zenject;

namespace EmoteRainToggle.UI
{
    internal class ERTPauseMenuManager : IInitializable, IDisposable
    {
        private ERTPauseMenuViewController _viewController;
        private FloatingScreen _floatingScreen;

        private PauseController _pauseController;
        private PauseMenuManager _pauseMenuManager;


        private ERTPauseMenuManager(PauseController pauseController, PauseMenuManager pauseMenuManager)
        {
            _pauseController = pauseController;
            _pauseMenuManager = pauseMenuManager;
        }

        public void Initialize()
        {
            _viewController = BeatSaberUI.CreateViewController<ERTPauseMenuViewController>();

            _floatingScreen = FloatingScreen.CreateFloatingScreen(
                new Vector2(100, 25),
                false,
                new Vector3(0, 0.85f, 1.9f),
                Quaternion.identity);

            _viewController._FloatingScreen = _floatingScreen;

            _floatingScreen.SetRootViewController(_viewController, HMUI.ViewController.AnimationType.None);

            _pauseController.didPauseEvent += OnShowPauseMenu;
            _pauseMenuManager.didPressContinueButtonEvent += OnHidePauseMenu;
            _pauseMenuManager.didPressMenuButtonEvent += OnHidePauseMenu;
            _pauseMenuManager.didPressRestartButtonEvent += OnHidePauseMenu;

            _floatingScreen.gameObject.SetActive(false);
        }

        public void Dispose()
        {
            _pauseController.didPauseEvent -= OnShowPauseMenu;
            _pauseMenuManager.didPressContinueButtonEvent -= OnHidePauseMenu;
            _pauseMenuManager.didPressMenuButtonEvent -= OnHidePauseMenu;
            _pauseMenuManager.didPressRestartButtonEvent -= OnHidePauseMenu;
        }

        private void OnHidePauseMenu()
        {
            _floatingScreen.gameObject.SetActive(false);
        }

        private void OnShowPauseMenu()
        {
            _floatingScreen.gameObject.SetActive(true);
        }

        private void OnReturnToMenu()
        {
            _floatingScreen.gameObject.SetActive(false);
        }
    }
}
