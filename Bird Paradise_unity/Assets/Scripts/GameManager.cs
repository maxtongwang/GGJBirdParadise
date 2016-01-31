using UnityEngine;
using System.Collections;
using System.Collections.Generic;

enum GameState {Menu, Start, Running, Finished, End};

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public GameObject letterObject;

	GameState currState;
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

		currState = GameState.Menu;
	}

	void Update()
	{
		switch(currState)
		{
		case GameState.Menu:
			break;
		case GameState.Start:
			NewRound ();
			currState = GameState.Running;
			break;
		case GameState.Running:
			break;
		case GameState.Finished:
			break;
		case GameState.End:
			break;
		}
	}

	void OnApplicationQuit()
	{

	}

	public void LoadLevel(string levelToLoad)
	{	StartCoroutine(SwitchScene("MainGame"));	}

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

	public void RoundFinished()
	{
		currState = GameState.Finished;
		StartCoroutine (WaitForAnimation ());
	}

	public void Winner(bool player)
	{
		currState = GameState.End;

		if(player)
		{	StartCoroutine(SwitchScene("P1Win"));	}
		else
		{	StartCoroutine(SwitchScene("P2Win"));	}
	}

	public void GoToMenu()
	{
		currState = GameState.Menu;

		StartCoroutine(SwitchScene("TitleScreen"));
	}

	IEnumerator WaitForAnimation()
	{
		yield return new WaitForSeconds(1);
		currState = GameState.Start;
	}
}