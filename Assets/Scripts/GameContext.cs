using Presenters;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Views;

public class GameContext : MonoBehaviour
{
	[SerializeField]
	private GameManager _gameManager;

	[Header("DBs")]
	
	[SerializeField]
	private GameData _gameData;

	[Header("UI")]
	[SerializeField]
	private CharacterPanelView _characterPanel;
	[FormerlySerializedAs("_slotsStackViewController")] [SerializeField] private SlotsStackView _slotsStackView;
	[FormerlySerializedAs("_itemStackViewController")] [SerializeField] private ItemStackView _itemStackView;
	[SerializeField] private FlaskUI _flaskUI;
	[SerializeField] private CookingUI _cookingUI;
	[SerializeField] private GameObject _startGameButton;
	[SerializeField] private Image timerImage;
	[SerializeField] private TextMeshProUGUI _scoreText;
	[SerializeField] private TextMeshProUGUI _dialogText;


	private CharacterPanelPresenter _characterPanelPresenter;

	private void Awake()
	{
		_gameManager.Initialize(_gameData);

		_characterPanelPresenter = new CharacterPanelPresenter(_characterPanel, _gameManager);
		// TODO: Convert other Views.
	}
}
