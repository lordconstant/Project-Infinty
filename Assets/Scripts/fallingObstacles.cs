using UnityEngine;
using System.Collections;

public class fallingObstacles : MonoBehaviour {
	public GameObject obstacle;
	public GameObject warning;
	public float spawnRate = 3.0f;
	public float spawnHeight = 7.0f;

	float m_timer = 0.0f;
	float screenH;
	float screenW;

	// Use this for initialization
	void Start () {
		screenH = Camera.main.orthographicSize * 2.0f;
		screenW = screenH / Screen.height * Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
		m_timer += Time.deltaTime;

		if(m_timer >= spawnRate){
			Vector3 newPos;
			newPos.z = 0;
			newPos.y = spawnHeight;
			newPos.x = transform.parent.position.x + Random.Range(-screenW/2, screenW/2);

			GameObject newObs = Instantiate(obstacle, newPos, Quaternion.identity) as GameObject;

			newPos.y = screenH/2 - warning.transform.localScale.y/2;

			GameObject newWarning = Instantiate(warning, newPos, Quaternion.identity) as GameObject;
			newObs.name = "Obstacle";
			newWarning.name = "Warning";

			newObs.transform.parent = transform.parent;
			newWarning.transform.parent = transform.parent;

			m_timer = 0.0f;
		}
	}
}
