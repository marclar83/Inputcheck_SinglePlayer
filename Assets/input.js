#pragma strict

var controllerNumber = 0;
var up = false;
var down = false;
var left = false;
var right = false;
var btnA = false;
var btnB = false;
var btnX = false;
var btnY = false;
var select = false;
var start = false;
var l1 = false;
var l2 = false;
var r1 = false;
var r2 = false;
var l3 = false;
var r3 = false;
var lt = 0.0;
var rt = 0.0;
var axisLX = 0.0;
var axisLY = 0.0;
var axisRX = 0.0;
var axisRY = 0.0;
var platform = "";

function Awake() {
  #if UNITY_IPHONE
    platform = "iOS"; 
  #endif
  #if UNITY_ANDROID
    platform = "Android"; 
  #endif
  #if UNITY_STANDALONE_OSX
    platform = "OSX";
  #endif
  #if UNITY_STANDALONE_WIN
    platform = "Win";
  #endif    
  #if UNITY_STANDALONE_LINUX
    platform = "Linux";
  #endif 
  #if UNITY_WSA
   platform = "WinM";
  #endif 
}

function FixedUpdate () {
	var i = controllerNumber;
	var j = (controllerNumber-1 < 0) ? 0 : controllerNumber-1;
	var s1 = Input.GetJoystickNames()[j];
	s1 = s1.ToUpper();
		switch (platform){
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
				}	
			break;	
			case "OSX":
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
					lt = (Input.GetButton("btn"+i+"_8")) ? 1 : 0;
					rt = (Input.GetButton("btn"+i+"_9")) ? 1 : 0;
					axisLX = Input.GetAxis("Axis"+i+"_X");
					axisLY = Input.GetAxis("Axis"+i+"_Y");
					axisRX = Input.GetAxis("Axis"+i+"_3");
					axisRY = Input.GetAxis("Axis"+i+"_4");	
					l3 = Input.GetButton("btn"+i+"_1");
					r3 = Input.GetButton("btn"+i+"_2");	
				}else if (s1.Contains("WIRELESS")){ //PS4
					up = Input.GetAxis("Axis"+i+"_8") < -0.5;
					down = Input.GetAxis("Axis"+i+"_8") > 0.5;
					left = Input.GetAxis("Axis"+i+"_7") < -0.5;
					right = Input.GetAxis("Axis"+i+"_7") > 0.5;
					btnA = Input.GetButton("btn"+i+"_1");
					btnB = Input.GetButton("btn"+i+"_2");
					btnX = Input.GetButton("btn"+i+"_0");
					btnY = Input.GetButton("btn"+i+"_3");
					select = Input.GetButton("btn"+i+"_8");
					start = Input.GetButton("btn"+i+"_9");
					l1 = Input.GetButton("btn"+i+"_4");
					l2 = Input.GetButton("btn"+i+"_6");
					r1 = Input.GetButton("btn"+i+"_5");
					r2 = Input.GetButton("btn"+i+"_7");
					lt = ((Input.GetAxis("Axis"+i+"_5")+1)/2); // between -1 and 1 so +1 = 0 to 2 and /2 = 0 to 1 !
					rt = ((Input.GetAxis("Axis"+i+"_6")+1)/2); // between -1 and 1 so +1 = 0 to 2 and /2 = 0 to 1 !
					axisLX = Input.GetAxis("Axis"+i+"_X");
					axisLY = Input.GetAxis("Axis"+i+"_Y");
					axisRX = Input.GetAxis("Axis"+i+"_3");
					axisRY = Input.GetAxis("Axis"+i+"_4");	
					l3 = Input.GetButton("btn"+i+"_10");
					r3 = Input.GetButton("btn"+i+"_11");	
				}else{  // requiert : 360Controller driver: https://github.com/d235j/360Controller
					up = Input.GetButton("btn"+i+"_5");
					down = Input.GetButton("btn"+i+"_6");
					left = Input.GetButton("btn"+i+"_7");
					right = Input.GetButton("btn"+i+"_8");
					btnA = Input.GetButton("btn"+i+"_16");
					btnB = Input.GetButton("btn"+i+"_17");
					btnX = Input.GetButton("btn"+i+"_18");
					btnY = Input.GetButton("btn"+i+"_19");
					select = Input.GetButton("btn"+i+"_10");
					start = Input.GetButton("btn"+i+"_9");
					l1 = Input.GetButton("btn"+i+"_13");
					l2 = Input.GetAxis("Axis"+i+"_5") > 0.2;
					r1 = Input.GetButton("btn"+i+"_14");
					r2 = Input.GetAxis("Axis"+i+"_6") > 0.2;
					lt = (Input.GetAxis("Axis"+i+"_5") > 0) ? Input.GetAxis("Axis"+i+"_5") : 0;
					rt = (Input.GetAxis("Axis"+i+"_6") > 0) ? Input.GetAxis("Axis"+i+"_6") : 0;
					axisLX = Input.GetAxis("Axis"+i+"_X");
					axisLY = Input.GetAxis("Axis"+i+"_Y");
					axisRX = Input.GetAxis("Axis"+i+"_3");
					axisRY = Input.GetAxis("Axis"+i+"_4");	
					l3 = Input.GetButton("btn"+i+"_11");
					r3 = Input.GetButton("btn"+i+"_12");	
				}
			break;	
			case "Android":
				up = Input.GetAxis("Axis"+i+"_6") < -0.5;
				down = Input.GetAxis("Axis"+i+"_6") > 0.5;
				left = Input.GetAxis("Axis"+i+"_5") < -0.5;
				right = Input.GetAxis("Axis"+i+"_5") > 0.5;
				btnA = Input.GetButton("btn"+i+"_0");
				btnB = Input.GetButton("btn"+i+"_1");
				btnX = Input.GetButton("btn"+i+"_2");
				btnY = Input.GetButton("btn"+i+"_3");
				start = Input.GetButton("btn"+i+"_10"); //|| (Input.GetMouseButton(0) && fingerCount == 0);
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
			break;
		}
	}
