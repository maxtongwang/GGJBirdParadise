using UnityEngine;
using System.Collections;

public class DisplayLetters : MonoBehaviour {

    public Transform _player1Pos; //vector3
    public Transform _player2Pos; //vector3
    public const float letter_lenght = 32;
    public const float letter_space = letter_lenght * 2;
    private const int total_letters = 24;
    public int currentLetters;

    private GameObject[] player1_letter;
    private GameObject[] player2_letter;

    public GameObject[] letters;
    //public GameObject[] cLetters;

    Vector3 letter_0 = new Vector3(0, 0, 0);
    Vector3 hidden = new Vector3(-100f, -100f, 0);
    int num = 23;
    // Use this for initialization
    void Start () {
        for (int i = letters.Length-1; i > -1; i--)
        {

            // Instantiate(letters[i], new Vector3(_player1Pos.transform.position.x, _player1Pos.transform.position.y , _player1Pos.transform.position.z), Quaternion.identity);
          letters[i].transform.position = letter_0;
        }
       // letters[0].transform.position = letter_0;

    }

    // Update is call
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)&&num>0)
        {
            letters[num].transform.position = hidden;
            num -= 1;
        }
    }
}
