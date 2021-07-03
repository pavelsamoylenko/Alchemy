using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;

public class ItemButton : MonoBehaviour, IPointerClickHandler
{
    public ItemStackViewController ItemStackViewController;
    public Item Item { get; set; }

    public void InitializeButton(Item item)
    {
        this.Item = item;
        this.name = item.Name + " Item Button";
        this.GetComponentInChildren<TextMeshProUGUI>().text = item.Name;
        this.GetComponent<Image>().sprite = item.Image;
        
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        ItemStackViewController.SendItemToSlot(this.Item);
    }
}