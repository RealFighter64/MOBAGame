using UnityEngine;
using System.Collections;

/// <summary>
/// 	A container for all of the resources to be loaded in game.
/// </summary>
public static class GameResources
{
	// Materials
	public static Material glowMaterial = Resources.Load("Materials/glowMaterial") as Material;

	// Prefabs
	public static GameObject hexGrid = Resources.Load("Prefabs/Hex Grid") as GameObject;
	public static GameObject knightCharacter = Resources.Load("Prefabs/KnightCharacter") as GameObject;
	public static GameObject rtsCamera = Resources.Load("Prefabs/RTS_Camera") as GameObject;
}

