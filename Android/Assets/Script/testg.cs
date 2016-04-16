using UnityEngine;
using System.Collections;
using Com.BehaviourManamger;
using Com.ModelManamger;
using Com.Controller;


public class testg : MonoBehaviour {
	public Controller test_ba = Controller.GetInstance();
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
		} else {
			if (Application.platform == RuntimePlatform.WindowsPlayer) {
				if (Input.GetMouseButtonDown (0)) {
					CheckTouch (Input.mousePosition, "began");
				}
				
				if (Input.GetMouseButtonUp (0)) {
					CheckTouch (Input.mousePosition, "ended");
				}
				
			}
		}
		
		
		
	}
	
	void CheckTouch(Vector3 pos, string phase) {
		/* Get the screen point where the user is touching */
		Vector3 wp =  Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint(touchPos);
		
		/* if button is touched... */
		if (hit.gameObject.name == "g3" && hit && phase == "began") {
			print ("g3");
			test_ba.run (3, 2, this.gameObject);
		}
	}
}
