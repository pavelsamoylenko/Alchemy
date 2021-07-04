using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
	public class CharacterPanelView : MonoBehaviour
	{
		[SerializeField]
		private Image _character;
		[SerializeField]
		private TextMeshProUGUI _characterMessage;

		[SerializeField]
		private Image _timer;

		public void Show(Character character, Receipt requestReceipt)
		{
			_character.sprite = character.Image;
			_characterMessage.text = character.Text;

			// TODO: Receipt
			// TODO: Timer
			// requestReceipt.TimeToFinish;
		}

		public void Hide()
		{

		}
	}
}
