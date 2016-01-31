using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {

	Animator anim; 

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

//	public void AnimatorStateUpdateP1(int state)
//	{
//		anim.SetInteger ("p1AnimatorState", state);
//	}

	public void wrongInput(int player)
	{
		// player 1
		if (player == 0) {
			anim.SetInteger ("p1AnimatorState", 1);
		}

		// player 2
		if (player == 1) {
			anim.SetInteger ("p2AnimatorState", 1);
		}
	}

	public void rightInput(int player)
	{
		// player 1
		if (player == 0) {
			anim.SetInteger ("p1AnimatorState", 2);
		}

		// player 2
		if (player == 1) {
			anim.SetInteger ("p2AnimatorState", 2);
		}
	}

	public void sequenceEnd()
	{
		// random int for each player
		// it decides player shimmys in or out
		// player 1
		anim.SetInteger ("p1AnimatorState", (Random.Range(0,2)+2));
		

		// player 2
		anim.SetInteger ("p2AnimatorState", (Random.Range(0,2)+2));
		
	}

//	public void AnimatorStateUpdateP2(int state)
//	{
//		anim.SetInteger ("p2AnimatorState", state);
//	}
}
