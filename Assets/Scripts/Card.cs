using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public float scaleFactor;
	public float speedOfGrowth;

	public Character character;

	private Text nameText;
	private Text descriptionText;
	private Text manaCostText;

	private float currentScaleFactor = 1;
	private bool currentlyMouseOver = false;

	private RectTransform rectTransform;

	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform> ();
		nameText = transform.Find ("Name").GetComponent<Text> ();
		descriptionText = transform.Find ("Description").GetComponent<Text> ();
		manaCostText = transform.Find ("Mana Cost").GetComponent<Text> ();
	}

	public void Init (Character character) {
		this.character = character;
	}

	// Update is called once per frame
	void Update () {
		rectTransform.localScale = new Vector3 (currentScaleFactor, currentScaleFactor, currentScaleFactor);
		if (currentlyMouseOver) {
			if (currentScaleFactor < scaleFactor) {
				currentScaleFactor += speedOfGrowth;
			}
		} else {
			if (currentScaleFactor > 1) {
				currentScaleFactor -= speedOfGrowth;
			}
		}
		UpdateCardInformation ();
	}

	void UpdateCardInformation() {
		nameText.text = character.name;
		descriptionText.text = "Lorem Ipsum";
		manaCostText.text = character.manaCost.ToString();
	}

	public void OnPointerEnter(PointerEventData eventData) {
		currentlyMouseOver = true;
	}

	public void OnPointerExit(PointerEventData eventData) {
		currentlyMouseOver = false;
	}

	public void Spawn(){
		int manaCost = character.manaCost;
		if (GameInformation.player1Turn == true && manaCost <= GameInformation.currentMana1) {
			Character initialCharacter = Instantiate(character.gameObject).GetComponent<Character>();
			initialCharacter.name = Time.time.ToString();
			GameInformation.SpawnCharacter(initialCharacter);
			GameInformation.currentMana1 -= manaCost;
			GameInformation.cardDeck.cardArray.Remove (this);
			GameInformation.cardDeck.UpdateDeck ();
			Destroy (this.gameObject);
		}
		if (GameInformation.player1Turn == false && manaCost <= GameInformation.currentMana2) {
			Character initialCharacter = Instantiate(character.gameObject).GetComponent<Character>();
			initialCharacter.name = Time.time.ToString();
			GameInformation.SpawnCharacter(initialCharacter);
			GameInformation.currentMana2 -= manaCost;
			GameInformation.cardDeck.cardArray.Remove (this);
			GameInformation.cardDeck.UpdateDeck ();
			Destroy (this.gameObject);
		}
	}
}