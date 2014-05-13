//copyright ©, Corey Bradford - Whodok Games, 2014
//Version: 1.0
//Date Modified: 09/05/2014

using UnityEngine;
using System.Collections;

public class LevelGenTrig : MonoBehaviour {
	public LevelGen.ERA spawnLevelEra;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			GameObject.FindGameObjectWithTag("levelGen").GetComponent<LevelGen>().SpawnLevel(spawnLevelEra);
		}
	}
}
