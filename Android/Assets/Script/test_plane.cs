using UnityEngine;
using System.Collections;
using Com.BehaviourManamger;
using Com.ModelManamger;

public class test_plane : MonoBehaviour {
	public Behaviour_manager test_ma = new Behaviour_manager();
	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.WindowsEditor) {
			if (Input.GetMouseButtonDown (0)) {
				CheckTouch(Input.mousePosition, "began");
			}
			
			if (Input.GetMouseButtonUp (0)) {
				CheckTouch (Input.mousePosition, "ended");
			}
		} else {
		}
	}


	void CheckTouch(Vector3 pos, string phase)
	{
		/* Get the screen point where the user is touching */
		Vector3 wp =  Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint(touchPos);
		
		/* if button is touched... */
		if (hit.gameObject.name == "r1" && hit && phase == "began")
		{
			/*
			int i = 0;
			Game_object object_manager = new Game_object ();
			GameObject this_one = GameObject.Find(object_manager.plane [i] );
			int temp = i / 4;
			Chess_Position pos1 = new Chess_Position ();
			Vector2 te = new Vector2 (0.6f, 4.2f);
			if (temp == 0) {
				print("good");
				this_one.transform.position = te;
				print (temp + " " + this_one.transform.position.x + " " + this_one.transform.position.z);
			} else {
				this_one.transform.position = pos1.position [temp, 0];
			}

			//print (temp + " " + pos1.position [temp, 0].x + " " + pos1.position [temp, 0].y);*/
			test_ma.Out_Home(0);
			//test_ma.Back_Home(0);
		
	}

}
}
