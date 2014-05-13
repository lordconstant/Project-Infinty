//copyright ©, Christopher Gough - Whodok Games, 2014
//Version: 1.0
//Date Modified: 12/05/2014

using UnityEngine;
using System.Collections;

public class ObjectCollision : MonoBehaviour {
	public bool left = true;
	public bool right = true;
	public bool top = false;
	public bool bottom = false;
	public WorldScript levelScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.transform.tag == "Player"){
			if(other.contacts[0].point.x < transform.position.x && other.contacts[0].point.y < (transform.position.y + (transform.renderer.bounds.size.y / 2)) && other.contacts[0].point.y > (transform.position.y - (transform.renderer.bounds.size.y / 2)) && left){
				Debug.Log("left");
				levelScript.lives--;
			}

			if(other.contacts[0].point.x > transform.position.x && other.contacts[0].point.y < (transform.position.y + (transform.renderer.bounds.size.y / 2)) && other.contacts[0].point.y > (transform.position.y - (transform.renderer.bounds.size.y / 2)) && right){
				Debug.Log("right");
				levelScript.lives--;
			}

			if(other.contacts[0].point.y < transform.position.y && other.contacts[0].point.x < (transform.position.x + ((transform.renderer.bounds.size.x / 2) - 0.1)) && other.contacts[0].point.x > (transform.position.x - ((transform.renderer.bounds.size.x / 2) - 0.1)) && bottom){
				Debug.Log("bottom");
				levelScript.lives--;
			}

			if(other.contacts[0].point.y > transform.position.y && other.contacts[0].point.x < (transform.position.x + ((transform.renderer.bounds.size.x / 2) - 0.1)) && other.contacts[0].point.x > (transform.position.x - ((transform.renderer.bounds.size.x / 2) - 0.1)) && top){
				Debug.Log("top");
				levelScript.lives--;
			}
		}
	}
}
