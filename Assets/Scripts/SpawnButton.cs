using UnityEngine;
using System.Collections;

public class SpawnButton : MonoBehaviour
{
	public void SpawnKnight() {
		Character initialCharacter = Instantiate (GameResources.knightCharacter).GetComponent<Character>();
		initialCharacter.startingPosition = new HexCoordinates (0, 0);
		initialCharacter.name = Time.time.ToString();
		GameInformation.SpawnCharacter (initialCharacter);
	}
}

