using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class ReceiptsDatabase : MonoBehaviour
{
    public List<Receipt> receipts;

    private void Awake()
    {
        receipts = Receipt.GetAllInstances();
        Debug.Log("Receipts database created: " + receipts);
        
    }

    public Receipt RandomReceipt()
    {
        return receipts[Random.Range(0, receipts.Count)];
    }

    
}