using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnButton : MonoBehaviour
{
	public void SpawnKnight() {
		int manaCost = GameResources.knightCharacter.GetComponent<Character> ().manaCost;
		//if(manaCost <= GameInformation.currentMana){
			//Character initialCharacter = Instantiate (GameResources.knightCharacter).GetComponent<Character>();
			//initialCharacter.name = Time.time.ToString();
			//GameInformation.SpawnCharacter (initialCharacter);
			//GameInformation.currentMana -= manaCost;
		if(GameInformation.SoldierOrMana = true){
			Character initialCharacter = Instantiate (GameResources.knightCharacter).GetComponent<Character>();
			initialCharacter.name = Time.time.ToString();
			GameInformation.SpawnCharacter (initialCharacter);
			GameInformation.SoldierOrMana = false;
		}
	}
}

	public void SpawnWolf() {
		int manaCost = GameResources.wolfCharacter.GetComponent<Character>().manaCost;
		if(manaCost <= GameInformation.currentMana){
			Character initialCharacter = Instantiate (GameResources.wolfCharacter).GetComponent<Character>();
			initialCharacter.name = Time.time.ToString();
			GameInformation.SpawnCharacter (initialCharacter);
			GameInformation.currentMana -= manaCost;

		}
	}

	public void ManaButton(){
		if (GameInformation.SoldierOrMana = true){
			GameInformation.maximumMana++;
			GameInformation.SoldierOrMana = false;
		}
	}
}

