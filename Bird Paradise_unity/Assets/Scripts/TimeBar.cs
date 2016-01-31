using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class TimeBar : MonoBehaviour {

	public Slider healthBarSlider;  //reference for slider
	float timer;
	float healthbar_rate=0.1f;
	public GameObject player1_marker;//time bar wining marker for player 1
	public GameObject player2_marker;//time bar wining marker for player 2
	GetInputFromUser getInputFromUser;


	// Use this for initialization
	void Start () {

		GameObject MainCamera = GameObject.Find("Main Camera");
		getInputFromUser = MainCamera.GetComponent<GetInputFromUser>();

		 timer = Time.deltaTime;
		healthBarSlider.value = 1;//set current time bar in full length 


		healthbar_rate = 1 / getInputFromUser.calculateTotalTime(); 
		// healthbar_rate=1/caculatetotoaltime.totoaltime 
		// from getinutFromUser.cs 
	}
	
	// Update is called once per frame
	void Update () {
		 timer += Time.deltaTime;//start caculate time

		if(healthBarSlider.value>0)
			healthBarSlider.value= 1f- timer*healthbar_rate;


	    else
			Debug.Log("you lose");
		
		finish_game ();//call finish_game function decide if the player wins 

		//victory marker
		if (finish_game ()==1)
			player1_marker.transform.position = new Vector3 (healthBarSlider.transform.position.x-83.5f+ 167f * healthBarSlider.value,  healthBarSlider.transform.position.y);
		if (finish_game ()==2)
			player2_marker.transform.position = new Vector3 (healthBarSlider.transform.position.x-83.5f+ 167f * healthBarSlider.value,  healthBarSlider.transform.position.y);
		

         }


	public int finish_game(){
		if (getInputFromUser.p1End==true)   // if p1End==true. from getinutFromUser.cs 
			return 1;
		else if (getInputFromUser.p2End==true) // if p2End==true.  from getinutFromUser.cs
			return 2;
		else
			return 3;
			}
	
}

