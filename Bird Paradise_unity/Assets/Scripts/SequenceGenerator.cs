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

	private static int round = 0;
	
	public static void NewRound(ref char[] p1Letters, ref char[] p2Letters)
	{
		int difficulty = 0;
		//difficulty = ChooseDificulty();

		int length = (difficulty / 3) + 3;
		p1Letters = new char[length];
		p2Letters = new char[length];

		int[][] sequence = new int[][] {new int[] {0, 1, 2, 0, 1, 2},
										new int[] {1, 1, 1, 1, 1, 1}};
		//sequence = GenerateTheSequence(length, difficulty);

		p1Letters = InterpretSequence(sequence, 0, length, true);
		p2Letters = InterpretSequence(sequence, length, length, false);

		round += 1;
	}

	static int ChooseDificulty()
	{
		int difficulty = 0;



		return difficulty;
	}

	static int[][] GenerateTheSequence(int length, int difficulty)
	{
		int[][] sequence;

		switch(difficulty % 3)
		{
		case 0:
			sequence = TotalControl (length);
			break;
		case 1:
			sequence = TotalControl (length);
			break;
		case 2:
			sequence = TotalControl (length);
			break;
		}

		return sequence;
	}

	static int[][] TotalControl(int length)
	{
		int[][] sequence = new int[][] {new int[length*2],
										new int[length*2]};
		int current = 0;
		int possible = 2;
		int same = 0;

		for (int i = 0; i < length; i += 1)
		{
			int sum = possible * (1 + possible) / 2;

			int r = Random.Range (0, possible - 1);
		}


		return sequence;
	}

	static int[][] StructuredRandom(int length)
	{
		int[][] sequence = new int[][] {new int[length*2],
										new int[length*2]};
		bool cleared;



		return sequence;
	}

	static int[][] WildAndRandom(int length)
	{
		int[][] sequence = new int[][] {new int[length*2],
										new int[length*2]};
		bool cleared;

		for(int i = 0; i < length; i += 1)
		{
			cleared = true;

			do
			{
				sequence[0][i] = Random.Range(0,length-1);
				sequence[1][i] = Random.Range(0,2);

				for(int j = 0; j < i; i += 1)
				{
					if(sequence[0][i] == sequence[0][j] && sequence[0][i] == sequence[0][j])
					{	cleared = false;	}
				}
			}
			while(cleared);
		}
			
		return sequence;
	}

	static char[] InterpretSequence(int[][] sequence, int start, int length, bool p1)
	{
		char[] letterSequence = new char[length];

		for(int i = start; i < start + length; i += 1)
		{
			if (p1)
			{	letterSequence[i] = p1Keys[sequence[0][i]][sequence[1][i]];	}
			else
			{	letterSequence[i-start] = p2Keys[sequence[0][i]][sequence[1][i]];	}
		}

		return letterSequence;
	}
}
