using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GetInputFromUser : MonoBehaviour {

	ProgressBar progressBar;

    public String[] player1keys = { "Q", "W", "E", "R", "A", "S", "D", "F", "Z", "X", "C", "V" };
    public String[] player2keys = { "Y", "U", "I", "O", "P", "H", "J", "K", "L", "B", "N", "M" };
    public String[] thePlayer = new String[1];

	// hardcoded for testing
//	public string[] RandomArray1 = new String[3] { "A", "C", "D" };
//	public string[] RandomArray2 = new String[3] { "K", "N", "U" };
	public char[] RandomArray1;
	public char[] RandomArray2;
    public String temp;
    int inputArrayIndex1 = 0;
    int inputArrayIndex2 = 0;
    float p1Score;
    float p2Score;
	bool roundStarted = false;
	bool p1Playing = false;
	bool p2Playing = false;
	bool p1LastHit;
	bool p2LastHit;

	public void RecieveArrays(char[] p1Array, char[] p2Array)
	{
		RandomArray1 = p1Array;
		RandomArray2 = p2Array;
		roundStarted = true;
		p1Playing = true;
		p2Playing = true;
	}

    //Fuction to detect the key pressed by player
    public void detectPressedKey()
    {
		if (roundStarted)
		{
			foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
			{
				if (Input.GetKeyDown (keyCode))
				{
					Debug.Log ("The key was " + keyCode);
					getPlayerName (keyCode);
				}
			}
		}
    }

    //Function to compare the pressed key with both the KeySpaces to determine which player pressed the key
    void getPlayerName(KeyCode kCode)
    {
        for (int i = 0; i < player1keys.Length; i++)
        {
            if (kCode.ToString() == player1keys[i])
            {
                thePlayer[0] = "One";
                Debug.Log("It was Player " + thePlayer[0]);
                convertKeysToString(kCode);
                compareKeysWithDisplayedKeys(thePlayer, temp, RandomArray1, inputArrayIndex1);
            }
            else if (kCode.ToString() == player2keys[i])
            {
                thePlayer[0] = "Two";
                Debug.Log("It was Player " + thePlayer[0]);
                convertKeysToString(kCode);
                compareKeysWithDisplayedKeys(thePlayer, temp, RandomArray2, inputArrayIndex2);
            }
            else
            {

            }
        }
    }

    void compareKeysWithDisplayedKeys(String[] playerName, String tempString, String[] incomingArray, int index)
    {
        if(playerName[0] == "One")
        {
			// player pressed correct key
            if(tempString == incomingArray[index])
            {
                Debug.Log("P1 got the key right");
                p1Score = 1f;
				progressBar.makingProgressP1(p1Score);

				// at the end of sequence
                if (inputArrayIndex1 == incomingArray.Length)
                {
					p1Playing = false;
					if (!p2Playing)
					{	roundStarted = false;	}

                    // check who is faster
					// calculate player's accuracy
//					if()
//					{
//						;
//					}
                }
            }

            else
            {
                Debug.Log("P1 sucks");
				p1Score = -1f;
				progressBar.makingProgressP1(p1Score);

				// at the end of sequence
                if (inputArrayIndex1 == incomingArray.Length)
                {
					p1Playing = false;
					if (!p2Playing)
					{	roundStarted = false;	}
                    //calculateTotalScore(playerName[0], p1Score);
                }
            }

			inputArrayIndex1++;
        }


        else if(playerName[0] == "Two")
        {
            if (tempString == incomingArray[index])
            {
                Debug.Log("P2 got the key right");
				p2Score = 1f;
				progressBar.makingProgressP2(p2Score);

                if(inputArrayIndex2 == incomingArray.Length)
                {
					p2Playing = false;
					if (!p1Playing)
					{	roundStarted = false;	}
                    //calculateTotalScore(playerName[0], p2Score);
                }
            }

            else
            {
                Debug.Log("P2 sucks");
				p2Score = -1f;
				progressBar.makingProgressP2(p2Score);

				if (inputArrayIndex2 == incomingArray.Length)
                {
					p2Playing = false;
					if (!p1Playing)
					{	roundStarted = false;	}
                    //calculateTotalScore(playerName[0], p2Score);
                }
            }

			inputArrayIndex2++;
        }
    }

    /*float calculateTotalScore(String player, float score)
    {
        Debug.Log("The Final Score for player " + player + " is " + score);
        return score;
    }*/

    void convertKeysToString(KeyCode keyCode)
    {
        temp = keyCode.ToString();
    }

	// Use this for initialization
	void Start () {
		progressBar = GetComponent<ProgressBar>();
	}
	
	// Update is called once per frame
	void Update () {

        detectPressedKey();

    }
}