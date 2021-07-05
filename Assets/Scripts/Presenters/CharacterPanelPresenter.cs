using System;
using Views;

namespace Presenters
{
	public class CharacterPanelPresenter : IDisposable
	{
		private readonly CharacterPanelView _view;
		private readonly GameManager _model;

		public CharacterPanelPresenter(CharacterPanelView view, GameManager model)
		{
			_view = view;
			_model = model;

			_model.OnCharacterCome += CharacterComeHandler;
			_model.OnGameFinished += GameFinishedHandler;
			_model.OnTimeElapsed += TimeElapsedHandler;

		}

		private void TimeElapsedHandler()
		{
			_view.Hide();
		}

		private void GameFinishedHandler()
		{
			_view.Hide();
		}

		private void CharacterComeHandler(ReceiptRequest request)
		{
			_view.Show(request.Custumer, request.Receipt);
		}

		public void Dispose()
		{
			_model.OnCharacterCome -= CharacterComeHandler;
		}
	}
}
