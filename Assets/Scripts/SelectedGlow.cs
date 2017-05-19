using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedGlow : MonoBehaviour {
	LineRenderer[] lineRenderers;

	// Use this for initialization
	public void Init (HexCoordinates coords, bool valid) {
		lineRenderers = new LineRenderer[6];
		for (int i = 0; i < 6; i++) {
			if (!GameInformation.currentPath.InPath (coords + HexCoordinates.neighbours [i])) {
				GameObject tempObject = new GameObject ("Glow " + 1);
				tempObject.transform.parent = transform;
				lineRenderers [i] = tempObject.AddComponent<LineRenderer> ();
				lineRenderers [i].material = GameResources.glowMaterial;
				lineRenderers [i].useWorldSpace = false;
				lineRenderers [i].positionCount = 2;
				lineRenderers [i].widthMultiplier = 0.1F;
				lineRenderers [i].numCapVertices = 5;
				Vector3[] vertices = new Vector3[2];
				vertices [0] = coords.GetWorldVertices () [i];
				vertices [1] = coords.GetWorldVertices () [i + 1];
				lineRenderers [i].SetPositions (vertices);

				if (valid) {
					lineRenderers [i].startColor = Color.yellow;
					lineRenderers [i].endColor = Color.yellow;
				} else {
					lineRenderers [i].startColor = Color.red;
					lineRenderers [i].endColor = Color.red;
				}
			}
		}
	}

	public void InitAttack(HexCoordinates coords) {
		lineRenderers = new LineRenderer[6];
		for (int i = 0; i < 6; i++) {
			if (!GameInformation.currentAttackPath.InPath (coords + HexCoordinates.neighbours [i])) {
				GameObject tempObject = new GameObject ("Glow " + 1);
				tempObject.transform.parent = transform;
				lineRenderers [i] = tempObject.AddComponent<LineRenderer> ();
				lineRenderers [i].material = GameResources.glowMaterial;
				lineRenderers [i].useWorldSpace = false;
				lineRenderers [i].positionCount = 2;
				lineRenderers [i].widthMultiplier = 0.1F;
				lineRenderers [i].numCapVertices = 5;
				Vector3[] vertices = new Vector3[2];
				vertices [0] = coords.GetWorldVertices () [i];
				vertices [1] = coords.GetWorldVertices () [i + 1];
				lineRenderers [i].SetPositions (vertices);
				lineRenderers [i].startColor = Color.red;
				lineRenderers [i].endColor = Color.red;
			}
		}
	}

	public void InitFocus(HexCoordinates coords) {
		lineRenderers = new LineRenderer[6];
		for (int i = 0; i < 6; i++) {
			GameObject tempObject = new GameObject ("Glow " + 1);
			tempObject.transform.parent = transform;
			lineRenderers [i] = tempObject.AddComponent<LineRenderer> ();
			lineRenderers [i].material = GameResources.glowMaterial;
			lineRenderers [i].useWorldSpace = false;
			lineRenderers [i].positionCount = 2;
			lineRenderers [i].widthMultiplier = 0.1F;
			lineRenderers [i].numCapVertices = 5;
			Vector3[] vertices = new Vector3[2];
			vertices [0] = coords.GetWorldVertices () [i];
			vertices [1] = coords.GetWorldVertices () [i + 1];
			lineRenderers [i].SetPositions (vertices);
			lineRenderers [i].startColor = Color.blue;
			lineRenderers [i].endColor = Color.blue;
		}
	}
	
	public void Reset(HexCoordinates coords) {
		foreach (LineRenderer o in GetComponentsInChildren<LineRenderer>()) {
			Destroy (o.gameObject);
		}
	}

	public void UpdateCell(HexCoordinates coords, bool valid, bool attacking) {
		Reset (coords);
		if (!attacking) {
			Init (coords, valid);
		} else {
			InitAttack (coords);
		}
	}
}
