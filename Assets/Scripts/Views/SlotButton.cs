using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

    public class SlotButton : MonoBehaviour, IPointerClickHandler
    {
        public Image _background;
        public Image _icon;
        public Item Item { get; set; }
        public Sprite defaultSprite;
        private bool _filled;
        

        private void Start()
        {
            
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
