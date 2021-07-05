using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class ItemDatabase : ScriptableObject
{
    public List<Item> items;
}
