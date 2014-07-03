using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class prueba : MonoBehaviour {
	
	public FsmString str;

	// Use this for initialization
	void Start () {
		
		str= FsmVariables.GlobalVariables.GetFsmString("string_voz");
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//str.Value="ss";
	
	}
	
	
	
}
