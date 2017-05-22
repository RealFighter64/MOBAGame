using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public CharacterPath pathForMovement;
	public List<HexCoordinates> listOfCoords;

	Character character;
	HexMapEditor editor;

	bool moving;
	public bool Moving { get { return moving; } }
	int currentIndex;

	// Use this for initialization
	void Start () {
		currentIndex = 0;
		this.character = GetComponent<Character> ();
		editor = GameInformation.currentHexGrid.GetComponentInChildren<HexMapEditor> ();
	}
	
	// Update is called once per frame
	void Update () {
		pathForMovement = GameInformation.currentPath;
		if (moving == true && pathForMovement.ValidPath ()) {
			editor.pathAvailable = false;
			transform.position = Vector3.MoveTowards (transform.position, pathForMovement.hexCoords [currentIndex].CentreToWorldPosition (), 0.5F);
			LookAt (pathForMovement.hexCoords [currentIndex]);
			if (transform.position == pathForMovement.hexCoords [currentIndex].CentreToWorldPosition()) {
				character.position = pathForMovement.hexCoords [currentIndex];
				currentIndex++;
			}
		}

		if (currentIndex >= pathForMovement.hexCoords.Length) {
			if(moving == true)
				character.moved = true;
			moving = false;
			currentIndex = 0;
			GameInformation.currentPath = new CharacterPath();
			editor.pathAvailable = true;
		}
	}


	public void StartMoving() {
		if (pathForMovement.character != null) {
			if (pathForMovement.character.gameObject == this.gameObject) {
				if (pathForMovement.hexCoords.Length > 1 && pathForMovement.ValidPath ()) {
					moving = true;
				} else {
					GameInformation.currentPath = new CharacterPath ();
				}
			}
		}
	}

	public void LookAt(HexCoordinates coords) {
		transform.LookAt (coords.CentreToWorldPosition ());
	}

	public void InitPosition (HexCoordinates position) {
		transform.position = position.CentreToWorldPosition();
	}
}
