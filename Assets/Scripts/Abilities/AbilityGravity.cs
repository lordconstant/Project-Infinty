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

public class AbilityGravity : AbilityBase {

	public float playerFlipSpeed = 10;

	Vector3 m_playerScale;

	public override IEnumerator beginAbility(){
		Physics2D.gravity = -Physics2D.gravity;
		m_playerScale = m_player.transform.localScale;

		while(m_player.transform.localScale != new Vector3(m_playerScale.x, -m_playerScale.y, m_playerScale.z)){
			Vector3 t_scale = m_player.transform.localScale;
			t_scale.y = Mathf.Lerp(m_player.transform.localScale.y, -m_playerScale.y, playerFlipSpeed * Time.deltaTime);
			m_player.transform.localScale = t_scale;

			yield return null;
		}
	}

	public override IEnumerator finishAbility(){
		Physics2D.gravity = -Physics2D.gravity;

		while(m_player.transform.localScale != m_playerScale){
			Vector3 t_scale = m_player.transform.localScale;
			t_scale.y = Mathf.Lerp(m_player.transform.localScale.y, m_playerScale.y, playerFlipSpeed * Time.deltaTime);
			m_player.transform.localScale = t_scale;

			yield return null;
		}
	}
}
