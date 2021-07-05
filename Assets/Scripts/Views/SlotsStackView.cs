using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SlotsStackView : MonoBehaviour
{
    
    public SlotButton slotButtonPrefab;
    public List<GameObject> _slotsGO = new List<GameObject>();

    private Receipt _currentReceipt;
    
    
    public void ShowReceiptSlots(Receipt receipt)
    {
        _currentReceipt = receipt;
        Reset();
        var itemsSequence = receipt.Ingredients;
        foreach (var item in itemsSequence)
        {
            GenerateSlot(item);
        }
    }

    public void RefreshReceiptSlots()
    {
        ShowReceiptSlots(_currentReceipt);
    }
    
    public void FillSlot(Item item)
    {
        foreach (var slotGO in _slotsGO)
        {
            if (!slotGO.GetComponent<SlotButton>().isFilled())
            {
                var slot = slotGO.GetComponent<SlotButton>();
                slot.Item = item;
                slot.Fill();
                break;
            }
        }
    }

    public List<Item> GetFilledSlots()
    {
        var list = new List<Item>();
        foreach (var slotGO in _slotsGO)
        {
            var slot = slotGO.GetComponent<SlotButton>();
            if (slot.isFilled())
            {
                list.Add(slot.Item);
            }
        }

        return list;
    }
    private void GenerateSlot(Item item)
    {
        SlotButton button = Instantiate(slotButtonPrefab, this.transform, false);
        button.name = item.Name + " Slot Button";
        button.InitializeButton(item);
        _slotsGO.Add(button.gameObject);
    }

    public void Reset()
    {
        foreach (var go in _slotsGO)
        {
            Destroy(go);
        }
        _slotsGO.Clear();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
