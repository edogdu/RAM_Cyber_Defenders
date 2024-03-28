using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUnitySpace;
using Random = UnityEngine.Random;

namespace CustomUnitySpace
{
    public class ShuffleCards
    {
        public List<GameObject> deck = new List<GameObject>();
        public List<GameObject> reorrderDeck = new List<GameObject>();
        public List<GameObject> cardPrefabs;

        public List<GameObject> InitializeDeck(List<GameObject> cardPrefabs)
        {
            deck.AddRange(cardPrefabs);

            for (int i = 0; i < deck.Count - 1; i++)
            {
                int randomNum = Random.Range(i, deck.Count);

                // Swap the cards at positions i and randomNum
                GameObject temp = deck[i];
                deck[i] = deck[randomNum];
                deck[randomNum] = temp;
                Debug.Log(i);
            }

            reorrderDeck.AddRange(deck);
            return reorrderDeck;
        }
    }









}
