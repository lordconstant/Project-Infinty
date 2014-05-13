//copyright ©, Christopher Gough - Whodok Games, 2014
//Version: 2.0
//Date Modified: 09/05/2014

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 5.0f;
	public float jumpPower = 8.0f;

	bool m_left = false;
	bool m_right = false;
	bool m_jumping = false;
	bool m_moving = false;
	bool m_crouching = false;

	float screenW;
	float screenH;

	Vector3 m_normalScale;

	// Use this for initialization
	void Start () {
		screenH = Camera.main.orthographicSize * 2.0f;
		screenW = screenH / Screen.height * Screen.width;
		m_normalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("a") || Input.GetKey("left")){
			m_left = true;
		}

		if(Input.GetKeyUp("a") || Input.GetKeyUp("left")){
			m_left = false;
		}

		if(Input.GetKey("d") || Input.GetKey("right")){
			m_right = true;
		}
		
		if(Input.GetKeyUp("d") || Input.GetKeyUp("right")){
			m_right = false;
		}

		if(Input.GetKey("space") && !m_jumping){
			m_jumping = true;

			transform.rigidbody2D.AddForce(new Vector2(0.0f, jumpPower*100));
		}

		if(Input.GetKeyDown("s") && !m_crouching){
			m_crouching = true;

			Vector3 curScale = transform.localScale;
			curScale.y = curScale.y / 2;
			transform.localScale = curScale;
		}

		if(Input.GetKeyUp("s") && m_crouching){
			m_crouching = false;
			
			transform.localScale = m_normalScale;
		}

		if(!m_left && !m_right){
			m_moving = false;
		}else{
			m_moving = true;
		}

		if(m_moving){
			Move ();
		}
	}

	void Move(){
		Vector3 curPos = transform.localPosition;

		if(m_left && curPos.x > -screenW/2 + transform.localScale.x/2){
			curPos.x -= Time.deltaTime * speed;
		}

		if(m_right && curPos.x < screenW/2 - transform.localScale.x/2){
			curPos.x += Time.deltaTime * speed;
		}

		transform.localPosition = curPos;
	}

	void OnCollisionStay2D(Collision2D other){
		if(m_jumping){
			if(other.contacts[0].point.y > other.transform.position.y && other.contacts[0].point.x < (other.transform.position.x + (other.collider.renderer.bounds.size.x / 2)) && other.contacts[0].point.x > (other.transform.position.x - (other.collider.renderer.bounds.size.x / 2))){
				m_jumping = false;
			}
		}
	}
}
