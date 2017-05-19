
using UnityEngine;
using UnityEditor;

[System.Serializable]
public struct AttackingRange
{
	public int rangeMin;
	public int rangeMax;

	public AttackingRange (int rangeMin, int rangeMax)
	{
		this.rangeMin = rangeMin;
		this.rangeMax = rangeMax;
	}
}

