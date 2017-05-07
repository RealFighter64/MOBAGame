using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	public int range;
	public HexCoordinates position;

	public CharacterMovement charMovement;
	public CharacterAnimation charAnimation;

	// Use this for initialization
	void Start ()
	{
		charMovement = gameObject.AddComponent<CharacterMovement> ();
		charAnimation = gameObject.AddComponent<CharacterAnimation> ();
		position = new HexCoordinates (0, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		charAnimation.Moving = charMovement.Moving;
	}
}

