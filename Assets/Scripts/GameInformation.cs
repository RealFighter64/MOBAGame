using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS_Cam;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// 	A container for all global game information.
/// </summary>
public class GameInformation : MonoBehaviour {
	public static CharacterPath currentPath;
	public static CharacterPath currentAttackPath;
	public static Character currentlySelectedCharacter;
	public static HexGrid currentHexGrid;
	public HexGrid defaultHexGrid;
	public static Text manaText;
	public static RTS_Camera currentCamera;
	public static RTS_Camera player1Camera;
	public static RTS_Camera player2Camera;
	public static GameObject cardPanelPlayer1;
	public static GameObject cardPanelPlayer2;
	public RTS_Camera defaultPlayer1Camera;
	public RTS_Camera defaultPlayer2Camera;
	public GameObject defaultCardPanelPlayer1;
	public GameObject defaultCardPanelPlayer2;
	public static AttackButton attackButton;
	public static int turnNumber;
	public static int maximumMana1;
    public static int maximumMana2;
	public static int currentMana1;
    public static int currentMana2;

	public static Character[] characterObjects = new Character[2];

	public static Deck cardDeck;

    public static bool SoldierOrMana = true;

    public static bool player1Turn { get { return turnNumber % 2 == 1; } }

	public static bool attackMode;

	public static List<Character> characters;

	void Awake () {
		currentHexGrid = defaultHexGrid;
		player1Camera = defaultPlayer1Camera;
		player2Camera = defaultPlayer2Camera;
		cardPanelPlayer1 = defaultCardPanelPlayer1;
		cardPanelPlayer2 = defaultCardPanelPlayer2;
		player2Camera.gameObject.SetActive (false);
		currentCamera = player1Camera;
		currentPath = new CharacterPath ();
		currentAttackPath = new CharacterPath ();
		characters = new List<Character> ();
		attackMode = false;
		attackButton = currentHexGrid.GetComponentInChildren<AttackButton> ();
		currentlySelectedCharacter = null;
		turnNumber = 1;
		manaText = currentHexGrid.transform.Find ("Hex Map Editor/Mana Text").GetComponent<Text>();
		maximumMana1 = 1;
        maximumMana2 = 1;
		currentMana1 = maximumMana1;
        currentMana2 = maximumMana2;
		characterObjects [0] = GameResources.wolfCharacter.GetComponent<Character>();
		characterObjects [1] = GameResources.dragonCharacter.GetComponent<Character>();
		cardDeck = currentHexGrid.GetComponentInChildren<Deck> ();
    }

	void Update() {
        if (player1Turn == true)
        {
			manaText.text = "Current Mana: " + currentMana1 + " / " + maximumMana1;
        } else
        {
			manaText.text = "Current Mana: " + currentMana2 + " / " + maximumMana2;
        }
            
	}

	public static void SpawnCharacter(Character character) {
		character.team1 = player1Turn;
		if (character.team1) {
			character.startingPosition = new HexCoordinates (0, 0);
		} else {
			character.startingPosition = HexCoordinates.FromOffsetCoordinates (currentHexGrid.width-1, currentHexGrid.height-1);
			character.transform.rotation = Quaternion.Euler (0, 180, 0);
		}
		characters.Add (character);
	}

	public static int IndexOfCharacter(Character character) {
		return characters.IndexOf (character);
	}

	public static void ResetAttackingPath() {
		attackMode = false;
		currentAttackPath = new CharacterPath ();
	}

	public static int IndexOfCharacter(HexCoordinates coords) {
		for (int i = 0; i < characters.Count; i++) {
			if (characters [i].position == coords) {
				return i;
			}
		}
		return -1;
	}

	public static void PlayerTurn() {
		turnNumber++;
		if (player1Turn) {
			currentCamera.gameObject.SetActive (false);
			currentCamera = player1Camera;
			currentCamera.gameObject.SetActive (true);
			cardPanelPlayer1.SetActive (true);
			cardDeck = cardPanelPlayer1.GetComponent<Deck> ();
			cardPanelPlayer2.SetActive(false);
		} else {
			currentCamera.gameObject.SetActive (false);
			currentCamera = player2Camera;
			currentCamera.gameObject.SetActive (true);
			cardPanelPlayer1.SetActive(false);
			cardDeck = cardPanelPlayer2.GetComponent<Deck> ();
			cardPanelPlayer2.SetActive(true);
		}
		currentHexGrid.GetComponentInChildren<HexMapEditor>().currentCamera = GameInformation.currentCamera.GetComponent<Camera> ();

		cardDeck.DrawCard ();

		//if (player1Turn)
			//maximumMana++;

		currentMana1 = maximumMana1;
        currentMana2 = maximumMana2;

		foreach (Character character in characters) {
			character.attacked = false;
			character.moved = false;
			character.sleeping = false;
		}
	}
}
