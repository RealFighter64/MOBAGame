using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 	A container for all global game information.
/// </summary>
public class GameInformation : MonoBehaviour {

	public Character initialCharacter;

	public static CharacterPath currentPath;
	public static HexGrid currentHexGrid;

	public static List<Character> characters;

	void Awake () {
		DontDestroyOnLoad (gameObject);
		currentHexGrid = Instantiate (GameResources.hexGrid).GetComponent<HexGrid> ();
		currentPath = new CharacterPath ();
		characters = new List<Character> ();
		SpawnCharacter (initialCharacter);
	}

	public static void SpawnCharacter(Character character) {
		characters.Add (character);
	}

	public static int IndexOfCharacter(Character character) {
		return characters.IndexOf (character);
	}

	public static int IndexOfCharacter(HexCoordinates coords) {
		for (int i = 0; i < characters.Count; i++) {
			if (characters [i].position == coords) {
				return i;
			}
		}
		return -1;
	}
}
