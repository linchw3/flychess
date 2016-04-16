using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Com.Controller;
using Com.ModelManamger;
using Com.BehaviourManamger;

namespace Com.AI {

public class AIRule {
		public void run() {
			
		}


		/* choose the plane which can be moved
		 * return he plane number
		 * if there is no plane can be moved
		 * return -1
		 */
		/*int choosePlane(int thisUser, int diceNum) {
			int index = 4 * thisUser;
			if (diceNum == 6) {
				for (int i = 0; i < 4; i++) {
					if (!control.planeDone(thisUser, i)) {
							return i;		//要的是planeNum
					}
				}
				return -1;
			} else {
				for (int i = 0; i < 4; i++) {
					if (!control.planeAtHome(thisUser, i) && !control.planeDone(thisUser, i)) {
						return i;
					}
				}
				return -1;
			}
		}

		int turnDice(int thisUser, int thisPlane) {
			return control.turnDice (thisUser, thisPlane);
		}

		void move(int thisUser, int thisPlane, int diceNum) {
			control.planeAction (thisUser, thisPlane, diceNum);
		}*/
			
	}

}