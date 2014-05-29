//copyright ©, Corey Bradford - Whodok Games, 2014
//Version: 1.0
//Date Modified: 21/05/2014

/* 
 * Version 1.0 ----------
 * + Initial code
 * 
 */

using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	public float splashLength = 4.0f;
	public string levelName = "Game";
	
	// Use this for initialization
	void Start () {
		StartCoroutine(Change());
	}

	IEnumerator Change(){
		yield return new WaitForSeconds(splashLength);
		Application.LoadLevel(levelName);
	}

}
