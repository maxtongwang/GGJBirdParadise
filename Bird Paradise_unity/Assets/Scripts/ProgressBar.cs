using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	// initiate progress bar
	public Scrollbar progressBar1;
	public Scrollbar progressBar2;

	public float progress1 = .0f;
	public float progress2 = .0f;

	void Start()
	{
		progressBar1.size = .0f;
		progressBar2.size = .0f;
	}

	// call this function every time a button press happens
	void makingProgressP1(float score)
	{
		progress1 += score / 40f;
	}

	void makingProgressP2(float score)
	{
		progress2 += score / 40f;
	}

	// call this function at the end of a sequence
	void timeBonus(bool p1bonus, bool p2bonus)
	{
		if (p1bonus) {
			progress1 *= 1.5f / 40f;
		}

		if (p2bonus) {
			progress2 *= 1.5f / 40f;
		}
	}
}
