using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 	A container for all global game information.
/// </summary>
public class GameInformation : MonoBehaviour {

	public static Path currentPath;
	public static HexGrid currentHexGrid;

	void Awake () {
		DontDestroyOnLoad (gameObject);
		currentHexGrid = Instantiate (GameResources.hexGrid).GetComponent<HexGrid> ();
		currentPath = new Path ();
	}
}
