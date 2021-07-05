using System;
using Views;

namespace Presenters
{
    public class NotificationsViewPresenter : IDisposable
    {
        
        private readonly NotificationsView _view;
        private readonly GameManager _model;

        public NotificationsViewPresenter(NotificationsView view, GameManager model)
        {
            _view = view;
            _model = model;

            _model.OnCookSuccess += SendSuccessMessage;
            _model.OnCookFail += SendFailMessage;
            _model.OnTimeElapsed += SendTimeElapsedMessage;
            _model.OnGameFinished += SendWinMessage;
        }
        
        public void SendSuccessMessage()
        {
            _view.PostMessage("Well Done");
        }
    
        public void SendFailMessage()
        {
            _view.PostMessage("Something went wrong. Try again.");
            
        }
    
        public void SendTimeElapsedMessage()
        {
            _view.PostMessage("Customer left");
        }
        
        public void SendWinMessage()
        {
            _view.PostMessage("You won! Your time is: " + _model.GameTime);
        }
        
        public void ResetDialogText()
        {
            _view.PostMessage(" ");
        }

        
        public void SendMessage(string text)
        {
            _view.PostMessage(text);
        }

        public void Dispose()
        {
            _model.OnCookSuccess -= SendSuccessMessage;
            _model.OnCookFail -= SendFailMessage;
            _model.OnTimeElapsed -= SendTimeElapsedMessage;
            _model.OnGameFinished -= SendWinMessage;
        }
    }
}