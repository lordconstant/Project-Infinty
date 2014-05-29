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

public class AbilityScale : AbilityBase {
	
	public float playerScaleSpeed = 10;
	public float playerScale = 1.5f;

	Vector3 m_playerScale;
	
	public override IEnumerator beginAbility(){
		m_playerScale = m_player.transform.localScale;

		while(m_player.transform.localScale != new Vector3( playerScale, playerScale, playerScale)){
			m_player.transform.localScale = Vector3.Lerp(m_player.transform.localScale, new Vector3( playerScale, playerScale, playerScale), playerScaleSpeed * Time.deltaTime);

			yield return null;
		}
	}
	
	public override IEnumerator finishAbility(){
		while(m_player.transform.localScale != m_playerScale){
			m_player.transform.localScale = Vector3.Lerp(m_player.transform.localScale, m_playerScale, playerScaleSpeed * Time.deltaTime);

			yield return null;
		}
	}
}
