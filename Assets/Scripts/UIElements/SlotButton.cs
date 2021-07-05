using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

    public class SlotButton : MonoBehaviour, IPointerClickHandler
    {
        
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _background;
        [SerializeField] private Image _icon;
        [SerializeField] private Sprite defaultSprite;
        
        
        private bool _filled;
        public Item Item { get; set; }


        public void InitializeButton(Item item)
        {
            Reset();
            _text.text = item.Name;
        }
        public void Fill()
        {
            _background.color = new Color(0,0,0,0);
            _icon.sprite = Item.Image;
            _icon.color = new Color(1,1,1,1);
            _filled = true;
        }
        
        public void Reset()
        {
            _background.color = new Color(0,0,0,0.25f);
            _icon.sprite = defaultSprite;
            _icon.color = new Color(0,0,0,0.5f);
            Item = null;
            _filled = false;
        }
        
        public bool isFilled()
        {
            return _filled;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (isFilled())
            {
                Reset();
            }
        }
    }
