using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedGlow : MonoBehaviour {

	LineRenderer[] lineRenderers;

	// Use this for initialization
	public void Init (HexCoordinates coords) {
		lineRenderers = new LineRenderer[6];
		for (int i = 0; i < 6; i++) {
			GameObject tempObject = new GameObject ("Glow " + 1);
			tempObject.transform.parent = transform;
			lineRenderers [i] = tempObject.AddComponent<LineRenderer> ();
			lineRenderers [i].numPositions = 2;
			lineRenderers [i].widthMultiplier = 0.1F;
			lineRenderers [i].numCapVertices = 5;
			Vector3[] vertices = new Vector3[2];
			vertices [0] = coords.GetWorldVertices [i];
			vertices [1] = coords.GetWorldVertices [i + 1];
			lineRenderers[i].SetPositions(vertices);
		}
	}
}
