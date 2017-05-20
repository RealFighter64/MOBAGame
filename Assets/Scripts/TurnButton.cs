using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurnButton : MonoBehaviour {

	public void EndTurn() {
		GameInformation.PlayerTurn();
	}

}

