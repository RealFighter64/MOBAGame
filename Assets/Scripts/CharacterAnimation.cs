using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour
{

	bool moving;
	public bool Moving { set { moving = value; } }

	bool dead;
	public bool Dead { set { dead = value; } }

	Animator animator;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		animator.SetBool ("Moving", moving);
		animator.SetBool ("Dead", dead);
	}
}

