using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GetInputFromUser : MonoBehaviour {

	ProgressBar progressBar;

    public String[] player1keys = { "Q", "W", "E", "R", "A", "S", "D", "F", "Z", "X", "C", "V" };
    public String[] player2keys = { "Y", "U", "I", "O", "P", "H", "J", "K", "L", "B", "N", "M" };
    public String[] thePlayer = new String[1];
    public float[] timeTaken = new float[2];

	// hardcoded for testing
//	public string[] RandomArray1 = new String[3] { "A", "C", "D" };
//	public string[] RandomArray2 = new String[3] { "K", "N", "U" };
	public char[] RandomArray1;
	public char[] RandomArray2;
	public char temp;
    int inputArrayIndex1 = 0;
    int inputArrayIndex2 = 0;
    float p1Score;
    float p2Score;
    float p1ClickScore = 0;
    float p2ClickScore = 0;
	bool roundStarted = false;
	bool p1Playing = false;
	bool p2Playing = false;
	bool p1LastHit;
	bool p2LastHit;
    float timer;
    float totalTime = 1;
    //float finalScore;

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

	void compareKeysWithDisplayedKeys(string[] playerName, char tempString, char[] incomingArray, int index)
    {
        if(playerName[0] == "One")
        {
			// player pressed correct key
            if(tempString == incomingArray[index])
            {
                Debug.Log("P1 got the key right at the time " + timer);
                p1Score += 1f;
                p1ClickScore++;
				progressBar.makingProgressP1(p1Score);

				// at the end of sequence
                if (inputArrayIndex1 == incomingArray.Length - 1)
                {
                    // check for bonus eligiblity here
                    

                    Debug.Log("The condition is satisfied " + playerName[0]);
                    getTimeUsedByPlayer(playerName);
                    p1Playing = false;

                    p1ClickScore = 0;

                    if (!p2Playing)
					{
                        roundStarted = false;
                    }  
                }
            }

            else
            {
				Debug.Log("P1 sucks, the correct key was " + temp);
				p1Score += -1f;
                //p1ClickScore -=1/2;
                progressBar.makingProgressP1(p1Score);

				// at the end of sequence
                if (inputArrayIndex1 == incomingArray.Length - 1)
                {
                    Debug.Log("The condition is satisfied " + playerName[0]);
                    getTimeUsedByPlayer(playerName);
                    p1Playing = false;

                    if (!p2Playing)
					{
                        roundStarted = false;
                    }
                    //calculateTotalScore(playerName[0], p1Score);
                }
            }

			inputArrayIndex1++;
        }


        else if(playerName[0] == "Two")
        {
            if (tempString == incomingArray[index])
            {
                Debug.Log("P2 got the key right at the time " + timer);
				p2Score += 1f;
                p2ClickScore++;
                progressBar.makingProgressP2(p2Score);

                if(inputArrayIndex2 == incomingArray.Length - 1)
                {
                    // check for bonus eligiblity here

                    Debug.Log("The condition is satisfied " + playerName[0]);
                    getTimeUsedByPlayer(playerName);
                    p2Playing = false;

                    p2ClickScore = 0;

					if (!p1Playing)
					{
                        roundStarted = false;
                    }
                    //calculateTotalScore(playerName[0], p2Score);
                }
            }

            else
            {
                Debug.Log("P2 sucks");
				p2Score += -1f;
                //p2ClickScore -=1/2;
                progressBar.makingProgressP2(p2Score);

				if (inputArrayIndex2 == incomingArray.Length - 1)
                {
                    Debug.Log("The condition is satisfied " + playerName[0]);
                    getTimeUsedByPlayer(playerName);
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
		temp = keyCode.ToString().ToCharArray()[0];
    }

    void getTimeUsedByPlayer(String[] player)
    {
        if (player[0] == "One")
        {
            timeTaken[0] = timer;
            Debug.Log("The total time taken by the Player 1 is " + timeTaken[0]);
        }
        else if (player[0] == "Two")
        {
            timeTaken[1] = timer;
            Debug.Log("The total time taken by the Player 2 is " + timeTaken[1]);
        }
    }

    // call below function only when a player is able to have a bonus
    void scoreTimeBonusP1(float score)
    {     
        score *= (((totalTime - timeTaken[0]) / totalTime) / 8) + 1;
        Debug.Log("Player 1 score is " + score);
        progressBar.makingProgressP1(score);
    }

    void scoreTimeBonusP2(float score)
    {
        score *= (((totalTime - timeTaken[1]) / totalTime) / 8) + 1;
        Debug.Log("Player 2 score is " + score);
        progressBar.makingProgressP2(score);
    }

    // Use this for initialization
    void Start () {
		progressBar = GetComponent<ProgressBar>();
        timer = Time.deltaTime;

        p1Score = .0f;
        p2Score = .0f;
	}

    void calculateTotalTime()
    {
        for(int i = 0; i < RandomArray1.Length; i++)
        {
            totalTime += Mathf.Pow(0.8f, i);
        }
        Debug.Log("Time allowed to complete the task is " + totalTime);
    }

    void bonusEligibility()
    {
        if ((timeTaken[0] < timeTaken[1]) && (p1ClickScore >= p2ClickScore))
        {
            scoreTimeBonusP1(p1Score);
            Debug.Log("P1 won");
        }
        else if ((timeTaken[1] < timeTaken[0]) && (p2ClickScore >= p1ClickScore))
        {
            scoreTimeBonusP2(p2Score);
            Debug.Log("P2 won");
        }
    }
	
	// Update is called once per frame
	void Update () {

        detectPressedKey();
        timer += Time.deltaTime;
        if(timer > totalTime)
        {
            bonusEligibility();
            Debug.Break();
            SceneManager.LoadScene("Score");
        }
    }

    void Awake()
    {
        calculateTotalTime();
    }
}