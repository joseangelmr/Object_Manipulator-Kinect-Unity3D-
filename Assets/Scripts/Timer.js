#pragma strict

var timer : float = 60.0;
var style : GUIStyle;



function Update(){
	timer -= Time.deltaTime;
	
	if(timer <= 0){
		timer = 0;
		Application.LoadLevel("GameOver");
	}
}

function OnGUI(){
	GUI.color = Color.white;
	//style.fontSize = 10;
	GUI.Box(new Rect(10, 10, 100,200), "Time: " + timer.ToString("0"), style);
	}