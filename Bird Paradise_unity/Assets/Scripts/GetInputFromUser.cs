using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GetInputFromUser : MonoBehaviour {

    public String[] player1keys = { "Q", "W", "E", "R", "A", "S", "D", "F", "Z", "X", "C", "V" };
    public String[] player2keys = { "Y", "U", "I", "O", "P", "H", "J", "K", "L", "B", "N", "M" };
    public String[] thePlayer = new String[1];
    public String[] RandomArray1 = new String[3] { "A", "C", "D" };
    public String[] RandomArray2 = new String[3] { "K", "N", "U" };
    public String temp;
    int inputArrayIndex1 = 0;
    int inputArrayIndex2 = 0;
    float p1Score = 0;
    float p2Score = 0;

    //Fuction to detect the key pressed by player
    public void detectPressedKey()
    {
        foreach(KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                Debug.Log("The key was " + keyCode);
                getPlayerName(keyCode);
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
            if(tempString == incomingArray[index])
            {
                Debug.Log("P1 got the key right");
                p1Score++;
                inputArrayIndex1++;
                if (inputArrayIndex1 == incomingArray.Length)
                {
                    //calculateTotalScore(playerName[0], p1Score);
                }
            }
            else
            {
                Debug.Log("P1 sucks");
                inputArrayIndex1++;
                if (inputArrayIndex1 == incomingArray.Length)
                {
                    //calculateTotalScore(playerName[0], p1Score);
                }
            }
        }
        else if(playerName[0] == "Two")
        {
            if (tempString == incomingArray[index])
            {
                Debug.Log("P2 got the key right");

                inputArrayIndex2++;
                if(inputArrayIndex2 == incomingArray.Length)
                {
                    //calculateTotalScore(playerName[0], p2Score);
                }
            }
            else
            {
                Debug.Log("P2 sucks");
                inputArrayIndex2++;
                if (inputArrayIndex2 == incomingArray.Length)
                {
                    //calculateTotalScore(playerName[0], p2Score);
                }
            }
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
	
	}
	
	// Update is called once per frame
	void Update () {

        detectPressedKey();

    }
}