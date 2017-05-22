using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	public int range;
	[SerializeField]
	public AttackingRange attackingRange;
	public HexCoordinates position;
	public float startingHealth;
	public float damage;
	public bool team1;
	public HexCoordinates startingPosition;
	public bool attacked;
	public bool moved;
	public bool sleeping;

	//[HideInInspector]
	public float health;

	public CharacterMovement charMovement;
	public CharacterAnimation charAnimation;

	private Renderer characterRenderer;
	private ParticleSystem particles;

	private float startOfDeathAnimation;

	// Use this for initialization
	void Start ()
	{
		charMovement = gameObject.AddComponent<CharacterMovement> ();
		charAnimation = gameObject.AddComponent<CharacterAnimation> ();
		characterRenderer = GetComponentInChildren<Renderer> ();
		Debug.LogWarning(GetComponentInChildren<ParticleSystem>());
		particles = GetComponentInChildren<ParticleSystem> ();
		position = new HexCoordinates (0, 0);
		health = startingHealth;
		startOfDeathAnimation = 0;
		position = startingPosition;
		charMovement.InitPosition (position);
		if (team1) {
			characterRenderer.material.color = new Color(1F, 0.5F, 0.5F);
		} else {
			characterRenderer.material.color = new Color(0.5F, 0.5F, 1F);
		}
		attacked = false;
		sleeping = true;
		moved = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		charAnimation.Moving = charMovement.Moving;

		if (sleeping) {
			particles.gameObject.SetActive (true);
		} else {
			particles.gameObject.SetActive (false);
		}

		if (health <= 0)
			Die ();
	}

	void Attack(int neighbour, int distance)
	{
		Debug.Log (position.CellNeighbours);
	}

	public void TakeDamage (float damage)
	{
		health -= damage;
		charAnimation.Impact = true;
	}

	void Die ()
	{
		charAnimation.Dead = true;
		if (startOfDeathAnimation == 0) {
			startOfDeathAnimation = Time.time;
		} else {
			if (Time.time - startOfDeathAnimation >= 2.5) {
				GameInformation.characters.Remove (this);
				GameObject.Destroy (gameObject);
			}
		}
	}
}

