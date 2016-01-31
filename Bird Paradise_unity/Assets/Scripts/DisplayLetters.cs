using UnityEngine;
using System.Collections;

public class DisplayLetters : MonoBehaviour {

    public GameObject[] letters;
	//all the letters on screen, images of letters. added them mannually from editor 

    private static char[] Alphabet = new char[] { 'Q', 'W', 'E', 'R', 'A', 'S',
    'D', 'F', 'Z', 'X', 'C', 'V', 'Y', 'U', 'I', 'O', 'P', 'H', 'J', 'K', 'L', 'B', 'N', 'M' };

    //example
    char[] p_1 = { 'A', 'E', 'C', 'W','R' };
    char[] p_2 = { 'O', 'P', 'M', 'H' };

	GetInputFromUser getInputFromUser;
	SequenceGenerator sequenceGenerator;

    //example

   // Vector3 letter_0 = new Vector3(_player1Pos.position.x, _player1Pos.position.y, _player1Pos.position.z);
    Vector3 hidden = new Vector3(-20f, -20f, 0);
    int num = 23;

//	Vector3 disp_pos_p1=new Vector3(Screen.width*0.1f,Screen.height*0.7f,0);
//	Vector3 disp_pos_p2=new Vector3(Screen.width*0.4f,Screen.height*0.7f,0);
	Vector3 disp_pos_p1=new Vector3(-7.6f,3f,0);
	Vector3 disp_pos_p2=new Vector3(0.82f,3f,0);


    // Use this for initialization
    void Start () {
		GameObject MainCamera = GameObject.Find("Main Camera");
		getInputFromUser = MainCamera.GetComponent<GetInputFromUser>();
		sequenceGenerator = MainCamera.GetComponent<SequenceGenerator> ();

		for (int i = letters.Length-1; i > -1; i--)
        {
          letters[i].transform.position = new Vector3(-200f,-200f,0);
        }

		//findLetterImage(p_1, p_2); //read char arrays from other script

    }

    // Update is call
    void Update () {
		if (getInputFromUser.newSequence == true)
			disappear ();
			
        //if newsequence==true
		// disappear();
		// from getinutFromUser.cs
    }

	public  void findLetterImage(char[] array_1,char[] array_2)
    {
        int a1 = array_1.Length;
        int a2 = array_2.Length;

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

	public	void display(int i)
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

	public	void disappear(){ 
	for (int i = letters.Length-1; i > -1; i--)
	{
			letters[i].transform.position = hidden;
	}
	}
		
}
