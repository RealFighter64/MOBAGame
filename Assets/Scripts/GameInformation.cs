using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 	A container for all global game information.
/// </summary>
public class GameInformation : MonoBehaviour {

	public Character currCharacter;

	public static CharacterPath currentPath;
	public static HexGrid currentHexGrid;
	public static Character currentCharacter;

	void Awake () {
		DontDestroyOnLoad (gameObject);
		currentHexGrid = Instantiate (GameResources.hexGrid).GetComponent<HexGrid> ();
		currentPath = new CharacterPath ();
		currentCharacter = currCharacter;
	}
}
