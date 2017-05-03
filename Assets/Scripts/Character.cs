using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	public int range;

	CharacterMovement charMovement;

	// Use this for initialization
	void Start ()
	{
		charMovement = gameObject.AddComponent<CharacterMovement> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

