using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
	public class CharacterPanelView : MonoBehaviour
	{
		[SerializeField] private Image _character;
		[SerializeField] private TextMeshProUGUI _characterMessage;
		
		[SerializeField] private Image _receiptImage;
		[SerializeField] private TextMeshProUGUI _receiptText;

		[SerializeField] private Image _timer;


		private float _timeToFinish;
		private float _timeRemaining;

		private void Update()
		{
			_timeRemaining -= Time.deltaTime;
			if(_timeRemaining >= 0) TimerImageUpdate();
		}

		public void Show(Character character, Receipt receipt)
		{
			gameObject.SetActive(true);
			_character.sprite = character.Image;
			_characterMessage.text = character.Text + " " + receipt.Name;
			_receiptImage.sprite = receipt.Image;
			_receiptText.text = SetReceiptText(receipt);

			_timeRemaining = _timeToFinish = receipt.TimeToFinish;
			TimerImageUpdate();
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}
		
		private void TimerImageUpdate()
		{
			_timer.fillAmount = _timeRemaining / _timeToFinish;
		}

		private string SetReceiptText(Receipt receipt)
		{
			var items = receipt.Ingredients;
			var text = "At a temperature near " + receipt.TargetTemperature + "˚";
			text += " mix ";

			for (int item = 0; item < items.Count; item++)
			{
				if (item != items.Count - 1)
				{
					_receiptText.text += (items[item].Name + ".");
				}
				else if (item != items.Count - 2)
				{
					_receiptText.text += (items[item].Name + "and ");
				}
				else
				{
					_receiptText.text += (items[item].Name + ", ");
				}
			}

			return text;
		}

	}
}
