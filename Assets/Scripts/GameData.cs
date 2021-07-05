using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu()]
public class GameData : ScriptableObject
{
        public List<Item> ItemDatabase;
        public List<Receipt> ReceiptsDatabase;
        public List<Character> CharactersDatabase;


        private void Awake()
        {
                Initialize();
        }
        
        
        public Character GetRandomCharacter()
        {
                return CharactersDatabase[Random.Range(0, CharactersDatabase.Count)];
        }
        public Receipt GetRandomReceipt()
        {
                return ReceiptsDatabase[Random.Range(0, ReceiptsDatabase.Count)];
        }

        private void Initialize()
        {
                ItemDatabase = GetAllInstances<Item>();
                ReceiptsDatabase = GetAllInstances<Receipt>();
                CharactersDatabase = GetAllInstances<Character>();
                
        }
        public static List<T> GetAllInstances<T>() where T : ScriptableObject
        {
                return Resources.LoadAll<T>("ScriptableObjects/").ToList();
        }

}