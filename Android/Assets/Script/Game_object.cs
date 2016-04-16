using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Com.ModelManamger {
	public struct Number {
		public int userNum;
		public int planeNum;
		public Number(int userNum_, int planeNum_) {
			userNum = userNum_;
			planeNum = planeNum_;
		}
	}

	public class Game_object : MonoBehaviour{
		//public static Game_object Game_object_instance;
		//use to save the plane
		public string[] user = new string[] {"red", "blue", "yellow", "green"};
		public string[] plane = new string[] {"r1", "r2", "r3", "r4", "b1", "b2", "b3", "b4", "y1", "y2", "y3","y4",
		"g1", "g2", "g3", "g4"};/* = new GameObject[16]{GameObject.Find("r1"), GameObject.Find("r2"), GameObject.Find("r3"),
		GameObject.Find("r4"), GameObject.Find("b1"), GameObject.Find("b2"), GameObject.Find("b3"), GameObject.Find("b4"),
		GameObject.Find("y1"), GameObject.Find("y2"), GameObject.Find("y3"), GameObject.Find("y4"), GameObject.Find("g1"),
		GameObject.Find("g2"), GameObject.Find("g3"), GameObject.Find("g4")};*/

		//用于存储每个对象所处的位置的坐标，避免每次遍历的麻烦；
		public static int[] subscript = new int[] {57, 58, 59, 60, 57, 58, 59, 60, 57, 58, 59, 60, 57, 58, 59, 60};
		public static int[] global = new int[] {57, 58, 59, 60, 57, 58, 59, 60, 57, 58, 59, 60, 57, 58, 59, 60};
		public static bool[] done = new bool[] {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
		public static Dictionary<string, Number> Name_Get_Number = new Dictionary<string, Number>();

		public Game_object() {
			if (Name_Get_Number.Count == 0) {
								Name_Get_Number.Add ("r1", new Number (0, 0));
								Name_Get_Number.Add ("r2", new Number (0, 1));
								Name_Get_Number.Add ("r3", new Number (0, 2));
								Name_Get_Number.Add ("r4", new Number (0, 3));
			
								Name_Get_Number.Add ("b1", new Number (1, 0));
								Name_Get_Number.Add ("b2", new Number (1, 1));
								Name_Get_Number.Add ("b3", new Number (1, 2));
								Name_Get_Number.Add ("b4", new Number (1, 3));
			
								Name_Get_Number.Add ("y1", new Number (2, 0));
								Name_Get_Number.Add ("y2", new Number (2, 1));
								Name_Get_Number.Add ("y3", new Number (2, 2));
								Name_Get_Number.Add ("y4", new Number (2, 3));
			
								Name_Get_Number.Add ("g1", new Number (3, 0));
								Name_Get_Number.Add ("g2", new Number (3, 1));
								Name_Get_Number.Add ("g3", new Number (3, 2));
								Name_Get_Number.Add ("g4", new Number (3, 3));
						}
		}
		//use to save the dice;
		public string[] dice = new string[]{"dice_1", "dice_2", "dice_3", "dice_4", "dice_5", "dice_6", "dice_action_0", "dice_action_1",
			"dice_action_2", "dice_action_3"};/* = new GameObject[] {GameObject.Find("dice_1"), GameObject.Find("dice_2"), 
			GameObject.Find("dice_3"),GameObject.Find("dice_4"), GameObject.Find("dice_5"), GameObject.Find("dice_6"),
			GameObject.Find("dice_action_0"),GameObject.Find("dice_action_1"), 
			GameObject.Find("dice_action_2"), GameObject.Find("dice_action_3")};*/
		/*
		public static Game_object GetInstance() {
			if (Game_object_instance == null) {
				Game_object_instance = new Game_object();
			}
			return Game_object_instance;
		}*/
		/*
		public Game_object() {
			plane = new GameObject[] {GameObject.Find("r1"), GameObject.Find("r2"), GameObject.Find("r3"),
				GameObject.Find("r4"), GameObject.Find("b1"), GameObject.Find("b2"), GameObject.Find("b3"), GameObject.Find("b4"),
				GameObject.Find("y1"), GameObject.Find("y2"), GameObject.Find("y3"), GameObject.Find("y4"), GameObject.Find("g1"),
				GameObject.Find("g2"), GameObject.Find("g3"), GameObject.Find("g4")};
			dice = new GameObject[] {GameObject.Find("dice_1"), GameObject.Find("dice_2"), 
				GameObject.Find("dice_3"),GameObject.Find("dice_4"), GameObject.Find("dice_5"), GameObject.Find("dice_6"),
				GameObject.Find("dice_action_0"),GameObject.Find("dice_action_1"), 
				GameObject.Find("dice_action_2"), GameObject.Find("dice_action_3")};
				}

		void init_this() {
			plane = new GameObject[] {GameObject.Find("r1"), GameObject.Find("r2"), GameObject.Find("r3"),
				GameObject.Find("r4"), GameObject.Find("b1"), GameObject.Find("b2"), GameObject.Find("b3"), GameObject.Find("b4"),
				GameObject.Find("y1"), GameObject.Find("y2"), GameObject.Find("y3"), GameObject.Find("y4"), GameObject.Find("g1"),
				GameObject.Find("g2"), GameObject.Find("g3"), GameObject.Find("g4")};
			dice = new GameObject[] {GameObject.Find("dice_1"), GameObject.Find("dice_2"), 
				GameObject.Find("dice_3"),GameObject.Find("dice_4"), GameObject.Find("dice_5"), GameObject.Find("dice_6"),
				GameObject.Find("dice_action_0"),GameObject.Find("dice_action_1"), 
				GameObject.Find("dice_action_2"), GameObject.Find("dice_action_3")};
		}

		void Awake() {
			init_this();
		}
		void Start () {
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		*/
 }

	public class Chess_Position {
		//use to save the position
		public Vector2[,] position = new Vector2[, ]{{new Vector2(0.6f, 5.7f),new Vector2(0f, 3.8f), new Vector2(0f, 3.2f), new Vector2(0f, 2.7f), new Vector2(0f, 2f),
				new Vector2(0.37f, 1.66f), new Vector2(1f, 1.86f), new Vector2(1.57f, 1.88f), new Vector2(2.12f, 1.68f), new Vector2(2.3f, 1f), new Vector2(2.3f, 0.56f),
				new Vector2(2.3f, 0f), new Vector2(2.3f, -0.56f), new Vector2(2.3f, -1f), new Vector2(2.12f, -1.68f), new Vector2(1.57f, -1.88f), new Vector2(1f, -1.86f), 
				new Vector2(0.37f, -1.66f), new Vector2(0f, -2f), new Vector2(0f, -2.7f), new Vector2(0f, -3.2f), /*负号*/new Vector2(0f, -3.8f), new Vector2(-0.6f, -4f), new Vector2(-1.1f, -4f),
				new Vector2(-1.6f, -4f), new Vector2(-2f, -4f), new Vector2(-2.7f, -4f), new Vector2(-3.4f, -3.8f), new Vector2(-3.4f, -3.2f), new Vector2(-3.4f, -2.7f), 
				new Vector2 (-3.3f, -2f), new Vector2 (-3.7f, -1.7f), new Vector2 (-4.3f, -1.9f), new Vector2 (-4.8f, -1.9f), new Vector2 (-5.5f, -1.7f), new Vector2 (-5.6f, -1f),
				new Vector2 (-5.7f, -0.5f), new Vector2 (-5.7f, 0f), new Vector2 (-5.7f, 0.5f), new Vector2 (-5.7f, 1f), new Vector2 (-5.5f, 1.7f), new Vector2 (-4.8f, 1.9f), 
				new Vector2 (-4.3f, 1.9f), new Vector2 (-3.7f, 1.7f), new Vector2 (-3.3f, 2f), new Vector2 (-3.4f, 2.7f), new Vector2 (-3.5f, 3.2f), new Vector2 (-3.4f, 3.85f),
				new Vector2 (-2.7f, 4f), new Vector2 (-2.9f, 4f), new Vector2 (-1.6f, 4f),     new Vector2 (-1.6f, 3.2f), new Vector2 (-1.6f, 2.6f), new Vector2 (-1.6f, 2f), new Vector2 (-1.6f, 1.6f),
				new Vector2 (-1.6f, 1f), new Vector2 (-1.6f, 0.4f), new Vector2 (2.3f, 4.05f), new Vector2 (1.4f, 4f), new Vector2 (1.39f, 3.1f), new Vector2 (2.39f, 3.1f)},
			{new Vector2 (2.5f, -2.2f),  new Vector2(2.12f, -1.68f), new Vector2(1.57f, -1.88f), new Vector2(1f, -1.86f), new Vector2(0.37f, -1.66f), new Vector2(0f, -2f), new Vector2(0f, -2.7f), new Vector2(0f, -3.2f), new Vector2(0f, -3.8f), new Vector2(-0.6f, -4f), new Vector2(-1.1f, -4f),
				new Vector2(-1.6f, -4f), new Vector2(-2f, -4f), new Vector2(-2.7f, -4f), new Vector2(-3.4f, -3.8f), new Vector2(-3.4f, -3.2f), new Vector2(-3.4f, -2.7f), 
				new Vector2 (-3.3f, -2f), new Vector2 (-3.7f, -1.7f), new Vector2 (-4.3f, -1.9f), new Vector2 (-4.8f, -1.9f), new Vector2 (-5.5f, -1.7f), new Vector2 (-5.6f, -1f),
				new Vector2 (-5.7f, -0.5f), new Vector2 (-5.7f, 0f), new Vector2 (-5.7f, 0.5f), new Vector2 (-5.7f, 1f), new Vector2 (-5.5f, 1.7f), new Vector2 (-4.8f, 1.9f), 
				new Vector2 (-4.3f, 1.9f), new Vector2 (-3.7f, 1.7f), new Vector2 (-3.3f, 2f), new Vector2 (-3.4f, 2.7f), new Vector2 (-3.5f, 3.2f), new Vector2 (-3.4f, 3.85f),
				new Vector2 (-2.7f, 4f), new Vector2 (-2.9f, 4f), new Vector2 (-1.6f, 4f), new Vector2 (-1.1f, 4.1f), new Vector2 (-0.6f, 4.1f),new Vector2(0f, 3.8f), new Vector2(0f, 3.2f), new Vector2(0f, 2.7f), new Vector2(0f, 2f),
				new Vector2(0.37f, 1.66f), new Vector2(1f, 1.86f), new Vector2(1.57f, 1.88f), new Vector2(2.12f, 1.68f), new Vector2(2.3f, 1f), new Vector2(2.3f, 0.56f),
				new Vector2(2.3f, 0f), new Vector2 (1.4f, 0f), new Vector2 (0.9f, 0f), new Vector2 (0.42f, 0f), new Vector2 (0f, 0f), new Vector2 (-0.57f, 0f), new Vector2(-1.1f, 0f),
				new Vector2 (2.3f, -3f), new Vector2 (1.4f, -3.0f), new Vector2 (1.4f, -3.9f), new Vector2 (2.4f, -4.0f)}, 
			{new Vector2 (-3.8f, -4.3f), new Vector2(-3.4f, -3.8f), new Vector2(-3.4f, -3.2f), new Vector2(-3.4f, -2.7f), 
				new Vector2 (-3.3f, -2f), new Vector2 (-3.7f, -1.7f), new Vector2 (-4.3f, -1.9f), new Vector2 (-4.8f, -1.9f), new Vector2 (-5.5f, -1.7f), new Vector2 (-5.6f, -1f),
				new Vector2 (-5.7f, -0.5f), new Vector2 (-5.7f, 0f), new Vector2 (-5.7f, 0.5f), new Vector2 (-5.7f, 1f), new Vector2 (-5.5f, 1.7f), new Vector2 (-4.8f, 1.9f), 
				new Vector2 (-4.3f, 1.9f), new Vector2 (-3.7f, 1.7f), new Vector2 (-3.3f, 2f), new Vector2 (-3.4f, 2.7f), new Vector2 (-3.5f, 3.2f), new Vector2 (-3.4f, 3.85f),
				new Vector2 (-2.7f, 4f), new Vector2 (-2.9f, 4f), new Vector2 (-1.6f, 4f),new Vector2 (-1.1f, 4.1f), new Vector2 (-0.6f, 4.1f),/*负号*/new Vector2(0f, -3.8f), new Vector2(0f, 3.2f), new Vector2(0f, 2.7f), new Vector2(0f, 2f),
				new Vector2(0.37f, 1.66f), new Vector2(1f, 1.86f), new Vector2(1.57f, 1.88f), new Vector2(2.12f, 1.68f), new Vector2(2.3f, 1f), new Vector2(2.3f, 0.56f),
				new Vector2(2.3f, 0f), new Vector2(2.3f, -0.56f), new Vector2(2.3f, -1f), new Vector2(2.12f, -1.68f), new Vector2(1.57f, -1.88f), new Vector2(1f, -1.86f), 
				new Vector2(0.37f, -1.66f), new Vector2(0f, -2f), new Vector2(0f, -2.7f), new Vector2(0f, -3.2f), new Vector2(0f, -3.8f), new Vector2(-0.6f, -4f), new Vector2(-1.1f, -4f),
				new Vector2(-1.6f, -4f), new Vector2 (-1.6f, -3.2f), new Vector2 (-1.6f, -2.68f), new Vector2 (-1.6f, -2.0f), new Vector2 (-1.6f, -1.6f), new Vector2 (-1.6f, 1f),
				new Vector2 (-1.6f, -0.4f), new Vector2 (-5.7f, -3.0f), new Vector2 (-4.7f, -3.0f), new Vector2 (-5.7f, -4f), new Vector2 (-4.7f, -4f)}, 
			{new Vector2 (-5.8f, 2.26f), new Vector2 (-5.5f, 1.7f), new Vector2 (-4.8f, 1.9f), 
				new Vector2 (-4.3f, 1.9f), new Vector2 (-3.7f, 1.7f), new Vector2 (-3.3f, 2f), new Vector2 (-3.4f, 2.7f), new Vector2 (-3.5f, 3.2f), new Vector2 (-3.4f, 3.85f),
				new Vector2 (-2.7f, 4f), new Vector2 (-2.9f, 4f), new Vector2 (-1.6f, 4f),new Vector2 (-1.1f, 4.1f), new Vector2 (-0.6f, 4.1f),new Vector2(0f, 3.8f), new Vector2(0f, 3.2f), new Vector2(0f, 2.7f), new Vector2(0f, 2f),
				new Vector2(0.37f, 1.66f), new Vector2(1f, 1.86f), new Vector2(1.57f, 1.88f), new Vector2(2.12f, 1.68f), new Vector2(2.3f, 1f), new Vector2(2.3f, 0.56f),
				new Vector2(2.3f, 0f), new Vector2(2.3f, -0.56f), new Vector2(2.3f, -1f), new Vector2(2.12f, -1.68f), new Vector2(1.57f, -1.88f), new Vector2(1f, -1.86f), 
				new Vector2(0.37f, -1.66f), new Vector2(0f, -2f), new Vector2(0f, -2.7f), new Vector2(0f, -3.2f),/*负号*/new Vector2(0f, -3.8f), new Vector2(-0.6f, -4f), new Vector2(-1.1f, -4f),
				new Vector2(-1.6f, -4f),new Vector2(-1.6f, -4f), new Vector2(-2f, -4f), new Vector2(-2.7f, -4f), new Vector2(-3.4f, -3.8f), new Vector2(-3.4f, -3.2f), new Vector2(-3.4f, -2.7f), 
				new Vector2 (-3.3f, -2f), new Vector2 (-3.7f, -1.7f), new Vector2 (-4.3f, -1.9f), new Vector2 (-4.8f, -1.9f), new Vector2 (-5.5f, -1.7f), new Vector2 (-5.6f, -1f),
				new Vector2 (-5.7f, -0.5f), new Vector2 (-5.7f, 0f), new Vector2 (-4.9f, 0f), new Vector2 (-4.3f, 0f), new Vector2 (-3.7f, 0f), new Vector2 (-3.2f, 0f),
				new Vector2 (-2.7f, 0f), new Vector2 (-2.2f, 0f), new Vector2 (-5.7f, 4.0f), new Vector2 (-4.7f, 4.0f), new Vector2 (-5.7f, 3.1f), new Vector2(-4.7f, 3.1f)}};
	}
}
