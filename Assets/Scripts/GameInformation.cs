using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS_Cam;
using UnityEngine.Networking;

/// <summary>
/// 	A container for all global game information.
/// </summary>
public class GameInformation : MonoBehaviour {
	public static CharacterPath currentPath;
	public static CharacterPath currentAttackPath;
	public static Character currentlySelectedCharacter;
	public static HexGrid currentHexGrid;
	public HexGrid defaultHexGrid;
	public static RTS_Camera currentCamera;
	public static RTS_Camera player1Camera;
	public static RTS_Camera player2Camera;
	public RTS_Camera defaultPlayer1Camera;
	public RTS_Camera defaultPlayer2Camera;
	public static AttackButton attackButton;
	public static int turnNumber;
	public static int maximumMana;
	public static int currentMana;

	public static bool player1Turn { get { return turnNumber % 2 == 1; } }

	public static bool attackMode;

	public static List<Character> characters;

	void Awake () {
		currentHexGrid = defaultHexGrid;
		player1Camera = defaultPlayer1Camera;
		player2Camera = defaultPlayer2Camera;
		player2Camera.gameObject.SetActive (false);
		currentCamera = player1Camera;
		currentPath = new CharacterPath ();
		currentAttackPath = new CharacterPath ();
		characters = new List<Character> ();
		attackMode = false;
		attackButton = currentHexGrid.GetComponentInChildren<AttackButton> ();
		currentlySelectedCharacter = null;
		turnNumber = 1;
		maximumMana = 1;
		currentMana = maximumMana;
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
		} else {
			currentCamera.gameObject.SetActive (false);
			currentCamera = player2Camera;
			currentCamera.gameObject.SetActive (true);
		}
		currentHexGrid.GetComponentInChildren<HexMapEditor>().currentCamera = GameInformation.currentCamera.GetComponent<Camera> ();

		if (player1Turn)
			maximumMana++;

		currentMana = maximumMana;

		foreach (Character character in characters) {
			character.attacked = false;
			character.moved = false;
			character.sleeping = false;
		}
	}
}
