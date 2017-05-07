using System;

public class CharacterPath : Path
{
	public Character character;

	public CharacterPath (HexCoordinates[] hexCoords, Character character) : base(hexCoords)
	{
		this.character = character;
	}

	public CharacterPath(Character character) : base()
	{
		this.character = character;
	}

	public CharacterPath() : base()
	{ }

	public bool ValidPath() {
		if (hexCoords.Length <= character.range) {
			for (int i = 0; i < hexCoords.Length-1; i++) {
				bool validCoord = false;
				foreach (HexCoordinates neighbour in HexCoordinates.neighbours) {
					if(hexCoords[i]+neighbour == hexCoords[i+1]){
						validCoord = true;
					}
				}
				if (!validCoord) {
					return false;
				}
			}
			return true;
		} else {
			return false;
		}
	}
}

