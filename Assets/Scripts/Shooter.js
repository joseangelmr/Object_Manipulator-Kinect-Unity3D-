var projectile : Rigidbody;
var speed = 20;


function Update()
{

 	 

	//OnTriggerEnter();
/* if( Input.GetButtonDown( "Fire1" ) )
 {
  var instantiatedProjectile : Rigidbody = Instantiate(
   projectile, transform.position, transform.rotation );
  instantiatedProjectile.velocity =
   transform.TransformDirection( Vector3( 0, 0, speed ) );
  Physics.IgnoreCollision( instantiatedProjectile. collider,
   transform.root.collider );
 }*/
 
 /*if(OnTriggerEnter(other : Collider)){
 
 var instantiatedProjectile : Rigidbody = Instantiate(
   projectile, transform.position, transform.rotation );
  instantiatedProjectile.velocity =
   transform.TransformDirection( Vector3( 0, 0, speed ) );
  Physics.IgnoreCollision( instantiatedProjectile. collider,
   transform.root.collider );
 }*/
 
}

function OnTriggerEnter (other : Collider) {
		
		/*if(other.transform.tag == "HandL" || other.transform.tag == "HandR"){
			obj.transform.GetComponent(scriptGameState).lessPoints();
			var reset: Vector3 = Vector3(Random.Range(-10.0, 10.0), Random.Range(-1.5, 25.0), Random.Range(100.0,110.0));
			transform.position = reset;
		}*/
		
		//Disparar
		
   var instantiatedProjectile : Rigidbody = Instantiate(
   projectile, transform.position, transform.rotation );
  instantiatedProjectile.velocity =
   transform.TransformDirection( Vector3( 0, 0, speed ) );
  Physics.IgnoreCollision( instantiatedProjectile. collider,
   transform.root.collider );
}