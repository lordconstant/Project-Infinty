//copyright ©, Corey Bradford - Whodok Games, 2014
//Version: 1.0
//Date Modified: 12/05/2014

/*
 * Version 1.0 ----------
 * - Initial code
 * 
 */

using UnityEngine;
using System.Collections;

public class ObjectSpawn : MonoBehaviour {
	[Range(0, 100)]
		public float spawnRate;
	public GameObject[] objects;

	// Use this for initialization
	void Start () {
		if(Random.value <= spawnRate/100){
			GameObject t_level = Instantiate(objects[Random.Range(0, objects.Length)], transform.position, Quaternion.identity) as GameObject;
			t_level.transform.parent = transform;
		}
	}
}
