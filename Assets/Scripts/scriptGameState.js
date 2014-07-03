#pragma strict

static var score : int = 0;
var style : GUIStyle;


function Start () {

}

function Update () {

}

function plusPoints() {
 score+= 5;
}

function lessPoints() {
score -= 3;
}

function OnGUI() {
	//GUI.contentColor = Color.cyan;
	GUI.color = Color.green;
	//style.fontSize = 50;
	
	GUI.Box(Rect(10,80,10,20),"Score: " + score,style); 
}