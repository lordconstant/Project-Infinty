using UnityEngine;
using System.Collections;

public class obstacleHit : MonoBehaviour {
	public WorldScript levelScript = null;

	float screenH;
	float screenW;

	// Use this for initialization
	void Start () {
		if(!levelScript){
			levelScript = Camera.main.GetComponent<WorldScript>() as WorldScript;
		}

		screenH = Camera.main.orthographicSize * 2.0f;
		screenW = screenH / Screen.height * Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.localPosition.y < -screenH/2){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag == "Player"){
			levelScript.lives--;
			Destroy(gameObject);
		}
	}
}
