using System;
using Views;

namespace Presenters
{
    public class MenuViewPresenter : IDisposable
    {
        
        private readonly StartMenuView _view;
        private readonly GameManager _model;

        public MenuViewPresenter(StartMenuView view, GameManager model)
        {
            _view = view;
            _model = model;

            _model.OnGameStarted += GameStartedHandler;
            _model.OnCookSuccess += UpdateScore;
            _model.OnGameFinished += GameFinishedHandler;
        }

        private void GameStartedHandler(GameData obj)
        {
            _view.HideNewGameButton();
        }

        private void GameFinishedHandler()
        {
            _view.ShowNewGameButton();
        }


        private void UpdateScore()
        {
            _view.UpdateScore(_model.CurrentScore);
        }

        public void Dispose()
        {
            _model.OnCookSuccess -= UpdateScore;
            _model.OnGameFinished -= GameFinishedHandler;
            _model.OnGameStarted -= GameStartedHandler;
        }
    }
}