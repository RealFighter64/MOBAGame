using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class AttackButton : MonoBehaviour
{
	HexMapEditor mapEditor;
	Text buttonText;
	Character currentCharacter;

	void Start ()
	{
		mapEditor = GameInformation.currentHexGrid.GetComponentInChildren<HexMapEditor> ();
		buttonText = GetComponentInChildren<Text> ();
	}

	public void Attack ()
	{
		if (GameInformation.attackMode) {
			GameInformation.ResetAttackingPath ();
			buttonText.text = "Attack";
		} else {
			try {
				currentCharacter = GameInformation.currentlySelectedCharacter;
				if(currentCharacter.team1 == GameInformation.player1Turn) {
					List<HexCoordinates> tempCoords = new List<HexCoordinates>();
					foreach (HexCoordinates neighbour in currentCharacter.position.CellNeighbours) {
						if(GameInformation.IndexOfCharacter(neighbour) != -1) {
							tempCoords.Add(neighbour);
						}
					}
					if(tempCoords.Count != 0) {
						CharacterPath attackingPath = new CharacterPath (tempCoords.ToArray(), currentCharacter);
						GameInformation.currentAttackPath = attackingPath;
						buttonText.text = "Cancel";
						GameInformation.attackMode = true;
					}
				}
			} catch (Exception e) {
				GameInformation.attackMode = false;
				buttonText.text = "Attack";
			}
		}
	}
}

