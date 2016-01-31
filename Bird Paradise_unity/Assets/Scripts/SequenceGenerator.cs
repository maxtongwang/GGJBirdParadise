using UnityEngine;
using System.Collections;

public class SequenceGenerator : MonoBehaviour
{
	private static char[][] p1Keys = new char[][] {	new char[] {'Q','A','Z'},
													new char[] {'W','S','X'},
													new char[] {'E','D','C'},
													new char[] {'R','F','V'}};
	
	private static char[][] p2Keys = new char[][] { new char[] {'P','O','L'},
													new char[] {'I','K','M'},
													new char[] {'U','J','N'},
													new char[] {'Y','H','B'}};

	private static int round = 0;
	
	public static void NewRound(ref char[] p1Letters, ref char[] p2Letters)
	{
		int difficulty = 7;
		//difficulty = ChooseDificulty();

		int length = (difficulty / 3) + 3;
		p1Letters = new char[length];
		p2Letters = new char[length];

		int[][] sequence = new int[][] {new int[] {0, 1, 2, 0, 1, 2},
										new int[] {1, 1, 1, 1, 1, 1}};
		sequence = GenerateTheSequence(length, difficulty);

		Debug.Log(length + " " + difficulty);

		string check1 = "";
		string check2 = "";
		for(int i = 0; i < sequence[0].Length; i += 1)
		{
			check1 = check1 + sequence[0][i] + ", ";
			check2 = check2 + sequence [1] [i] + ", ";
		}
		Debug.Log(check1);
		Debug.Log (check2);

		p1Letters = InterpretSequence(sequence, 0, length, true);
		p2Letters = InterpretSequence(sequence, length, length, false);

		round += 1;
	}

	static int ChooseDificulty()
	{
		int difficulty = Random.Range(0,4) * 3 + 2;

		return difficulty;
	}

	static int[][] GenerateTheSequence(int length, int difficulty)
	{
		int[][] sequence = new int[1][];

		switch(difficulty % 3)
		{
		case 0:
			sequence = TotalControl (length);
			break;
		case 1:
			sequence = StructuredRandom (length);
			break;
		case 2:
			sequence = WildAndRandom (length);
			break;
		}

		return sequence;
	}

	static int[][] TotalControl(int length)
	{
		int[][] sequence = new int[][] {new int[length*2],
										new int[length*2]};
		int current, max, possible, same;
		bool clear;

		do
		{
			current = 0;
			max = (int)Mathf.Min(3, length-1);
			possible = 2;
			same = 0;
			clear = true;

			for (int i = 0; i < length; i += 1)
			{
				int sum = possible * (1 + possible) / 2;
				int r = Random.Range (0, sum);

//				Debug.Log (r);

				for (int j = possible; j >= 0; j -= 1)
				{
					r -= j;
					if (r < 0 || possible == 0)
					{
						int check = possible - j;

						if(i >= max)
						{
							sequence[0][i] = current + check;
							sequence[0][i+length] = current + check;

							if(sequence[0][i] == sequence[0][i-1])
							{	same += 1;	}
						}
						else if(possible == 2)
						{
							if(check == 0)
							{
								sequence[0][i] = i;
								sequence[0][i+length] = i;
							}
							else if(check == 1)
							{
								sequence[0][i] = i + 1;
								sequence[0][i+length] = i + 1;
							}
							if(i > 0)
							{
								if(sequence[0][i] == sequence[0][i-1])
								{	same += 1;	}
							}
						}
						else if(i > 0)
						{
							if(check == 0)
							{
								sequence[0][i] = i;
								sequence[0][i+length] = i;
							}
							else if(check == 1)
							{
								sequence[0][i] = i - 1;
								sequence[0][i+length] = i - 1;
							}
							else if(check == 2)
							{
								sequence[0][i] = i + 1;
								sequence[0][i+length] = i + 1;
							}
							else
							{
								sequence[0][i] = i - (check - 1);
								sequence[0][i+length] = i - (check - 1);
							}
								
							if(sequence[0][i] == sequence[0][i-1])
							{	same += 1;	}
						}

						if(same >= 3)
						{
							if(sequence[0][i] == max)
							{	clear = false;	}
							else if(sequence[0][i] == sequence[0][i-1])
							{
								sequence[0][i] += 1;
								sequence[0][i + length] += 1;
								same -= 1;
							}
						}

//						Debug.Log(i + " " + j + " " + current + " " + sequence[0][i] + " " + max + " " + possible + " " + sum + " " + r + " " + check);

						possible = (int)Mathf.Min(max, i + 2) - sequence[0][i] + 1;
						current = sequence[0][i];
						break;
					}
				}
			}
		}
		while(!clear);

		current = 0;
		max = 2;

		for(int i = 0; i < length; i += 1)
		{
			if(i == 0)
			{
				//skip
			}
			else if(sequence[0][i] == sequence[0][i-1])
			{
				current += 1;
				same -= 1;
				max -= 1;
			}
			else if(same != max)
			{
				if(Random.Range(0, max-same+1) == 0)
				{
					current += 1;
					max -= 1;
				}
			}

			sequence[1][i] = current;
			sequence[1][i + length] = current;
		}

		return sequence;
	}

	static int[][] StructuredRandom(int length)
	{
		int[][] sequence = new int[][] {new int[length*2],
										new int[length*2]};
		int max = (int)Mathf.Min(3, length-1);
		int same = 0;
		bool cleared;

		for (int i = 0; i < length; i += 1)
		{
			do
			{
				cleared = true;

				sequence[0][i] = Random.Range(0,max+1);
				sequence[0][i+length] = sequence[0][i];

				for(int j = 0; j < i; j += 1)
				{
					if(sequence[0][i] == sequence[0][j])
					{
						if(same == 2)
						{	cleared = false;	}
						else if(Random.Range(0, 2-same+1) == 0)
						{	same += 1;	}
						else
						{	cleared = false;	}
					}
				}
			}
			while(!cleared);
		}

		int current = 0;
		max = 2;

		for(int i = 0; i < length; i += 1)
		{
			if(i == 0)
			{
				if(same != max)
				{
					if(Random.Range(0, max-same+1) == 0)
					{
						current += 1;
						max -= 1;
					}
				}

			}
			for(int j = 0; j < i; j += 1)
			{
				if(sequence[0][i] == sequence[0][j])
				{
					current += 1;
					same -= 1;
					max -= 1;
					break;
				}
				else if(same != max)
				{
					if(Random.Range(0, max-same+1) == 0)
					{
						current += 1;
						max -= 1;
					}
				}
			}

			sequence[1][i] = current;
			sequence[1][i + length] = current;
		}
			
		return sequence;
	}

	static int[][] WildAndRandom(int length)
	{
		int[][] sequence = new int[][] {new int[length*2],
										new int[length*2]};
		int tries;
		int max = (int)Mathf.Min(3, length-1);
		bool cleared;

		for(int i = 0; i < length; i += 1)
		{
//			cleared = true;
			tries = 0;

			do
			{
				cleared = true;

				sequence[0][i] = Random.Range(0,max+1);
				sequence[1][i] = Random.Range(0,3);

				for(int j = 0; j < i; j += 1)
				{
					if(sequence[0][i] == sequence[0][j] && sequence[1][i] == sequence[1][j])
					{
						cleared = false;
						tries += 1;
						Debug.Log(sequence[0][i] + " " + sequence[1][i] + " " + sequence[0][j] + " " + sequence[1][j]);
					}
				}
			}
			while(!cleared && tries < 10);

			sequence[0][i+length] = sequence[0][i];
			sequence[1][i+length] = sequence[1][i];

			if(tries >= 10)
			{	Debug.Log ("10 tries at space " + i);	}
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
