using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class HexMapEditor : MonoBehaviour {

	public Color[] colors;

	public HexGrid hexGrid;

	private Color activeColor;

	private Character currentCharacter;

	bool prevClick;

	bool pathStarted;

	void Awake () {
		SelectColor(0);
		pathStarted = false;
	}

	void Update () {
		
		if (Input.GetMouseButton (0) && !EventSystem.current.IsPointerOverGameObject ()) {
			if (prevClick == true) {
				HandleInput ();
			} else {
				ResetPath ();
				HandleFirstInput ();
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
			if (pathStarted) {
				if (!GameInformation.currentPath.InPath (hexCoords)) {
					List<HexCoordinates> coordList = new List<HexCoordinates> ();
					coordList.AddRange (GameInformation.currentPath.hexCoords);
					coordList.Add (hexCoords);
					GameInformation.currentPath = new CharacterPath (coordList.ToArray (), currentCharacter);
				}
			}
		}
	}

	void HandleFirstInput() {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (inputRay, out hit)) {
			HexCoordinates hexCoords = HexCoordinates.FromPosition (hit.point);
			if (GameInformation.IndexOfCharacter (hexCoords) != -1) {
				currentCharacter = GameInformation.characters [GameInformation.IndexOfCharacter (hexCoords)];
				pathStarted = true;
				HandleInput ();
			} else { pathStarted = false; }
		}
	}

	public void SelectColor (int index) {
		activeColor = colors[index];
	}
}