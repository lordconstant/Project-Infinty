//copyright ©, Corey Bradford - Whodok Games, 2014
//Version: 1.1
//Date Modified: 12/05/2014

/*
 * Version 1.1 ----------
 * + can set whether to enable or disable auto move
 * 
 * Version 1.0 ----------
 * - Initial code
 * 
 */

using UnityEngine;
using System.Collections;

public class PlayerControlTrig : MonoBehaviour {
	public bool autoMove;

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			other.transform.parent.GetComponent<CameraController>().moving = autoMove;
		}
	}
}
