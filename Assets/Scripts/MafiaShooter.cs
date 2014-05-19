using UnityEngine;
using System.Collections;

public class MafiaShooter : MonoBehaviour {
	public float fireRate = 0.05f;
	public float reloadTime = 3.0f;
	public int bulletsPerMag = 3;
	public Transform spawnPoint;
	public GameObject image;

	int m_bullets = 0;
	float m_timer = 0.0f;
	float m_reloadTimer = 0.0f;
	bool m_reloading = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(m_reloading){
			m_reloadTimer += Time.deltaTime;

			if(m_reloadTimer >= reloadTime){
				m_reloading = false;
			}
		}

		if(!m_reloading){
			m_timer += Time.deltaTime;

			if(m_bullets < bulletsPerMag){
				if(m_timer >= fireRate){
					GameObject newBullet = Instantiate(image, spawnPoint.position, Quaternion.identity) as GameObject;
					newBullet.name = "bullet";
					newBullet.transform.parent = this.transform.parent;
					m_bullets++;
					m_timer = 0.0f;
				}
			}else{
				m_reloading = true;
				m_reloadTimer = 0.0f;
				m_bullets = 0;
			}
		}
	}
}
