using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

	public List<Card> cardArray;

	public Transform cardPrefab;
	public int initialCardAmount;

	// Use this for initialization
	void Start () {
		cardArray = new List<Card>();
		for (int i = 0; i < initialCardAmount; i++) {
			DrawCardInitial ();
		}
		UpdateDeck ();
	}
		
	void DrawCardInitial() {
		Character tempCharacter = GameInformation.characterObjects [Random.Range (0, GameInformation.characterObjects.Length)];
		Transform tempCard = Instantiate (cardPrefab) as Transform;
		tempCard.SetParent (this.transform);
		Card tempCardData = tempCard.GetComponent<Card> ();
		tempCardData.Init (tempCharacter);
		cardArray.Add(tempCardData);
	}

	public void DrawCard() {
		Character tempCharacter = GameInformation.characterObjects [Random.Range (0, GameInformation.characterObjects.Length)];
		Transform tempCard = Instantiate (cardPrefab) as Transform;
		tempCard.SetParent (this.transform);
		Card tempCardData = tempCard.GetComponent<Card> ();
		tempCardData.Init (tempCharacter);
		cardArray.Add(tempCardData);
		UpdateDeck ();
	}

	public void UpdateDeck() {
		for (int i = 0; i < cardArray.Count; i++) {
			Card tempCard = cardArray [i];
			tempCard.GetComponent<RectTransform> ().localPosition = new Vector3 (-10 + -138*i, 10);
		}
	}

	void Awake() {

	}
}

