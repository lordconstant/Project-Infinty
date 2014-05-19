using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed = 5.0f;
	public float angle = 0.0f;
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

		transform.Rotate(0, 0, angle);
		rigidbody2D.AddForce(transform.right * speed * 50);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.localPosition.x > screenW/2 || transform.localPosition.x < -screenW/2 || transform.localPosition.y > screenH/2 || transform.localPosition.y < -screenH/2){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag == "Player"){
			levelScript.lives--;
		}

		Destroy(gameObject);
	}
}
