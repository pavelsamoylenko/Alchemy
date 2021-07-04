using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public event Action<ReceiptRequest> OnCharacterCome;

    [SerializeField] private SlotsStackViewController _slotsStackViewController;
    [SerializeField] private ItemStackViewController _itemStackViewController;
    [SerializeField] private FlaskUI _flaskUI;
    [SerializeField] private CookingUI _cookingUI;
    [SerializeField] private GameObject _startGameButton;
    [SerializeField] private Image timerImage;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [Header("Game parameters")]
    [SerializeField] private int _scoreToWin = 100;


    private ReceiptsDatabase _receiptsDatabase;
    private CharactersDatabase _charactersDatabase;
    private float _timeStarted;

    [SerializeField] private float _timeRemaining;

    private GameState _gameState = GameState.Waiting;
    private Receipt _currentReceipt;

    private int _currentScore = 0;


    public enum GameState
    {
        Cooking,
        Waiting,
        Over,
        Paused
    }

    public void Initialize(ItemDatabase receiptsDatabase)
    {

    }

    private void Start()
    {
        _receiptsDatabase = GetComponent<ReceiptsDatabase>();
        _charactersDatabase = GetComponent<CharactersDatabase>();
        StartGame();
    }

    public void StartGame()
    {
        ShowGameUI();
        _currentScore = 0;
        ResetDialogText();
        _scoreText.text = "Score: " + _currentScore;
        _timeStarted = Time.time;
        SetNewRequest();
    }


    private void Update()
    {
        switch (_gameState)
        {
            case GameState.Cooking when _timeRemaining > 0:
                _timeRemaining -= Time.deltaTime;
                TimerImageUpdate();
                break;
            case GameState.Cooking:
                SendTimeElapsedMessage();
                _cookingUI.gameObject.SetActive(false);
                _gameState = GameState.Waiting;
                StartCoroutine(WaitForNextRequest(5));
                break;
            case GameState.Waiting:
            {
                if (_currentScore >= _scoreToWin)
                {
                    _gameState = GameState.Over;
                }

                break;
            }
            case GameState.Over:
                GameOver();
                HideGameUI();
                break;
            case GameState.Paused:
                ShowStartGameUI();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void ShowStartGameUI()
    {

        _startGameButton.SetActive(true);
    }

    public void HideGameUI()
    {
        _slotsStackViewController.gameObject.SetActive(false);
        _itemStackViewController.gameObject.SetActive(false);
        _cookingUI.gameObject.SetActive(false);
        _flaskUI.gameObject.SetActive(false);

    }

    public void ShowGameUI()
    {
        _startGameButton.SetActive(false);
        _slotsStackViewController.gameObject.SetActive(true);
        _itemStackViewController.gameObject.SetActive(true);
        _cookingUI.gameObject.SetActive(true);
        _flaskUI.gameObject.SetActive(true);
    }


    public void SetNewRequest()
    {
        var request = CreateReceiptRequest();
        _gameState = GameState.Cooking;

        OnCharacterCome?.Invoke(request);

        // TODO: Remove under
        SetReceipt(request.Receipt);
        DisplayTimer();
        TimerImageUpdate();
        _cookingUI.gameObject.SetActive(true);
        _cookingUI.SetCookingUI(request);
    }

    public void SetReceipt(Receipt receipt)
    {
        ResetDialogText();
        _currentReceipt = receipt;
        _timeRemaining = receipt.TimeToFinish;
        _slotsStackViewController.Reset();
        _slotsStackViewController.SetReceipt(receipt);
    }


    public void Cook()
    {

        _slotsStackViewController.RefreshUserItems();
        if (_currentReceipt.Validate(_slotsStackViewController.UserItemsSet, _flaskUI.CurrentTemperature))
        {
            SendSuccessMessage();
            _cookingUI.DisableCook();
            _currentScore += _currentReceipt.Price;
            UpdateScoreUI();
            _gameState = GameState.Waiting;
            StartCoroutine(WaitForNextRequest(2));
        }
        else
        {
            _slotsStackViewController.RefreshSlots();
            SendFailMessage();
        }
    }

    private void UpdateScoreUI()
    {
        _scoreText.text = "Score: " + _currentScore;
    }

    private void SendSuccessMessage()
    {
        _dialogText.text = "Well Done";
    }

    private void SendFailMessage()
    {
        _dialogText.text = "Something went wrong. Try again.";
    }

    private void SendTimeElapsedMessage()
    {
        _dialogText.text = "Customer left";
    }


    private void DisplayTimer()
    {
        timerImage.gameObject.SetActive(true);

    }

    private void TimerImageUpdate()
    {
        timerImage.fillAmount = _timeRemaining / _currentReceipt.TimeToFinish;
    }


    private ReceiptRequest CreateReceiptRequest()
    {
        return new ReceiptRequest(_charactersDatabase.RandomCharacter(), _receiptsDatabase.RandomReceipt());
    }

    private Receipt GenerateOrder()
    {
        return _receiptsDatabase.RandomReceipt();
    }

    private void GameOver()
    {
        _gameState = GameState.Paused;
        var gameTime = Time.time - _timeStarted;
        _dialogText.text = "You won! Time: " + gameTime + " seconds";
    }

    private void ResetDialogText()
    {
        _dialogText.text = " ";
    }


    IEnumerator WaitForNextRequest(float time)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);
        if(_gameState == GameState.Waiting) SetNewRequest();
    }
}

