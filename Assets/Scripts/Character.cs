using UnityEngine;
using UnityEditor;
using System.Collections;

public class Character : MonoBehaviour
{
	public int range;
	public HexCoordinates position;
	public float startingHealth;

	//[HideInInspector]
	public float health;

	public CharacterMovement charMovement;
	public CharacterAnimation charAnimation;

	private Renderer renderer;

	private float startOfDeathAnimation;

	// Use this for initialization
	void Start ()
	{
		charMovement = gameObject.AddComponent<CharacterMovement> ();
		charAnimation = gameObject.AddComponent<CharacterAnimation> ();
		renderer = GetComponentInChildren<Renderer> ();
		position = new HexCoordinates (0, 0);
		health = startingHealth;
		startOfDeathAnimation = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		charAnimation.Moving = charMovement.Moving;

		if (health <= 0)
			Die ();
	}

	void TakeDamage (float damage)
	{
		health -= damage;
	}

	void Die ()
	{
		charAnimation.Dead = true;
		if (startOfDeathAnimation == 0) {
			startOfDeathAnimation = Time.time;
		} else {
			if (Time.time - startOfDeathAnimation >= 2.5) {
				GameObject.Destroy (gameObject);
			}
		}
	}
}

