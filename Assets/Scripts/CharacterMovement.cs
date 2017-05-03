using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public CharacterPath pathForMovement;
	public List<HexCoordinates> listOfCoords;

	bool moving;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pathForMovement = GameInformation.currentPath;
		if (moving == true && pathForMovement.ValidPath ()) {

		}
	}

	public void StartMoving() {
		moving = true;

	}
}
