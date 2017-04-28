using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path
{
	[SerializeField]
	public HexCoordinates[] hexCoords;

	public Path (HexCoordinates[] hexCoords) {
		this.hexCoords = hexCoords;
	}

	public bool InPath (HexCoordinates coords) {
		for (int i = 0; i < hexCoords.Length; i++) {
			if (hexCoords [i] == coords) {
				return true;
			}
		}
		return false;
	}
}

