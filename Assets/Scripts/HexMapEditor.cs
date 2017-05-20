using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class HexMapEditor : MonoBehaviour
{

	public Color[] colors;

	public HexGrid hexGrid;

	private Color activeColor;

	private Character currentCharacter;

	bool prevClick;

	bool pathStarted;

	void Awake ()
	{
		SelectColor (0);
		pathStarted = false;
	}

	void Update ()
	{
		
		if (Input.GetMouseButton (0) && !EventSystem.current.IsPointerOverGameObject ()) {
			if (prevClick == true) {
				if (!GameInformation.attackMode) {
					HandleInput ();
				}
			} else {
				if (!GameInformation.attackMode) {
					ResetPath ();
					HandleFirstInput ();
				} else {
					HandleAttackInput ();
				}
			}
			prevClick = true;
		} else {
			prevClick = false;
		}
	}

	void ResetPath ()
	{
		GameInformation.currentPath = new CharacterPath ();
	}

	HexCoordinates GetInput ()
	{
		Ray inputRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (inputRay, out hit)) {
			if (hit.collider.name == "HexMesh") {
				HexCoordinates hexCoords = HexCoordinates.FromPosition (hit.point);
				return hexCoords;
			} else {
				return new HexCoordinates (1000, 1000);
			}
		} else {
			return new HexCoordinates (1000, 1000);
		}
	}

	void HandleInput ()
	{
		HexCoordinates hexCoords = GetInput ();
		if (hexCoords != new HexCoordinates (1000, 1000)) {
			if (GameInformation.IndexOfCharacter (hexCoords) == -1) {
				if (pathStarted) {
					if (currentCharacter.team1 == GameInformation.player1Turn) {
						if (!GameInformation.currentPath.InPath (hexCoords)) {
							List<HexCoordinates> coordList = new List<HexCoordinates> ();
							coordList.AddRange (GameInformation.currentPath.hexCoords);
							coordList.Add (hexCoords);
							GameInformation.currentPath = new CharacterPath (coordList.ToArray (), currentCharacter);
						}
					}
				}
			}
		}
	}

	void HandleFirstInput ()
	{
		HexCoordinates hexCoords = GetInput ();
		if (hexCoords != new HexCoordinates (1000, 1000)) {
			if (GameInformation.IndexOfCharacter (hexCoords) != -1) {
				currentCharacter = GameInformation.characters [GameInformation.IndexOfCharacter (hexCoords)];
				if (currentCharacter.team1 == GameInformation.player1Turn) {
					pathStarted = true;
					if (!GameInformation.currentPath.InPath (hexCoords)) {
						List<HexCoordinates> coordList = new List<HexCoordinates> ();
						coordList.AddRange (GameInformation.currentPath.hexCoords);
						coordList.Add (hexCoords);
						GameInformation.currentPath = new CharacterPath (coordList.ToArray (), currentCharacter);
					}
				}
			} else {
				pathStarted = false;
			}
		}
	}

	void HandleAttackInput() {
		HexCoordinates hexCoords = GetInput ();
		if (hexCoords != new HexCoordinates (1000, 1000)) {
			if (GameInformation.IndexOfCharacter (hexCoords) != -1) {
				currentCharacter = GameInformation.characters [GameInformation.IndexOfCharacter (hexCoords)];
				if (GameInformation.currentAttackPath.InPath (hexCoords)) {
					Character tempCharacter = GameInformation.currentlySelectedCharacter;
					if (tempCharacter.team1 != currentCharacter.team1) {
						tempCharacter.charMovement.LookAt (currentCharacter.position);
						tempCharacter.charAnimation.Attacking = true;
						currentCharacter.TakeDamage (tempCharacter.damage);
						GameInformation.attackButton.Attack ();
					}
				}
			}
		}
	}

	public void SelectColor (int index)
	{
		activeColor = colors [index];
	}
}