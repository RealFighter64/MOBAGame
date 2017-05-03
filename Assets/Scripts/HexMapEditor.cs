using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class HexMapEditor : MonoBehaviour {

	public Color[] colors;

	public HexGrid hexGrid;

	private Color activeColor;

	bool prevClick;

	void Awake () {
		SelectColor(0);
	}

	void Update () {
		
		if (Input.GetMouseButton (0) && !EventSystem.current.IsPointerOverGameObject ()) {
			if (prevClick == true) {
				HandleInput ();
			} else {
				ResetPath ();
				HandleInput ();
			}
			prevClick = true;
		} else {
			prevClick = false;
		}
	}

	void ResetPath() {
		GameInformation.currentPath = new CharacterPath ();
	}

	void HandleInput () {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			HexCoordinates hexCoords = HexCoordinates.FromPosition (hit.point);
			if (!GameInformation.currentPath.InPath(hexCoords) && (hexCoords == new HexCoordinates(0, 0) || GameInformation.currentPath.hexCoords.Length > 0)) {
				List<HexCoordinates> coordList = new List<HexCoordinates> ();
				coordList.AddRange (GameInformation.currentPath.hexCoords);
				coordList.Add (hexCoords);
				GameInformation.currentPath = new CharacterPath (coordList.ToArray());
			}
		}
	}

	public void SelectColor (int index) {
		activeColor = colors[index];
	}
}