using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Com.ModelManamger;
using Com.BehaviourManamger;
namespace Com.Controller {
	public class Controller {
		public int diceNum;
		public int userNum;
		public int planeNum;
		public bool gameOver;
		public int processTag;
		public GameObject obj;
		
		public The_Action test_ma = new Behaviour_manager();
		
		//单例
		public Game_object object_manager;
		public Chess_Position pos;
		public static Controller Controller_instance;
		
		void setting(GameObject obj, int planeNum) {
			this.obj = obj;
			this.planeNum = planeNum;
		}

		public void run(int thisUser, int thisPlane, GameObject obja) {
			Debug.Log("userNum:" + userNum);
			//确定用户权限			l
			if (processTag == 0) {
				//等待丢骰子
				Debug.Log ("投骰子");
				if (isDice (obja) && thisUser == -1)
					turnDice(thisUser, thisPlane);
			} else {
				Debug.Log ("选飞机");
				if (thisUser != userNum)
					return;
				else
					setting (obja, thisPlane);
				//等待选飞机
				planeAction(thisUser, thisPlane, diceNum);
			}
		}
		
		int turnDice(int thisUser, int thisPlane) {
			//点击的物体是骰子
			diceNum = test_ma.turn_dice () + 1;
			if (diceNum != 6 && allAtHome (userNum)) {
				//不可以起飞且全部飞机在家里
				nextUser ();
			} else {
				nextProcess ();
			}
			return diceNum;
		}
		
		
		//确认选择的物体是骰子
		bool isDice(GameObject obj) {
			if (obj.name.Equals("dice") || obj.name.Equals("dices"))
				return true;
			return false;
		}
		
		
		void planeAction(int thisUser, int thisPlane, int thisDice) {
			if (thisDice == 6) {
				//可以起飞
				if (planeAtHome (thisUser, thisPlane)) {
					test_ma.Out_Home (4 * thisUser + thisPlane);
				} else {
					//飞机移动
					test_ma.Move (4 * thisUser + thisPlane, thisDice);
					reaction (thisUser, thisPlane);
				}
				nextProcess ();
			} else {
				//不可以起飞
				if (planeAtHome (thisUser, thisPlane)) {
					return;
				} else {
					//飞机移动
					test_ma.Move (4 * thisUser + thisPlane, thisDice);
					reaction (thisUser, thisPlane);
					nextProcess ();
					nextUser ();
				}
			}
		}
		
		//确认选择的物体是当前用户的飞机
		//这个函数似乎没有存在的意义
		bool isMyPlane(int thisUser, int thisPlane) {
			int index = 4 * thisUser;
			GameObject obj = GameObject.Find (object_manager.plane[index + thisPlane]);
			for (int i = index; i < index + 4; i++)
			if (obj.name.Equals(object_manager.plane [i])) {
				return true;
			}
			return false;
		}
		
		//确认选择的飞机是否在家
		bool planeAtHome(int thisUser, int thisPlane) {
			for (int i = 57; i < 61; i++) {
				if (Game_object.subscript[4 * thisUser + thisPlane] == (57 + thisPlane))
					return true;
			}
			return false;
		}
		
		//判断是否所有的飞机都在家
		bool allAtHome(int thisUser) {
			return Game_object.subscript[4 * thisUser + 0] == (57 + 0)
				&& Game_object.subscript[4 * thisUser + 1] == (57 + 1)
				&& Game_object.subscript[4 * thisUser + 2] == (57 + 2)
				&& Game_object.subscript[4 * thisUser + 3] == (57 + 3);
		}
		
		
		//下一个流程， 0：等待点击骰子， 1：等待选择飞机
		void nextProcess() {
			processTag = processTag == 0 ? 1 : 0;
		}
		
		//切换用户
		void nextUser() {
			userNum++;
			if (userNum >= 4)
				userNum = 0;
			changePlane ();
			//resetDice();
		}

		//切换显示当前用户颜色使用的飞机
		void changePlane() {
				Game_object object_manager = new Game_object ();
				for (int i = 0; i < 4; i++) {
					GameObject temp = GameObject.Find(object_manager.user[i]);
					temp.renderer.enabled = false;	
				}
				GameObject temp1 = GameObject.Find(object_manager.user[userNum]);
				temp1.renderer.enabled = true;	
		}

		void reaction(int thisUser, int thisPlane) {
			reaction_Enemy (thisUser, thisPlane);
			if (reaction_Fly(thisUser, thisPlane)) {
				reaction_Enemy (thisUser, thisPlane);
				reaction_SomeColor (thisUser, thisPlane);
				reaction_Enemy (thisUser, thisPlane);
			} else if (reaction_SomeColor(thisUser, thisPlane)) {
				reaction_Enemy (thisUser, thisPlane);
				reaction_Fly (thisUser, thisPlane);
				reaction_Enemy (thisUser, thisPlane);
			}
			reaction_Done (thisUser, thisPlane);
		}
		
		void reaction_Enemy(int thisUser, int thisPlane) {
			int here = Game_object.global[4 * thisUser + thisPlane];//Game_object.subscript[4 * userNum + planeNum];//GameObject.Find(object_manager.plane [4 * userNum + planeNum]).transform.position;
			for (int i = 0; i < 16; i++) {
				if (4 * thisUser <= i && i < 4 * thisUser + 4)
					continue;
				if (here == Game_object.global[i]) {
					//回家
					test_ma.Back_Home(i);
				}
			}
		}
		
		bool reaction_Fly(int thisUser, int thisPlane)  {
			int here = Game_object.subscript[4 * thisUser + thisPlane];
			if (here == 18) {
				test_ma.Fly (4 * thisUser + thisPlane);
				return true;
			}
			return false;
		}
		
		bool reaction_SomeColor(int thisUser, int thisPlane) {
			int here = Game_object.subscript [4 * thisUser + thisPlane];
			if (here >= 50 || here == 0)
				return false;
			here -= 2;
			if (here % 4 == 0) {
				test_ma.Move (4 * thisUser + thisPlane, 4);
				return true;
			}
			return false;
		}
		
		void reaction_Done(int thisUser, int thisPlane) {
			if (Game_object.subscript[4 * thisUser + thisPlane] == 56) {
				//到达终点
				test_ma.Done(4 * thisUser + thisPlane);
			}
		}
		
		public static Controller GetInstance() {
			if (Controller_instance == null) {
				Controller_instance = new Controller();
			}
			return Controller_instance;
		}
		
		private Controller() {
			pos = new Chess_Position ();
			object_manager = new Game_object ();
			processTag = 0;
			gameOver = false;
		}
	}
}