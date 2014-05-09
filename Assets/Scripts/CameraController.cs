//copyright ©, Christopher Gough - Whodok Games, 2014
//Version: 1.0
//Date Modified: 09/05/2014

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float speed = 3.0f;
	public bool moving = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(moving){
			Vector3 curPos = transform.position;

			curPos.x += Time.deltaTime * speed;

			transform.position = curPos;
		}
	}
}
