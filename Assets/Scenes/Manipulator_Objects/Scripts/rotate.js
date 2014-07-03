#pragma strict
var speed= 30;
var actual : float = 99;
var actual2 : float = 99;

function Start () {

}

function Update () {



var axisY : float = GameObject.Find("Cube_manito_test").transform.position.y + 0.15;
var axisXX : float = GameObject.Find("Cube_manito_test").transform.position.x;

var axisX : float = GameObject.Find("Cube_manito_test2").transform.position.x +0.8;
var axisYY : float = GameObject.Find("Cube_manito_test2").transform.position.y - 0.20;

var axisA : float = GameObject.Find("Cube_manito_L").transform.position.y;

//Debug.LogWarning(axisYY);
//Debug.LogWarning("---"+axisA);


	if (axisY > 0.60 && axisY < 0.61)
	{
		if (actual != 0 && axisXX < 0.46)
		{ 
		actual= 0;
		//Debug.LogWarning("-----------sumo 18Grados en 0-----------");
		transform.rotation = Quaternion.Euler(10, 0, 0);
		
		
		
		}
	}
	
	if (axisY > 0.61 && axisY < 0.62)
	{
		if (actual != 1 && axisXX < 0.46)
		{ 
		actual= 1;
		//Debug.LogWarning("-----------sumo 18Grados en 1-----------");
		transform.rotation = Quaternion.Euler(10, 0, 0);
		}
	}
	
	
	if (axisY > 0.62 && axisY < 0.63)
	{
		if (actual != 2 && axisXX < 0.46)
		{ 
		actual= 2;
		//Debug.LogWarning("-----------sumo 18Grados en 2-----------");
		transform.rotation = Quaternion.Euler(20, 0, 0);
		}
	}
	
	if (axisY > 0.63 && axisY < 0.64)
	{
		if (actual != 3 && axisXX < 0.46)
		{ 
		actual= 3;
		//Debug.LogWarning("-----------sumo 18Grados en 3-----------");
		transform.rotation = Quaternion.Euler(30, 0, 0);
		}
	}
	
	if (axisY > 0.64 && axisY < 0.65)
	{
		if (actual != 4 && axisXX < 0.46)
		{ 
		actual= 4;
		//Debug.LogWarning("-----------sumo 18Grados en 4-----------");
		transform.rotation = Quaternion.Euler(40, 0, 0);
		}
	}
	
	if (axisY > 0.65 && axisY < 0.66)
	{
		if (actual != 5 && axisXX < 0.46)
		{ 
		actual= 5;
		//Debug.LogWarning("-----------sumo 18Grados en 5-----------");
		transform.rotation = Quaternion.Euler(50, 0, 0);
		}
	}
	
	if (axisY > 0.66 && axisY < 0.67)
	{
		if (actual != 6 && axisXX < 0.46)
		{ 
		actual= 6;
		//Debug.LogWarning("-----------sumo 18Grados en 6-----------");
		transform.rotation = Quaternion.Euler(60, 0, 0);
		}
	}
	
	if (axisY > 0.67 && axisY < 0.68)
	{
		if (actual != 7 && axisXX < 0.46)
		{ 
		actual= 7;
		//Debug.LogWarning("-----------sumo 18Grados en 7-----------");
		transform.rotation = Quaternion.Euler(70, 0, 0);
		}
	}
	
	if (axisY > 0.68 && axisY < 0.69)
	{
		if (actual != 8 && axisXX < 0.46)
		{ 
		actual= 8;
		//Debug.LogWarning("-----------sumo 18Grados en 8-----------");
		transform.rotation = Quaternion.Euler(80, 0, 0);
		}
	}
	
	if (axisY > 0.69 && axisY < 0.70)
	{
		if (actual != 9 && axisXX < 0.46)
		{ 
		actual= 9;
		//Debug.LogWarning("-----------sumo 18Grados en 9-----------");
		transform.rotation = Quaternion.Euler(90, 0, 0);
		}
	}
	
	
	//----------------------------------------------------------------------
	
	
	if (axisX > 0.55 && axisX < 0.56)
	{
		if (actual2 != 0 && axisYY > 0.67)
		{ 
		actual2= 0;
		//Debug.LogWarning("-----------sumo 18Grados en 0-----------");
		transform.rotation = Quaternion.Euler(0, -10, 0);
		}
	}
	
	if (axisX > 0.56 && axisX < 0.57)
	{
		if (actual2 != 1 && axisYY > 0.67)
		{ 
		actual2= 1;
		//Debug.LogWarning("-----------sumo 18Grados en 0-----------");
		transform.rotation = Quaternion.Euler(0, -20, 0);
		}
	}
	
	if (axisX > 0.57 && axisX < 0.58)
	{
		if (actual2 != 2 && axisYY > 0.67)
		{ 
		actual2= 2;
		//Debug.LogWarning("-----------sumo 18Grados en 0-----------");
		transform.rotation = Quaternion.Euler(0, -30, 0);
		}
	}
	
	if (axisX > 0.58 && axisX < 0.59)
	{
		if (actual2 != 3 && axisYY > 0.67)
		{ 
		actual2= 3;
		//Debug.LogWarning("-----------sumo 18Grados en 0-----------");
		transform.rotation = Quaternion.Euler(0, -40, 0);
		}
	}
	
	if (axisX > 0.59 && axisX < 0.60)
	{
		if (actual2 != 4  && axisYY > 0.67)
		{ 
		actual2= 4;
		//Debug.LogWarning("-----------sumo 18Grados en 0-----------");
		transform.rotation = Quaternion.Euler(0, -50, 0);
		}
	}
	
	if (axisX > 0.60 && axisX < 0.61)
	{
		if (actual2 != 5 && axisYY > 0.67)
		{ 
		actual2= 5;
		//Debug.LogWarning("-----------sumo 18Grados en 0-----------");
		transform.rotation = Quaternion.Euler(0, -60, 0);
		}
	}
	
	if (axisX > 0.61 && axisX < 0.62)
	{
		if (actual2 != 6  && axisYY > 0.67)
		{ 
		actual2= 6;
		//Debug.LogWarning("-----------sumo 18Grados en 0-----------");
		transform.rotation = Quaternion.Euler(0, -70, 0);
		}
	}
	
	if (axisX > 0.62 && axisX < 0.63)
	{
		if (actual2 != 7 && axisYY > 0.67)
		{ 
		actual2= 7;
		//Debug.LogWarning("-----------sumo 18Grados en 0-----------");
		transform.rotation = Quaternion.Euler(0, -80, 0);
		}
	}
	
	if (axisX > 0.63 && axisX < 0.64)
	{
		if (actual2 != 8 && axisYY > 0.67)
		{ 
		actual2= 8;
		//Debug.LogWarning("-----------sumo 18Grados en 0-----------");
		transform.rotation = Quaternion.Euler(0, -90, 0);
		}
	}
	
	if (axisX > 0.64 && axisX < 0.65)
	{
		if (actual2 != 9 && axisYY > 0.67)
		{ 
		actual2= 9;
		//Debug.LogWarning("-----------sumo 18Grados en 0-----------");
		transform.rotation = Quaternion.Euler(0, -90, 0);
		}
	}
	
	
	
}
