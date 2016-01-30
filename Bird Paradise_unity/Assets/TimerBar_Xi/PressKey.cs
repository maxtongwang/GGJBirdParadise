using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class PressKey : MonoBehaviour {

	public Slider healthBarSlider;  //reference for slider
	float timer;
	float healthbar_rate=0.1f;
	public GameObject player1_marker;//time bar wining marker for player 1
	public GameObject player2_marker;//time bar wining marker for player 2


	// Use this for initialization
	void Start () {
		 timer = Time.deltaTime;
		healthBarSlider.value = 1;//set current time bar in full length 
		//transform.localPosition = new Vector3 (-461, 170f);//set in a invisible place outside of screen

	}
	
	// Update is called once per frame
	void Update () {
		 timer += Time.deltaTime;//start caculate time

		if(healthBarSlider.value>0)
			healthBarSlider.value= 1- timer*healthbar_rate;
	    else
			Debug.Log("you lose");
		
		finish_game ();//call finish game function decide if the player wins 

		if (finish_game ()==1)
			player1_marker.transform.localPosition = new Vector3 (-302.5f + 160 * healthBarSlider.value, 149f);
		//the coords of 344, 160, 170 depends on canvas size. ask Xi for detail 
		if (finish_game ()==2)
			player2_marker.transform.localPosition = new Vector3 (-302.5f + 160 * healthBarSlider.value,149f);



         }


	public int finish_game(){
		if (Input.GetKeyDown (KeyCode.A))
			return 1;
		else if (Input.GetKeyDown (KeyCode.B))
			return 2;
		else
			return 3;
			}
	
}

