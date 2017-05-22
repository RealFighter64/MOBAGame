using UnityEngine;
using System.Collections;

public class HexCell : MonoBehaviour
{
	public HexCoordinates coordinates;
	public Color color;

	bool prevColoured;

	SelectedGlow selectedGlow;
	bool focus;

	void Start() {
		selectedGlow = GetComponentInChildren<SelectedGlow> ();
		prevColoured = true;
	}

	void Update () {
		try {
			focus = GameInformation.currentlySelectedCharacter.position == coordinates;
		} catch {
			focus = false;
		}
		if (GameInformation.currentPath.InPath (coordinates)) {
			if (GameInformation.currentPath.ValidPath ()) {
				selectedGlow.UpdateCell (this.coordinates, true, false);
				GameInformation.currentHexGrid.ColorCell (coordinates, new Color (1F, 0.9F, 0.4F));
			} else {
				selectedGlow.UpdateCell (this.coordinates, false, false);
				GameInformation.currentHexGrid.ColorCell (coordinates, new Color (1F, 0.4F, 0.4F));
			}
			prevColoured = true;
		} else if (GameInformation.currentAttackPath.InPath (coordinates)) {
			selectedGlow.UpdateCell (this.coordinates, true, true);
			GameInformation.currentHexGrid.ColorCell (coordinates, new Color (1F, 0.4F, 0.4F));
		} else if (focus) {
			selectedGlow.Reset (this.coordinates);
			selectedGlow.InitFocus (this.coordinates);
			GameInformation.currentHexGrid.ColorCell (coordinates, new Color (0.4F, 0.4F, 1F));
		} else {
			if (prevColoured) {
				selectedGlow.Reset (this.coordinates);
				GameInformation.currentHexGrid.ColorCell (coordinates, new Color (0.25F, 0.29F, 0.15F));
				prevColoured = false;
			}
		}
	}
}

