using UnityEngine;
using System.Collections;

public class ObjectSpawn : MonoBehaviour {
	[Range(0, 100)]
		public float spawnRate;
	public GameObject[] objects;

	// Use this for initialization
	void Start () {
		if(Random.value <= spawnRate/100){
			Instantiate(objects[Random.Range(0, objects.Length)], this.transform.position, Quaternion.identity);
		}
	}
}
