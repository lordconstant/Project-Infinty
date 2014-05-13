//copyright ©, Christopher Gough - Whodok Games, 2014
//Version: 1.0
//Date Modified: 09/05/2014

using UnityEngine;
using System.Collections;

public class WorldScript : MonoBehaviour {
	public float scoreRate = 10;
	public int lives = 3;
	public GUIText gameText = null;

	float m_score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		m_score += Time.deltaTime * scoreRate;

		if(gameText != null){
			gameText.text = ((int)m_score).ToString();
		}

		if(lives < 0){
			Application.LoadLevel("Game");
		}
	}
}
