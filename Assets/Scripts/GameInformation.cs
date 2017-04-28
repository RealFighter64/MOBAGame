using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 	A container for all global game information.
/// </summary>
public class GameInformation : MonoBehaviour {

	public static Path currentPath;

	void Awake () {
		DontDestroyOnLoad (gameObject);
		HexCoordinates[] coords = new HexCoordinates[6];
		coords [0] = new HexCoordinates (0, 0);
		coords [1] = new HexCoordinates (1, 0);
		coords [2] = new HexCoordinates (1, 1);
		coords [3] = new HexCoordinates (1, 2);
		coords [4] = new HexCoordinates (1, 3);
		coords [5] = new HexCoordinates (2, 3);
		currentPath = new Path (coords);
	}
}
