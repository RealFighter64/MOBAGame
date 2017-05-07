using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public CharacterPath pathForMovement;
	public List<HexCoordinates> listOfCoords;

	Character character;

	bool moving;
	public bool Moving { get { return moving; } }
	int currentIndex;

	// Use this for initialization
	void Start () {
		currentIndex = 0;
		this.character = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
		pathForMovement = GameInformation.currentPath;
		if (moving == true && pathForMovement.ValidPath ()) {
			transform.position = Vector3.MoveTowards (transform.position, pathForMovement.hexCoords [currentIndex].CentreToWorldPosition (), 0.1F);
			transform.LookAt (pathForMovement.hexCoords [currentIndex].CentreToWorldPosition ());
			if (transform.position == pathForMovement.hexCoords [currentIndex].CentreToWorldPosition()) {
				character.position = pathForMovement.hexCoords [currentIndex];
				currentIndex++;
			}
		}

		if (currentIndex >= pathForMovement.hexCoords.Length) {
			moving = false;
			currentIndex = 0;
			GameInformation.currentPath = new CharacterPath();
		}
	}


	public void StartMoving() {
		if (pathForMovement.character != null) {
			if (pathForMovement.character.gameObject == this.gameObject) {
				if (pathForMovement.hexCoords.Length > 1 && pathForMovement.ValidPath ()) {
					moving = true;
					Debug.Log ("moving");
				} else {
					GameInformation.currentPath = new CharacterPath ();
				}
			} else {
				Debug.Log ("nawt moving");
			}
		}
	}
}
