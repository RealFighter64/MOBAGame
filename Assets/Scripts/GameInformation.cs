using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS_Cam;

/// <summary>
/// 	A container for all global game information.
/// </summary>
public class GameInformation : MonoBehaviour {
	public static CharacterPath currentPath;
	public static CharacterPath currentAttackPath;
	public static Character currentlySelectedCharacter;
	public static HexGrid currentHexGrid;
	public static RTS_Camera currentCamera;
	public static AttackButton attackButton;
	public static int turnNumber;

	public static bool player1Turn { get { return turnNumber % 2 == 1; } }

	public static bool attackMode;

	public static List<Character> characters;

	void Awake () {
		DontDestroyOnLoad (gameObject);
		currentHexGrid = Instantiate (GameResources.hexGrid).GetComponent<HexGrid> ();
		currentHexGrid.transform.position = Vector3.zero;
		currentCamera = Instantiate (GameResources.rtsCamera).GetComponent<RTS_Camera> ();
		currentCamera.transform.position = new Vector3 (10, 10, 10);
		currentCamera.transform.rotation = Quaternion.Euler (60, 0, 0);
		currentPath = new CharacterPath ();
		currentAttackPath = new CharacterPath ();
		characters = new List<Character> ();
		attackMode = false;
		attackButton = currentHexGrid.GetComponentInChildren<AttackButton> ();
		currentlySelectedCharacter = null;
		turnNumber = 1;
	}

	public static void SpawnCharacter(Character character) {
		character.team1 = player1Turn;
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
	}
}
