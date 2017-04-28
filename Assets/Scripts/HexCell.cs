using UnityEngine;
using System.Collections;

public class HexCell : MonoBehaviour
{
	public HexCoordinates coordinates;
	public Color color;

	void Start () {
		if (GameInformation.currentPath.InPath (coordinates)) {
			GetComponentInChildren<SelectedGlow> ().Init (this.coordinates);
		}
	}
}

