using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {

	Animator anim; 

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	public void wrongInput(int player)
	{
		// player 1
		if (player == 0) {
			anim.SetTrigger("p1WrongTrigger");
		}

		// player 2
		if (player == 1) {
			anim.SetTrigger("p2WrongTrigger");
		}
	}

	public void rightInput(int player)
	{
		// player 1
		if (player == 0) {
			anim.SetTrigger("p1RightTrigger");
		}

		// player 2
		if (player == 1) {
			anim.SetTrigger("p2RightTrigger");
		}
	}

	public void sequenceEnd(int player)
	{
		// random int for each player
		// it decides player shimmys in or out

		// player 1
		if (player == 0) {
			
			if ((Random.Range (0, 2) == 0)) {
				anim.SetTrigger ("p1ShimmyOutTrigger");
			}

			if ((Random.Range (0, 2) == 1)) {
				anim.SetTrigger ("p1ShimmyInTrigger");
			}
		}

		// player 2
		if (player == 1) {

			if ((Random.Range (0, 2) == 0)) {
				anim.SetTrigger ("p2ShimmyOutTrigger");
			}

			if ((Random.Range (0, 2) == 1)) {
				anim.SetTrigger ("p2ShimmyInTrigger");
			}
		}
		
	}
}
