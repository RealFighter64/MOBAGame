using UnityEngine;
using System.Collections;

public class HexCell : MonoBehaviour
{
	public HexCoordinates coordinates;
	public Color color;

	void Update () {
		if (GameInformation.currentPath.InPath (coordinates)) {
			GetComponentInChildren<SelectedGlow> ().UpdateCell (this.coordinates);
			GameInformation.currentHexGrid.ColorCell (coordinates, new Color (1F, 0.9F, 0.4F));
		} else {
			GetComponentInChildren<SelectedGlow> ().Reset (this.coordinates);
			GameInformation.currentHexGrid.ColorCell (coordinates, new Color (1F, 1F, 1F));
		}
	}
}

