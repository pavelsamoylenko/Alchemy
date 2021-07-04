using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "ScriptableObjects/Character")]
public class Character : ScriptableObject
{
        public string Name;
        public Sprite Image;
        public string Text;
        
        public static List<Character> GetAllInstances()
        {
                return Resources.LoadAll<Character>("ScriptableObjects/").ToList();
        }
}