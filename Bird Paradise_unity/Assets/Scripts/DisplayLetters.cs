using UnityEngine;
using System.Collections;

public class DisplayLetters : MonoBehaviour {

//    public Transform _player1Pos; //vector3
//    public Transform _player2Pos; //vector3
//    public const float letter_lenght = 32;
//    public const float letter_space = 1; //letter_lenght * 2;
//    private const int total_letters = 24;
//    public int currentLetters;
//
//    private GameObject[] player1_letter;
//    private GameObject[] player2_letter;

    public GameObject[] letters;

    private static char[] Alphabet = new char[] { 'Q', 'W', 'E', 'R', 'A', 'S',
    'D', 'F', 'Z', 'X', 'C', 'V', 'Y', 'U', 'I', 'O', 'P', 'H', 'J', 'K', 'L', 'B', 'N', 'M' };

    //example
    char[] p_1 = { 'A', 'E', 'C', 'W','R' };
    char[] p_2 = { 'O', 'P', 'M', 'H' };
    //example

   // Vector3 letter_0 = new Vector3(_player1Pos.position.x, _player1Pos.position.y, _player1Pos.position.z);
    Vector3 hidden = new Vector3(-100f, -100f, 0);
    int num = 23;

//	Vector3 disp_pos_p1=new Vector3(Screen.width*0.1f,Screen.height*0.7f,0);
//	Vector3 disp_pos_p2=new Vector3(Screen.width*0.4f,Screen.height*0.7f,0);
	Vector3 disp_pos_p1=new Vector3(-7.6f,3f,0);
	Vector3 disp_pos_p2=new Vector3(0.82f,3f,0);


    // Use this for initialization
    void Start () {
        for (int i = letters.Length-1; i > -1; i--)
        {
          letters[i].transform.position = new Vector3(-200f,-200f,0);
        }

		findLetterImage(p_1, p_2);

    }

    // Update is call
    void Update () {
        //if (Input.GetKeyDown(KeyCode.Space)&&num>0)
        //{
        //    letters[num].transform.position = hidden;
        //    num -= 1;
        //}

    }

    void findLetterImage(char[] array_1,char[] array_2)
    {
        int a1 = array_1.Length;
        int a2 = array_2.Length;

//        float p1 = _player1Pos.transform.position.x - 5;
//        float p2 = _player2Pos.transform.position.x - 5;
//
//        while (a1 < 0 && a2 < 0)
//        {
//            for (int i = 0; i < Alphabet.Length; i++)
//            {
//                if (array_1[i] == Alphabet[i])
//                {
//                    Debug.Log(array_1[i]);
//                    displayLetterImage(i, new Vector3(p1 + letter_space, _player1Pos.transform.position.y, _player1Pos.transform.position.z));
//                    a1--;
//                }
//
//                if (array_2[i] == Alphabet[i])
//                {
//                    displayLetterImage(i, new Vector3(p2 + letter_space, _player2Pos.transform.position.y, _player2Pos.transform.position.z));
//                    a2--;
//                }
//            }
//        }



		for (int i = 0; i < a1; i++)
			for (int j = 0; j < Alphabet.Length; j++) {
				if (array_1 [i] == Alphabet [j])
					display (j);
			}

		for (int i = 0; i < a2; i++)
			for (int j = 0; j < Alphabet.Length; j++) {
				if (array_2 [i] == Alphabet [j])
					display (j);
			}

    }

	void display(int i)
	{
		if (i <=11) {
			letters [i].transform.position = disp_pos_p1;
			disp_pos_p1.x += 1f;
		}

		if (i > 11) {
			letters [i].transform.position = disp_pos_p2;
			disp_pos_p2.x += 1f;
		}
	}

//    void displayLetterImage(int posImg,Vector3 player)
//    {
//        for (int i = 0; i < letters.Length; i++)
//        {
//            if (posImg == i)
//            {
//                letters[i].transform.position = player;
//                break;
//            }
//        }
//    }



}
