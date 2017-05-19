using UnityEngine;
using System.Collections;

public class HexCell : MonoBehaviour
{
	public HexCoordinates coordinates;
	public Color color;

	SelectedGlow selectedGlow;

	void Start() {
		selectedGlow = GetComponentInChildren<SelectedGlow> ();
	}

	void Update () {
		if (GameInformation.currentPath.InPath (coordinates)) {
			if (GameInformation.currentPath.ValidPath ()) {
				selectedGlow.UpdateCell (this.coordinates, true);
				GameInformation.currentHexGrid.ColorCell (coordinates, new Color (1F, 0.9F, 0.4F));
			} else {
				selectedGlow.UpdateCell (this.coordinates, false);
				GameInformation.currentHexGrid.ColorCell (coordinates, new Color (1F, 0.6F, 0.6F));
			}
		} else {
			selectedGlow.Reset (this.coordinates);
			GameInformation.currentHexGrid.ColorCell (coordinates, new Color (1F, 1F, 1F));
		}
	}
}

