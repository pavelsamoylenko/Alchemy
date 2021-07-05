using System;
using System.Collections.Generic;
using Views;

namespace Presenters
{
	public class StackViewPanelPresenter : IDisposable
	{
		private readonly ItemStackView _itemStackView;
		private readonly SlotsStackView _slotsStackView;
		private readonly GameManager _model;

		public StackViewPanelPresenter(ItemStackView itemStackView, SlotsStackView slotsStackView, GameManager model)
		{
			_itemStackView = itemStackView;
			_slotsStackView = slotsStackView;
			_model = model;

			_model.OnGameStarted += GameStartedHandler;
			_model.OnCharacterCome += CharacterComeHandler;
			_model.OnGameFinished += GameFinishedHandler;
			_model.OnCook += CookHandler;
			_model.OnCookFail += FailHandler;
		}

		private void FailHandler()
		{
			_slotsStackView.RefreshReceiptSlots();
		}

		private void CookHandler()
		{
			_model.UserItemsSet = _slotsStackView.GetFilledSlots();
		}

		private void GameFinishedHandler()
		{
			_slotsStackView.Hide();
			_itemStackView.Hide();
		}

		private void CharacterComeHandler(ReceiptRequest request)
		{
			_slotsStackView.ShowReceiptSlots(request.Receipt);
		}

		private void GameStartedHandler(GameData gameData)
		{
			_slotsStackView.Show();
			_itemStackView.Show();
			_itemStackView.GenerateItemButtons(gameData.ItemDatabase);
		}

		public void Dispose()
		{
			_model.OnCharacterCome -= CharacterComeHandler;
		}
	}
}
