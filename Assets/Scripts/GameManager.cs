using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Cooking,
        Waiting,
        Over,
        Paused
    }
    public event Action<ReceiptRequest> OnCharacterCome;
    public event Action<GameData> OnGameStarted;
    public event Action OnCook;
    public event Action OnGameFinished;
    public event Action OnCookSuccess;
    public event Action OnCookFail;

    public event Action OnTimeElapsed;
    
    public event Action<GameState> OnGameStateChanged;

   
    [Header("Game parameters")]
    [SerializeField] private int _scoreToWin = 100;

    [SerializeField] private float _defaultTemperature = 25;


    private GameData _gameData;
    private float _timeStarted;
    
    [SerializeField] private float _timeRemaining;

    
    public List<Item> UserItemsSet = new List<Item>();
    public float CurrentTemperature;
    
    private GameState _gameState = GameState.Waiting;
    private Receipt _currentReceipt;


    public int CurrentScore { get; private set; }
    public float GameTime { get; set; }


    

    public void Initialize(GameData gameData)
    {
        _gameData = gameData;
        CurrentTemperature = _defaultTemperature;
        CurrentScore = 0;

    }

    public void StartGame()
    {
        
        OnGameStarted?.Invoke(_gameData);
        CurrentScore = 0;
        
        //ResetDialogText();
        //_scoreText.text = "Score: " + _currentScore;
        _timeStarted = Time.time;
        SetNewRequest();
    }


    private void Update()
    {
        switch (_gameState)
        {
            case GameState.Cooking when _timeRemaining > 0:
                _timeRemaining -= Time.deltaTime;
                break;
            case GameState.Cooking:
                OnTimeElapsed?.Invoke();
                //SendTimeElapsedMessage();
                //_cookingUI.gameObject.SetActive(false);
                _gameState = GameState.Waiting;
                StartCoroutine(WaitForNextRequest(5));
                break;
            case GameState.Waiting:
            {
                if (CurrentScore >= _scoreToWin)
                {
                    _gameState = GameState.Over;
                }

                break;
            }
            case GameState.Over:
                GameOver();
                break;
            case GameState.Paused:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }


    public void SetNewRequest()
    {
        var request = CreateReceiptRequest();
        _currentReceipt = request.Receipt;
        _timeRemaining = _currentReceipt.TimeToFinish;
        _gameState = GameState.Cooking;
        OnCharacterCome?.Invoke(request);

    }
    
    public void Cook()
    {

        OnCook?.Invoke(); // Here we refresh UserItemSet
        
        if (_currentReceipt.Verify(UserItemsSet, CurrentTemperature))
        {
            CurrentScore += _currentReceipt.Price;
            OnCookSuccess?.Invoke();
            _gameState = GameState.Waiting;
            StartCoroutine(WaitForNextRequest(2));
        }
        else
        {
            OnCookFail?.Invoke();
        }
    }



    


 
    

    private ReceiptRequest CreateReceiptRequest()
    {
        return new ReceiptRequest(_gameData.GetRandomCharacter(), _gameData.GetRandomReceipt());
    }

    private Receipt GenerateOrder()
    {
        return _gameData.GetRandomReceipt();
    }

    private void GameOver()
    {
        
        GameTime = Time.time - _timeStarted;
        StopAllCoroutines();
        _gameState = GameState.Paused;
        OnGameFinished?.Invoke();
    }

    


    IEnumerator WaitForNextRequest(float time)
    {
        yield return new WaitForSeconds(time);
        if(_gameState == GameState.Waiting) SetNewRequest();
    }
}

