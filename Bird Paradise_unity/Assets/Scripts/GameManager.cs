using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public GameObject letterObject;
	GetInputFromUser input;
	DisplayLetters letters;

	void Awake()
	{
		input = GetComponent<GetInputFromUser> ();
		letters = letterObject.GetComponent<DisplayLetters> ();

		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		NewRound();
	}

	void OnApplicationQuit()
	{

	}

	public void LoadLevel(string levelToLoad)
	{
		StartCoroutine(SwitchScene("MainGame"));
	}

	public IEnumerator SwitchScene(string scene)
	{
		AsyncOperation async = Application.LoadLevelAsync(scene);
		yield return async;
	}

	void NewRound()
	{
		char[] p1Sequence = new char[1];
		char[] p2Sequence = new char[1];
		SequenceGenerator.NewRound(ref p1Sequence, ref p2Sequence);

		input.RecieveArrays (p1Sequence, p2Sequence);
		letters.findLetterImage(p1Sequence, p2Sequence);
		string p1Test = "";
		string p2Test = "";

		for(int i = 0; i < p1Sequence.Length; i += 1)
		{
			p1Test = p1Test + p1Sequence[i].ToString()+", ";
			p2Test = p2Test + p2Sequence[i].ToString()+", ";
		}
		Debug.Log(p1Test);
		Debug.Log(p2Test);
	}
}