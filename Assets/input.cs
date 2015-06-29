using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class input : MonoBehaviour {
	public int controllerNumber = 0;
	public bool up;
	public bool down;
	public bool left;
	public bool right;
	public bool btnA;
	public bool btnB;
	public bool btnX;
	public bool btnY;
	public bool select;
	public bool start;
	public bool l1;
	public bool l2;
	public bool r1;
	public bool r2;
	public bool l3;
	public bool r3;
	public float lt;
	public float rt;
	public float axisLX;
	public float axisLY;
	public float axisRX;
	public float axisRY;
	private string platform;
	private int fingerCount;
	private bool debugActive = false;
	public Text txtField;
	
	void Start () {txtField = GetComponent<Text>();}
	 
	void Awake() {
	  #if UNITY_EDITOR
		platform = "debug";
	  #endif  
	  #if UNITY_IPHONE && !UNITY_EDITOR
	    platform = "iOS"; 
	  #endif
	  #if UNITY_ANDROID && !UNITY_EDITOR
	    platform = "Android"; 
	  #endif
	  #if UNITY_STANDALONE_OSX && !UNITY_EDITOR
	    platform = "OSX";
	  #endif
	  #if UNITY_STANDALONE_WIN && !UNITY_EDITOR
	    platform = "Win";
	  #endif    
	  #if UNITY_STANDALONE_LINUX && !UNITY_EDITOR
	    platform = "Linux";
	  #endif 
	  #if UNITY_WSA && !UNITY_EDITOR
	   platform = "WinM";
	  #endif 
	}
	
	void FixedUpdate () {checkInput();}
	
	public void switchDebug(){debugActive = !debugActive;}
	
	void customize(){}
	
	void checkInput(){
		//Debug.Log(platform);
		int i = controllerNumber;
		string s1 = Input.GetJoystickNames()[i];
		s1 = s1.ToUpper();
			if (debugActive){
				txtField.text = (Input.GetJoystickNames()[i]+"\n"+
					"btn0: "+Input.GetButton("btn"+i+"_0")+"\n"+
					"btn1: "+Input.GetButton("btn"+i+"_1")+"\n"+
					"btn2: "+Input.GetButton("btn"+i+"_2")+"\n"+
					"btn3: "+Input.GetButton("btn"+i+"_3")+"\n"+
					"btn4: "+Input.GetButton("btn"+i+"_4")+"\n"+
					"btn5: "+Input.GetButton("btn"+i+"_5")+"\n"+
					"btn6: "+Input.GetButton("btn"+i+"_6")+"\n"+
					"btn7: "+Input.GetButton("btn"+i+"_7")+"\n"+
					"btn8: "+Input.GetButton("btn"+i+"_8")+"\n"+
					"btn9: "+Input.GetButton("btn"+i+"_9")+"\n"+
					"btn10: "+Input.GetButton("btn"+i+"_10")+"\n"+
					"btn11: "+Input.GetButton("btn"+i+"_11")+"\n"+
					"btn12: "+Input.GetButton("btn"+i+"_12")+"\n"+
					"btn13: "+Input.GetButton("btn"+i+"_13")+"\n"+
					"btn14: "+Input.GetButton("btn"+i+"_14")+"\n"+
					"btn15: "+Input.GetButton("btn"+i+"_15")+"\n"+
					"btn16: "+Input.GetButton("btn"+i+"_16")+"\n"+
					"AxisX: "+Input.GetAxis("Axis"+i+"_X")+"\n"+
					"AxisY: "+Input.GetAxis("Axis"+i+"_Y")+"\n"+
					"Axis3: "+Input.GetAxis("Axis"+i+"_3")+"\n"+
					"Axis4: "+Input.GetAxis("Axis"+i+"_4")+"\n"+
					"Axis5: "+Input.GetAxis("Axis"+i+"_5")+"\n"+
					"Axis6: "+Input.GetAxis("Axis"+i+"_6")+"\n"+
					"Axis7: "+Input.GetAxis("Axis"+i+"_7")+"\n"+
					"Axis8: "+Input.GetAxis("Axis"+i+"_8")+"\n"+
					"Axis9: "+Input.GetAxis("Axis"+i+"_9")+"\n"+
					"Axis10: "+Input.GetAxis("Axis"+i+"_10")+"\n"+
					"Axis11: "+Input.GetAxis("Axis"+i+"_11")+"\n"+
					"Axis12: "+Input.GetAxis("Axis"+i+"_12")+"\n"+
					"Axis13: "+Input.GetAxis("Axis"+i+"_13")+"\n"+
					"Axis14: "+Input.GetAxis("Axis"+i+"_14")+"\n"+
					"Axis15: "+Input.GetAxis("Axis"+i+"_15")+"\n"+
					"Axis16: "+Input.GetAxis("Axis"+i+"_16")+"\n"+
					"Axis17: "+Input.GetAxis("Axis"+i+"_17")+"\n"+
					"Axis18: "+Input.GetAxis("Axis"+i+"_18")+"\n"+
					"Axis19: "+Input.GetAxis("Axis"+i+"_19")+"\n"+
					"Axis20: "+Input.GetAxis("Axis"+i+"_20")
					);	
			}else{
			switch (platform){
				case "debug":
					txtField.text = (Input.GetJoystickNames()[i]+"\n"+
					"Up: "+up+"\n"+
					"Down: "+down+"\n"+
					"Left: "+left+"\n"+
					"Right: "+right+"\n"+
					"Select: "+select+"\n"+
					"Start: "+start+"\n"+
					"A: "+btnA+"\n"+
					"B: "+btnB+"\n"+
					"X: "+btnX+"\n"+
					"Y: "+btnY+"\n"+
					"L1: "+l1+"\n"+
					"L2: "+l2+"\n"+
					"R1: "+r1+"\n"+
					"R2: "+r2+"\n"+
					"L3: "+l3+"\n"+
					"R3: "+r3+"\n"+
					"LT: "+lt+"\n"+
					"RT: "+rt+"\n"+
					"AxisLX: "+axisLX+"\n"+
					"AxisLY: "+axisLY+"\n"+
					"AxisRX: "+axisRX+"\n"+
					"AxisRY: "+axisRY+"\n");
				break;
				case "iOS":
					if (s1.Contains("EXTENDED")){
						up = Input.GetButton("btn"+i+"_4");
						down = Input.GetButton("btn"+i+"_6");
						left = Input.GetButton("btn"+i+"_7");
						right = Input.GetButton("btn"+i+"_5");
						btnA = Input.GetButton("btn"+i+"_14");
						btnB = Input.GetButton("btn"+i+"_13");
						btnX = Input.GetButton("btn"+i+"_15");
						btnY = Input.GetButton("btn"+i+"_12");
						start = Input.GetButton("btn"+i+"_0");
						l1 = Input.GetButton("btn"+i+"_8");
						l2 = Input.GetButton("btn"+i+"_10");
						r1 = Input.GetButton("btn"+i+"_9");
						r2 = Input.GetButton("btn"+i+"_11");
						lt = Input.GetAxis("Axis"+i+"_11");
						rt = Input.GetAxis("Axis"+i+"_12");
						axisLX = Input.GetAxis("Axis"+i+"_X");
						axisLY = Input.GetAxis("Axis"+i+"_Y");
						axisRX = Input.GetAxis("Axis"+i+"_3");
						axisRY = Input.GetAxis("Axis"+i+"_4");
						txtField.text = (Input.GetJoystickNames()[i]+"\n"+
							"Up: "+up+"\n"+
							"Down: "+down+"\n"+
							"Left: "+left+"\n"+
							"Right: "+right+"\n"+
							"Start: "+start+"\n"+
							"A: "+btnA+"\n"+
							"B: "+btnB+"\n"+
							"X: "+btnX+"\n"+
							"Y: "+btnY+"\n"+
							"L1: "+l1+"\n"+
							"L2: "+l2+"\n"+
							"R1: "+r1+"\n"+
							"R2: "+r2+"\n"+
							"LT: "+lt+"\n"+
							"RT: "+rt+"\n"+
							"AxisLX: "+axisLX+"\n"+
							"AxisLY: "+axisLY+"\n"+
							"AxisRX: "+axisRX+"\n"+
							"AxisRY: "+axisRY+"\n");
					} else { //standard profile
						up = Input.GetButton("btn"+i+"_4");
						down = Input.GetButton("btn"+i+"_6");
						left = Input.GetButton("btn"+i+"_7");
						right = Input.GetButton("btn"+i+"_5");
						btnA = Input.GetButton("btn"+i+"_14");
						btnB = Input.GetButton("btn"+i+"_13");
						btnX = Input.GetButton("btn"+i+"_15");
						btnY = Input.GetButton("btn"+i+"_12");
						start = Input.GetButton("btn"+i+"_0");
						l1 = (Input.GetButton("btn"+i+"_8") || Input.GetButton("btn"+i+"_10")) ? true : false;
						r1 = (Input.GetButton("btn"+i+"_9") || Input.GetButton("btn"+i+"_11")) ? true : false;
						txtField.text = (Input.GetJoystickNames()[i]+"\n"+
							"Up: "+up+"\n"+
							"Down: "+down+"\n"+
							"Left: "+left+"\n"+
							"Right: "+right+"\n"+
							"Start: "+start+"\n"+
							"A: "+btnA+"\n"+
							"B: "+btnB+"\n"+
							"X: "+btnX+"\n"+
							"Y: "+btnY+"\n"+
							"L: "+l1+"\n"+
							"R: "+r1+"\n");
					}	
				break;	
				case "OSX":
					up = Input.GetButton("btn"+i+"_4");
					down = Input.GetButton("btn"+i+"_6");
					left = Input.GetButton("btn"+i+"_7");
					right = Input.GetButton("btn"+i+"_5");
					btnA = Input.GetButton("btn"+i+"_14");
					btnB = Input.GetButton("btn"+i+"_13");
					btnX = Input.GetButton("btn"+i+"_15");
					btnY = Input.GetButton("btn"+i+"_12");
					select = Input.GetButton("btn"+i+"_0");
					start = Input.GetButton("btn"+i+"_3");
					l1 = Input.GetButton("btn"+i+"_10");
					l2 = Input.GetButton("btn"+i+"_8");
					r1 = Input.GetButton("btn"+i+"_11");
					r2 = Input.GetButton("btn"+i+"_9");
					lt = (Input.GetButton("btn"+i+"_8")) ? 1 : 0;
					rt = (Input.GetButton("btn"+i+"_9")) ? 1 : 0;
					axisLX = Input.GetAxis("Axis"+i+"_X");
					axisLY = Input.GetAxis("Axis"+i+"_Y");
					axisRX = Input.GetAxis("Axis"+i+"_3");
					axisRY = Input.GetAxis("Axis"+i+"_4");	
					l3 = Input.GetButton("btn"+i+"_1");
					r3 = Input.GetButton("btn"+i+"_2");	
					txtField.text = (Input.GetJoystickNames()[i]+"\n"+
					"Up: "+up+"\n"+
					"Down: "+down+"\n"+
					"Left: "+left+"\n"+
					"Right: "+right+"\n"+
					"Select: "+select+"\n"+
					"Start: "+start+"\n"+
					"A: "+btnA+"\n"+
					"B: "+btnB+"\n"+
					"X: "+btnX+"\n"+
					"Y: "+btnY+"\n"+
					"L1: "+l1+"\n"+
					"L2: "+l2+"\n"+
					"R1: "+r1+"\n"+
					"R2: "+r2+"\n"+
					"L3: "+l3+"\n"+
					"R3: "+r3+"\n"+
					"LT: "+lt+"\n"+
					"RT: "+rt+"\n"+
					"AxisLX: "+axisLX+"\n"+
					"AxisLY: "+axisLY+"\n"+
					"AxisRX: "+axisRX+"\n"+
					"AxisRY: "+axisRY+"\n");
				break;	
				case "Android":
					fingerCount = 0;
					 foreach(Touch touch  in Input.touches) {
						if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
						fingerCount++;
					}
					up = Input.GetAxis("Axis"+i+"_6") < -0.5;
					down = Input.GetAxis("Axis"+i+"_6") > 0.5;
					left = Input.GetAxis("Axis"+i+"_5") < -0.5;
					right = Input.GetAxis("Axis"+i+"_5") > 0.5;
					btnA = Input.GetButton("btn"+i+"_0");
					btnB = Input.GetButton("btn"+i+"_1");
					btnX = Input.GetButton("btn"+i+"_2");
					btnY = Input.GetButton("btn"+i+"_3");
					//select = Input.GetButton("btn10");
					start = Input.GetButton("btn"+i+"_10") || (Input.GetMouseButton(0) && fingerCount == 0);
					l1 = Input.GetButton("btn"+i+"_4");
					l2 = Input.GetAxis("Axis"+i+"_7") > 0.2 || Input.GetAxis("Axis"+i+"_13") > 0.2; //Axis 7 - Xbox 360 - Axis 13 - Moga
					r1 = Input.GetButton("btn"+i+"_5");
					r2 = Input.GetAxis("Axis"+i+"_8") > 0.2 || Input.GetAxis("Axis"+i+"_12") > 0.2; //Axis 8 - Xbox 360 - Axis 12 - Moga
					lt = Input.GetAxis("Axis"+i+"_13");
					rt = Input.GetAxis("Axis"+i+"_12");
					if (Input.GetAxis("Axis"+i+"_8") > 0.05) rt = Input.GetAxis("Axis"+i+"_8");
					if (Input.GetAxis("Axis"+i+"_7") > 0.05) lt = Input.GetAxis("Axis"+i+"_7");
					axisLX = Input.GetAxis("Axis"+i+"_X");
					axisLY = Input.GetAxis("Axis"+i+"_Y");
					axisRX = Input.GetAxis("Axis"+i+"_3");
					axisRY = Input.GetAxis("Axis"+i+"_4");
					l3 = Input.GetButton("btn"+i+"_8");
					r3 = Input.GetButton("btn"+i+"_9");
					txtField.text = (Input.GetJoystickNames()[i]+"\n"+
					"Up: "+up+"\n"+
					"Down: "+down+"\n"+
					"Left: "+left+"\n"+
					"Right: "+right+"\n"+
					"Select: "+select+"\n"+
					"Start: "+start+"\n"+
					"A: "+btnA+"\n"+
					"B: "+btnB+"\n"+
					"X: "+btnX+"\n"+
					"Y: "+btnY+"\n"+
					"L1: "+l1+"\n"+
					"L2: "+l2+"\n"+
					"R1: "+r1+"\n"+
					"R2: "+r2+"\n"+
					"L3: "+l3+"\n"+
					"R3: "+r3+"\n"+
					"LT: "+lt+"\n"+
					"RT: "+rt+"\n"+
					"AxisLX: "+axisLX+"\n"+
					"AxisLY: "+axisLY+"\n"+
					"AxisRX: "+axisRX+"\n"+
					"AxisRY: "+axisRY+"\n");
				break;	
				case "WinM":
				case "Win":
					
					if (s1.Contains("PLAYSTATION(R)3")){
						up = Input.GetButton("btn"+i+"_4");
						down = Input.GetButton("btn"+i+"_6");
						left = Input.GetButton("btn"+i+"_7");
						right = Input.GetButton("btn"+i+"_5");
						btnA = Input.GetButton("btn"+i+"_14");
						btnB = Input.GetButton("btn"+i+"_13");
						btnX = Input.GetButton("btn"+i+"_15");
						btnY = Input.GetButton("btn"+i+"_12");
						select = Input.GetButton("btn"+i+"_0");
						start = Input.GetButton("btn"+i+"_3");
						l1 = Input.GetButton("btn"+i+"_10");
						l2 = Input.GetButton("btn"+i+"_8");
						r1 = Input.GetButton("btn"+i+"_11");
						r2 = Input.GetButton("btn"+i+"_9");
						lt = (l2) ? 1 : 0;
						rt = (r2) ? 1 : 0;
						axisLX = Input.GetAxis("Axis"+i+"_X");
						axisLY = Input.GetAxis("Axis"+i+"_Y");
						axisRX = Input.GetAxis("Axis"+i+"_3");
						axisRY = Input.GetAxis("Axis"+i+"_4");
						l3 = Input.GetButton("btn"+i+"_1");
						r3 = Input.GetButton("btn"+i+"_2");
					}else if (s1.Contains("BOX 360")){
						up = Input.GetAxis("Axis"+i+"_7") > 0.5;
						down = Input.GetAxis("Axis"+i+"_7") < -0.5;
						left = Input.GetAxis("Axis"+i+"_6") < -0.5;
						right = Input.GetAxis("Axis"+i+"_6") > 0.5;
						btnA = Input.GetButton("btn"+i+"_0");
						btnB = Input.GetButton("btn"+i+"_1");
						btnX = Input.GetButton("btn"+i+"_2");
						btnY = Input.GetButton("btn"+i+"_3");
						select = Input.GetButton("btn"+i+"_6");
						start = Input.GetButton("btn"+i+"_7");
						l1 = Input.GetButton("btn"+i+"_4");
						l2 = Input.GetAxis("Axis"+i+"_9") > 0.2;
						r1 = Input.GetButton("btn"+i+"_5");
						r2 = Input.GetAxis("Axis"+i+"_10") > 0.2;	
						lt = Input.GetAxis("Axis"+i+"_9");
						rt = Input.GetAxis("Axis"+i+"_10");
						if (l2 == false && Input.GetAxis("Axis"+i+"_3") > 0.2){
							l2 = true;
							lt = Input.GetAxis("Axis"+i+"_3");
						}
						if (r2 == false && Input.GetAxis("Axis"+i+"_3") < -0.2){
							r2 = true;
							rt = Mathf.Abs(Input.GetAxis("Axis"+i+"_3"));
						}	
						axisLX = Input.GetAxis("Axis"+i+"_X");
						axisLY = Input.GetAxis("Axis"+i+"_Y");
						axisRX = Input.GetAxis("Axis"+i+"_4");
						axisRY = Input.GetAxis("Axis"+i+"_5");
						l3 = Input.GetButton("btn"+i+"_8");
						r3 = Input.GetButton("btn"+i+"_9");
					}else if (s1.Contains("BOX ONE")){
						up = Input.GetAxis("Axis"+i+"_8") > 0.5;
						down = Input.GetAxis("Axis"+i+"_8") < -0.5;
						left = Input.GetAxis("Axis"+i+"_7") < -0.5;
						right = Input.GetAxis("Axis"+i+"_7") > 0.5;
						btnA = Input.GetButton("btn"+i+"_0");
						btnB = Input.GetButton("btn"+i+"_1");
						btnX = Input.GetButton("btn"+i+"_2");
						btnY = Input.GetButton("btn"+i+"_3");
						select = Input.GetButton("btn"+i+"_6");
						start = Input.GetButton("btn"+i+"_7");
						l1 = Input.GetButton("btn"+i+"_4");
						l2 = Input.GetAxis("Axis"+i+"_9") > 0.2;
						r1 = Input.GetButton("btn"+i+"_5");
						r2 = Input.GetAxis("Axis"+i+"_10") > 0.2;	
						lt = Input.GetAxis("Axis"+i+"_9");
						rt = Input.GetAxis("Axis"+i+"_10");
						if (l2 == false && Input.GetAxis("Axis"+i+"_3") > 0.2){
							l2 = true;
							lt = Input.GetAxis("Axis"+i+"_3");
						}
						if (r2 == false && Input.GetAxis("Axis"+i+"_3") < -0.2){
							r2 = true;
							rt = Mathf.Abs(Input.GetAxis("Axis"+i+"_3"));
						}	
						axisLX = Input.GetAxis("Axis"+i+"_X");
						axisLY = Input.GetAxis("Axis"+i+"_Y");
						axisRX = Input.GetAxis("Axis"+i+"_4");
						axisRY = Input.GetAxis("Axis"+i+"_5");
						l3 = Input.GetButton("btn"+i+"_8");
						r3 = Input.GetButton("btn"+i+"_9");
					}
					txtField.text = (Input.GetJoystickNames()[i]+"\n"+
					"Up: "+up+"\n"+
					"Down: "+down+"\n"+
					"Left: "+left+"\n"+
					"Right: "+right+"\n"+
					"Select: "+select+"\n"+
					"Start: "+start+"\n"+
					"A: "+btnA+"\n"+
					"B: "+btnB+"\n"+
					"X: "+btnX+"\n"+
					"Y: "+btnY+"\n"+
					"L1: "+l1+"\n"+
					"L2: "+l2+"\n"+
					"R1: "+r1+"\n"+
					"R2: "+r2+"\n"+
					"L3: "+l3+"\n"+
					"R3: "+r3+"\n"+
					"LT: "+lt+"\n"+
					"RT: "+rt+"\n"+
					"AxisLX: "+axisLX+"\n"+
					"AxisLY: "+axisLY+"\n"+
					"AxisRX: "+axisRX+"\n"+
					"AxisRY: "+axisRY+"\n");
				break;
				case "Linux":
					up = Input.GetAxis("Axis"+i+"_8") < -0.5;
					down = Input.GetAxis("Axis"+i+"_8") > 0.5;
					left = Input.GetAxis("Axis"+i+"_7") < -0.5;
					right = Input.GetAxis("Axis"+i+"_7") > 0.5;
					btnA = Input.GetButton("btn"+i+"_0");
					btnB = Input.GetButton("btn"+i+"_1");
					btnX = Input.GetButton("btn"+i+"_2");
					btnY = Input.GetButton("btn"+i+"_3");
					select = Input.GetButton("btn"+i+"_6");
					start = Input.GetButton("btn"+i+"_7");
					l1 = Input.GetButton("btn"+i+"_4");
					l2 = Input.GetAxis("Axis"+i+"_3") > 0.2;
					r1 = Input.GetButton("btn"+i+"_5");
					r2 = Input.GetAxis("Axis"+i+"_6") > 0.2;
					lt = Input.GetAxis("Axis"+i+"_3");
					rt = Input.GetAxis("Axis"+i+"_6");
					axisLX = Input.GetAxis("Axis"+i+"_X");
					axisLY = Input.GetAxis("Axis"+i+"_Y");
					axisRX = Input.GetAxis("Axis"+i+"_4");
					axisRY = Input.GetAxis("Axis"+i+"_5");
					l3 = Input.GetButton("btn"+i+"_9");
					r3 = Input.GetButton("btn"+i+"_10");
					txtField.text = (Input.GetJoystickNames()[i]+"\n"+
					"Up: "+up+"\n"+
					"Down: "+down+"\n"+
					"Left: "+left+"\n"+
					"Right: "+right+"\n"+
					"Select: "+select+"\n"+
					"Start: "+start+"\n"+
					"A: "+btnA+"\n"+
					"B: "+btnB+"\n"+
					"X: "+btnX+"\n"+
					"Y: "+btnY+"\n"+
					"L1: "+l1+"\n"+
					"L2: "+l2+"\n"+
					"R1: "+r1+"\n"+
					"R2: "+r2+"\n"+
					"L3: "+l3+"\n"+
					"R3: "+r3+"\n"+
					"LT: "+lt+"\n"+
					"RT: "+rt+"\n"+
					"AxisLX: "+axisLX+"\n"+
					"AxisLY: "+axisLY+"\n"+
					"AxisRX: "+axisRX+"\n"+
					"AxisRY: "+axisRY+"\n");
				break;
			}
		}
	}
}
