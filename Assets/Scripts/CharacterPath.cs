using System;

public class CharacterPath : Path
{
	Character character;

	public CharacterPath (HexCoordinates[] hexCoords) : base(hexCoords)
	{
		character = GameInformation.currentCharacter;
	}

	public CharacterPath() : base()
	{
		character = GameInformation.currentCharacter;
	}

	public bool ValidPath() {
		if (hexCoords.Length <= character.range) {
			return true;
		} else {
			return false;
		}
	}
}

