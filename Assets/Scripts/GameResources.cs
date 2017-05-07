using UnityEngine;
using System.Collections;

/// <summary>
/// 	A container for all of the resources to be loaded in game.
/// </summary>
public static class GameResources
{
	public static Material glowMaterial = Resources.Load("Materials/glowMaterial") as Material;

	public static GameObject hexGrid = Resources.Load("Hex Grid") as GameObject;
}

