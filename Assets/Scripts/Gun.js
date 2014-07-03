//#pragma strict

var Bullet : Rigidbody;
var Spawn : Transform;
var BulletSpeed : float = 1000;
//var bullet1 : Rigidbody = Instantiate(Bullet, Spawn.posicition, Spawn.rotation);
//var bullet1 : Rigidbody;

function Start () {

}

function Update () {
	if(Input.GetButtonDown("Fire1")){
		Fire();
	}
}

function Fire(){
	//bullet1 = (GameObject)(Bullet, Spawn.position, Spawn.rotation);
	var bullet1 : Rigidbody = Instantiate(Bullet,Spawn.position,Spawn.rotation);
	// bullet1.AddForce(transform.forward * BulletSpeed); 
	bullet1.AddForce(transform.forward * BulletSpeed);
}