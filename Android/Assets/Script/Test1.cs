using UnityEngine;
using System.Collections;
using Com.BehaviourManamger;
using Com.ModelManamger;


public class Test1 : MonoBehaviour {
	public Behaviour_manager test_ma = new Behaviour_manager();
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if (Application.platform == RuntimePlatform.WindowsEditor) {
			if (Input.GetMouseButtonDown (0)) {
				CheckTouch (Input.mousePosition, "began");
			}
			
			if (Input.GetMouseButtonUp (0)) {
				CheckTouch (Input.mousePosition, "ended");
			}
		} /*else {
			if (Application.platform == RuntimePlatform.WindowsPlayer) {
				if (Input.GetMouseButtonDown (0)) {
					CheckTouch (Input.mousePosition, "began");
				}
				
				if (Input.GetMouseButtonUp (0)) {
					CheckTouch (Input.mousePosition, "ended");
				}
				
			}
		}*/



	}

	void CheckTouch(Vector3 pos, string phase)
	{
		/* Get the screen point where the user is touching */
		Vector3 wp =  Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint(touchPos);
		
		/* if button is touched... */
		if (hit.gameObject.name == "dices" && hit && phase == "began")
		{
			int tes = test_ma.turn_dice();
			print("!!!");
			/*
			System.Random ran=new System.Random();
			int turn_num=ran.Next(0,7);
			/*Random ran=new Random();
			//Random.Range(1,7);
			int turn_num = */
			//GameObject temp = GameObject.Find("dice_1");
			/*print ("dices" + turn_num);
			Game_object object_manager = new Game_object ();
			for (int i = 0; i < 10; i++) {
				GameObject temp = GameObject.Find(object_manager.dice[i]);
				temp.renderer.enabled = false;	
				//object_manager.dice[i].renderer.enabled = false;	
			}

			for (int i = 0; i <= 9; i++) {
				GameObject temp;
				if(i > 0) {
					temp = GameObject.Find(object_manager.dice[i-1]);
					temp.renderer.enabled = false;
					//System.Threading.Thread.Sleep(5);
				}
				temp = GameObject.Find(object_manager.dice[i]);
				temp.renderer.enabled = true;	
				//timeDelay(50);
				//Thread.Sleep(1000);
				//object_manager.dice[i].renderer.enabled = true;
			}
			GameObject temp1 = GameObject.Find(object_manager.dice[9]);
			temp1.renderer.enabled = false;	
			temp1 = GameObject.Find(object_manager.dice[turn_num]);
			temp1.renderer.enabled = true;	
			//object_manager.dice[9].renderer.enabled = false;
			//object_manager.dice[turn_num].renderer.enabled = true;*/
		}

	}


}
 
