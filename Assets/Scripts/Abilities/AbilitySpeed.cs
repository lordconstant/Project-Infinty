//copyright ©, Corey Bradford - Whodok Games, 2014
//Version: 1.0
//Date Modified: 28/05/2014

/*
 * Version 1.0 ----------
 * + Initial code
 * 
 */

using UnityEngine;
using System.Collections;

public class AbilitySpeed : AbilityBase {

	public float playerSpeed = 10;
	public float playerAccel = 5;
	
	float m_playerSpeed;

	public override IEnumerator beginAbility(){
		m_playerSpeed = m_player.GetComponentInParent<CameraController>().speed;

		while(m_player.GetComponentInParent<CameraController>().speed <= playerSpeed - 0.1f || m_player.GetComponentInParent<CameraController>().speed >= playerSpeed + 0.1f){
			m_player.GetComponentInParent<CameraController>().speed = Mathf.Lerp(m_player.GetComponentInParent<CameraController>().speed, playerSpeed, playerAccel * Time.deltaTime);

			yield return null;
		}
	}
	
	public override IEnumerator finishAbility(){
		while(m_player.GetComponentInParent<CameraController>().speed <= m_playerSpeed - 0.1f || m_player.GetComponentInParent<CameraController>().speed >= m_playerSpeed + 0.1f){
			m_player.GetComponentInParent<CameraController>().speed = Mathf.Lerp(m_player.GetComponentInParent<CameraController>().speed, m_playerSpeed, playerAccel * Time.deltaTime);

			yield return null;
		}
	}
}
