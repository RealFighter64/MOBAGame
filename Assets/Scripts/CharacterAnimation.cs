using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour
{

	bool moving;
	public bool Moving { set { moving = value; } }

	bool dead;
	public bool Dead { set { dead = value; } }

	bool attacking;
	public bool Attacking { set { attacking = value; } }

	bool impact;
	public bool Impact { set { impact = value; } }

	Animator animator;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		animator.SetBool ("Moving", moving);
		animator.SetBool ("Dead", dead);
		if (attacking) {
			animator.SetTrigger ("Attacking");
			attacking = false;
		}
		if (impact) {
			animator.SetTrigger ("Impact");
			impact = false;
		}
	}
}

