using UnityEngine;
using System.Collections;

public class SequenceGenerator : MonoBehaviour
{
	private static char[][] p1Keys = new char[][] {	new char[] {'Q','A','Z'},
													new char[] {'W','S','X'},
													new char[] {'E','D','C'},
													new char[] {'R','F','V'}};
	
	private static char[][] p2Keys = new char[][] { new char[] {'O','L','P'},
													new char[] {'I','K','M'},
													new char[] {'U','J','N'},
													new char[] {'Y','H','B'}};
	
	public static void NewRound(ref char[] p1Letters, ref char[] p2Letters)
	{
		int difficulty = 0;
		//difficulty = ChooseDificulty();

		int length = (difficulty / 3) + 3;
		p1Letters = new char[length];
		p2Letters = new char[length];

		int[][] sequence = new int[][] {new int[] {1, 1, 1, 1, 1, 1},
										new int[] {0, 1, 2, 0, 1, 2}};
		//sequence = GenerateTheSequence(length, difficulty);

		p1Letters = InterpretSequence(sequence, 0, length, true);
		p2Letters = InterpretSequence(sequence, length, length, false);
	}

	static int ChooseDificulty()
	{
		int difficulty = 0;

		return difficulty;
	}

	static int[][] GenerateTheSequence(int length, int difficulty)
	{
		int[][] sequence = new int[2][];

		switch(difficulty % 3)
		{
		case 0:
			break;
		case 1:
			break;
		case 2:
			break;
		}

		return sequence;
	}

	static int[] WildAndRandom(int length, int size)
	{
		int[] sequence = new int[length];

		for(int i = 0; i < length; i += 1)
		{	sequence[i] = Random.Range(0, size-1);	}

		return sequence;
	}

	static char[] InterpretSequence(int[][] sequence, int start, int length, bool p1)
	{
		char[] letterSequence = new char[length];

		for(int i = start; i < start + length; i += 1)
		{
			if (p1)
			{	letterSequence[i] = p1Keys[sequence[1][i]][sequence[0][i]];	}
			else
			{	letterSequence[i-start] = p2Keys[sequence[1][i]][sequence[0][i]];	}
		}

		return letterSequence;
	}
}
