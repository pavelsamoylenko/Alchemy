using System.Collections;
using TMPro;
using UnityEngine;

namespace Views
{
    public class NotificationsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dialogText;
        private Coroutine _coroutine;


        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void PostMessage(string text)
        {
            if(_coroutine != null) 
                StopCoroutine(_coroutine);
            _dialogText.text = text;
            _coroutine = StartCoroutine(Wait(4));
            
        }
        
        IEnumerator Wait(float time)
        {
            yield return new WaitForSeconds(time);
            Reset();
        }

        private void Reset()
        {
            _dialogText.text = "";
        }
    }
}