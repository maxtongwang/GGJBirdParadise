using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	// initiate progress bar
	public Scrollbar progressBar1;
	public Scrollbar progressBar2;

	public float progress1;
	public float progress2;

	void Start()
	{
		progressBar1.size = .0f;
		progressBar2.size = .0f;
	}

	// call this function every time a button press happens
	public void makingProgressP1(float score)
	{
		progress1 += score;
		progressBar1.size = progress1 / 40;
	}

	public void makingProgressP2(float score)
	{
		progress2 += score;
		progressBar2.size = progress2 / 40;
	}

	// call this function at the end of a sequence
	public void timeBonus(bool p1bonus, bool p2bonus)
	{
		if (p1bonus) {
			progress1 *= 1.5f;
			progressBar1.size = progress1 / 40;
		}

		if (p2bonus) {
			progress2 *= 1.5f;
			progressBar2.size = progress2 / 40;
		}
	}
}
