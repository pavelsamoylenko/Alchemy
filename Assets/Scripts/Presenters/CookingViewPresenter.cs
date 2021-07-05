using System;
using Views;

namespace Presenters
{
    public class CookingViewPresenter : IDisposable
    {
        private readonly CookingView _view;
        private readonly GameManager _model;

        public CookingViewPresenter(CookingView view, GameManager model)
        {
            _view = view;
            _model = model;


            _model.OnGameStarted += GameStartedHandler;
            _model.OnCook += CookHandler;
            _model.OnCharacterCome += CharacterComeHandler;
            _model.OnGameFinished += GameFinishedHandler;
            _model.OnCookSuccess += HideCookButton;
            _model.OnTimeElapsed += HideCookButton;
        }
        

        private void CharacterComeHandler(ReceiptRequest obj)
        {
            _view.ShowCookButton();
        }

        private void HideCookButton()
        {
            _view.HideCookButton();
        }


        private void GameFinishedHandler()
        {
            _view.Hide();
        }

        private void CookHandler()
        {
            _model.CurrentTemperature = _view.CurrentTemperature;
        }

        private void GameStartedHandler(GameData obj)
        {
            _view.Show();
        }

        public void Dispose()
        {
            _model.OnGameStarted -= GameStartedHandler;
            _model.OnCook -= CookHandler;
            _model.OnGameFinished -= GameFinishedHandler;
            _model.OnCookSuccess -= HideCookButton;
            _model.OnCharacterCome -= CharacterComeHandler;
            _model.OnTimeElapsed -= HideCookButton;
        }
    }
}
