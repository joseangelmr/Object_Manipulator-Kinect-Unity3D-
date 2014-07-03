#pragma strict

var vel : float = 30;
var obj : GameObject;

function Start () {

}

function Update () {

	transform.Translate(Vector3.back * vel * Time.deltaTime);

	if(transform.position.z < 20) {
		var reset: Vector3 = Vector3(Random.Range(-10.0, 10.0), Random.Range(-1.5, 25.0), Random.Range(100.0,110.0));
		transform.position = reset;
	}

}

function OnTriggerEnter (other : Collider) {
		
		//if(other.transform.tag == "HandL" || other.transform.tag == "HandR"){
		if(other.transform.tag == "ArmL" || other.transform.tag == "ArmR"){
			obj.transform.GetComponent(scriptGameState).plusPoints();
			var reset: Vector3 = Vector3(Random.Range(-10.0, 10.0), Random.Range(-1.5, 25.0), Random.Range(100.0,110.0));
			transform.position = reset;
		}
}