using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour {

	public Button button;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
		button.onClick.AddListener (OnPointerClick);
	}

	void OnPointerClick() {
		foreach (Character character in GameInformation.characters) {
			if(!character.sleeping && !character.moved)
				character.charMovement.StartMoving ();
		}
		Debug.Log ("click");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
