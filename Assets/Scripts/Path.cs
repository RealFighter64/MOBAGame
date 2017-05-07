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

	public Path () {
		this.hexCoords = new HexCoordinates[0];
	}

	public bool InPath (HexCoordinates coords) {
		for (int i = 0; i < hexCoords.Length; i++) {
			if (hexCoords [i] == coords) {
				return true;
			}
		}
		return false;
	}

	public void Print() {
		string stringToPrint = "Path: ";
		for (int i = 0; i < hexCoords.Length; i++) {
			stringToPrint += hexCoords[i].ToString () + ", ";
		}
		Debug.Log (stringToPrint);
	}
}

