using Presenters;
using UnityEngine;
using Views;

public class GameContext : MonoBehaviour
{
	[SerializeField]
	private GameManager _gameManager;

	[Header("DBs")]
	[SerializeField]
	private ItemDatabase _itemDatabase;

	[Header("UI")]
	[SerializeField]
	private CharacterPanelView _characterPanel;


	private CharacterPanelPresenter _characterPanelPresenter;

	private void Awake()
	{
		_gameManager.Initialize(_itemDatabase);

		_characterPanelPresenter = new CharacterPanelPresenter(_characterPanel, _gameManager);
		// TODO: Convert other Views.
	}
}
