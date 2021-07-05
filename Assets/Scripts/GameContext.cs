using System;
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
	[SerializeField] private CharacterPanelView _characterPanel;
	[SerializeField] private SlotsStackView _slotsStackView;
	[SerializeField] private ItemStackView _itemStackView;
	[SerializeField] private StartMenuView _startMenuView;
	[SerializeField] private CookingView _cookingView;
	[SerializeField] private NotificationsView _notificationsView;


	private CharacterPanelPresenter _characterPanelPresenter;
	private CookingViewPresenter _cookingViewPresenter;
	private NotificationsViewPresenter _notificationsViewPresenter;
	private MenuViewPresenter _menuViewPresenter;
	private StackViewPanelPresenter _stackViewPanelPresenter;

	private void Awake()
	{
		_gameManager.Initialize(_gameData);
		_characterPanelPresenter = new CharacterPanelPresenter(_characterPanel, _gameManager);
		_cookingViewPresenter = new CookingViewPresenter(_cookingView, _gameManager);
		_notificationsViewPresenter = new NotificationsViewPresenter(_notificationsView, _gameManager);
		_menuViewPresenter = new MenuViewPresenter(_startMenuView, _gameManager);
		_stackViewPanelPresenter = new StackViewPanelPresenter(_itemStackView, _slotsStackView, _gameManager);


		// TODO: Convert other Views.
	}

	private void Start()
	{
		//_gameManager.StartGame();
	}
}
