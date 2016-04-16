using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Com.ModelManamger;
using Com.BehaviourManamger;
namespace Com.Controller {

/*
struct Number {
		public int userNum;
		public int planeNum;
		public Number(int userNum_, int planeNum_) {
			userNum = userNum_;
			planeNum = planeNum_;
				}
	};
	Dictionary<string, Number> Name_Get_Number = new Dictionary<string, Number>();
	Name_Get_Number.Add ("r1", Number(0, 0));
	Name_Get_Number.Add ("r2", Number(0, 1));
	Name_Get_Number.Add ("r3", Number(0, 2));
	Name_Get_Number.Add ("r4", Number(0, 3));
	
	Name_Get_Number.Add ("b1", Number(1, 0));
	Name_Get_Number.Add ("b2", Number(1, 1));
	Name_Get_Number.Add ("b3", Number(1, 2));
	Name_Get_Number.Add ("b4", Number(1, 3));
	
	Name_Get_Number.Add ("y1", Number(2, 0));
	Name_Get_Number.Add ("y2", Number(2, 1));
	Name_Get_Number.Add ("y3", Number(2, 2));
	Name_Get_Number.Add ("y4", Number(2, 3));
	
	Name_Get_Number.Add ("g1", Number(3, 0));
	Name_Get_Number.Add ("g2", Number(3, 1));
	Name_Get_Number.Add ("g3", Number(3, 2));
	Name_Get_Number.Add ("g4", Number(3, 3));
*/


public class Controller {
    public int diceNum;
	public int userNum;
	public int planeNum;
    public bool gameOver;
    public int processTag;
    public GameObject obj;

	public Behaviour_manager test_ma = new Behaviour_manager();

    //单例
	public Game_object object_manager;
	public Chess_Position pos;
	public static Controller Controller_instance;

    void setting(GameObject obj, int planeNum) {
        this.obj = obj;
		this.planeNum = planeNum;
    }



		/* public void run(Number input, GameObject obja) {
			int thisUser = input.userNum;
			int thisPlane = input.planeNum;
			Debug.Log("userNum:" + userNum);*/


	public void run(int thisUser, int thisPlane, GameObject obja) {
			Debug.Log("userNum:" + userNum);
		//确定用户权限			l
        if (processTag == 0) {
            //等待丢骰子
				if (isDice(obja) && thisUser == -1) {
                //点击的物体是骰子
					diceNum = test_ma.turn_dice() + 1;
                if(diceNum != 6 && allAtHome()) {
                    //不可以起飞且全部飞机在家里
                    nextUser();
                } else {
                    nextProcess();
                }

            }
        } else {
			if (thisUser != userNum)
				return;
			else
				setting (obja, thisPlane);

            //等待选飞机
			if (isMyPlane(obj)) {
               if (diceNum == 6) {
                    //可以起飞
                    if (planeAtHome(obj)) {
						test_ma.Out_Home(4 * userNum + planeNum);
                    } else {
                        //飞机移动
						test_ma.Move(4 * userNum + planeNum, diceNum);
                        reaction();
                    }
                    nextProcess();
                } else {
                    //不可以起飞
                    if (planeAtHome(obj)) {
						return;
                    } else {
                        //飞机移动
						test_ma.Move(4 * userNum + planeNum, diceNum);
                        reaction();
                        nextProcess();
                        nextUser();
                    }
                }
            }
        }
    }


    //确认选择的物体是骰子
    bool isDice(GameObject obj) {
			if (obj.name.Equals("dice") || obj.name.Equals("dices"))
                return true;
        return false;
    }

    //确认选择的物体是当前用户的飞机
    bool isMyPlane(GameObject obj) {
		int index = 4 * userNum;
        for (int i = index; i < index + 4; i++)
				if (obj.name.Equals(object_manager.plane [i])) {
										return true;
								}
        return false;
    }

    //确认选择的飞机是否在家
    bool planeAtHome(GameObject obj) {
        for (int i = 57; i < 61; i++) {
				if (Game_object.subscript[4 * userNum + planeNum] == (57 + planeNum))
                return true;
        }
        return false;
    }

    //判断是否所有的飞机都在家
    bool allAtHome() {
        int index = 4 * userNum;

			return Game_object.subscript[4 * userNum + 0] == (57 + 0)
				&& Game_object.subscript[4 * userNum + 1] == (57 + 1)
				&& Game_object.subscript[4 * userNum + 2] == (57 + 2)
				&& Game_object.subscript[4 * userNum + 3] == (57 + 3);
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
    }

    void reaction() {
		reaction_Enemy ();
		if (reaction_Fly()) {
			reaction_Enemy ();
			reaction_SomeColor ();
			reaction_Enemy ();
		} else if (reaction_SomeColor()) {
			reaction_Enemy ();
			reaction_Fly ();
			reaction_Enemy ();
		}
		reaction_Done ();
	}

	void reaction_Enemy() {
		int here = Game_object.global[4 * userNum + planeNum];//Game_object.subscript[4 * userNum + planeNum];//GameObject.Find(object_manager.plane [4 * userNum + planeNum]).transform.position;
		for (int i = 0; i < 16; i++) {
			if (4 * userNum <= i && i < 4 * userNum + 4)
				continue;
			if (here == Game_object.global[i]) {
				//回家
				test_ma.Back_Home(i);
			}
		}
	}

	bool reaction_Fly()  {
			int here = Game_object.subscript[4 * userNum + planeNum];
		if (here == 18) {
				test_ma.Fly (4 * userNum + planeNum);
			return true;
		}
		return false;
	}

	bool reaction_SomeColor() {
			int here = Game_object.subscript [4 * userNum + planeNum];
		if (here >= 50 || here == 0)
			return false;
		here -= 2;
		if (here % 4 == 0) {
			test_ma.Move (4 * userNum + planeNum, 4);
			return true;
		}
			return false;
	}

	void reaction_Done() {
			if (Game_object.subscript[4 * userNum + planeNum] == 56) {
			//到达终点
			test_ma.Back_Home(4 * userNum + planeNum);
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