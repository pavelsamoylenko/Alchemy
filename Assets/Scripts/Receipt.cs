using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptableObjects/Receipt")]
public class Receipt : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Image;
    public float TargetTemperature = 30;
    public float TimeToFinish = 10;
    public int Price;
    
    [FormerlySerializedAs("Ingridients")] public List<Item> Ingredients;
    
    private float _temperatureOffset = 5f;

    public bool Validate(List<Item> userSet, float temperature)
    {
        
        return (userSet.SequenceEqual(Ingredients) &&
               (temperature < TargetTemperature + _temperatureOffset &&
                temperature > TargetTemperature - _temperatureOffset));
    }
    public static List<Receipt> GetAllInstances()
    {
        var guids = AssetDatabase.FindAssets("t:"+ typeof(Receipt).Name);  //FindAssets uses tags check documentation for more info
        var a = new List<Receipt>();
        for(var i = 0; i < guids.Length; i++)         //probably could get optimized 
        {
            var path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a.Add(AssetDatabase.LoadAssetAtPath<Receipt>(path));
        }
 
        return a;
 
    }
    
}