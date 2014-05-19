using UnityEngine;
using System.Collections;

public class delayedDestroy : MonoBehaviour {
	public float delay = 3.0f;

	float m_timer = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		m_timer += Time.deltaTime;

		if(m_timer >= delay){
			Destroy(gameObject);
		}
	}
}
