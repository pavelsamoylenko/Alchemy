using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class StartMenuView : MonoBehaviour
    {
        [SerializeField] private GameObject _startGameButton;

        [SerializeField] private TextMeshProUGUI _scoreText;

        public void ShowNewGameButton()
        {
            _startGameButton.SetActive(true);
        }

        public void HideNewGameButton()
        {
            _startGameButton.SetActive(false);
        }

        public void UpdateScore(int score)
        {
            _scoreText.text = "Score: " + score;
        }
    }
}