//copyright ©, Corey Bradford - Whodok Games, 2014
//Version: 1.1
//Date Modified: 09/05/2014

/*
 * Version 1.1 ----------
 * + can only be triggered once
 * 
 * Version 1.0 ----------
 * - Initial code
 * 
 * Version 1.1 ----------
 * + can only be triggered once
 */

using UnityEngine;
using System.Collections;

public class LevelGenTrig : MonoBehaviour {
	public LevelGen.ERA spawnLevelEra;

	bool m_triggered = false;

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player" && !m_triggered){
			GameObject.FindGameObjectWithTag("levelGen").GetComponent<LevelGen>().SpawnLevel(spawnLevelEra);
			m_triggered = true;
		}
	}
}
