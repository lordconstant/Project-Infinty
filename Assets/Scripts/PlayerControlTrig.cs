//copyright ©, Corey Bradford - Whodok Games, 2014
//Version: 1.0
//Date Modified: 12/05/2014

using UnityEngine;
using System.Collections;

public class PlayerControlTrig : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			//change movement here
		}
	}
}
