//copyright ©, Corey Bradford - Whodok Games, 2014
//Version: 2.0
//Date Modified: 29/05/2014

/* 
 * Version 2.0 ----------
 * + Refactored Entire Code
 * + Split different abilities into different classes
 * 
 * Version 1.0 ----------
 * + Initial code
 * 
 */

using UnityEngine;
using System.Collections;

public class AbilityController : MonoBehaviour {

	public AbilityBase[] Abilities;

	[Range (0, 100)] public float abilityMaxActivateChance = 50;
	[Range (0, 100)] public float abilityChanceIncrease = 1;

	public float timeBetweenAbilities = 30;
	public float abilityStartWarning = 10;
	public float abilityActiveTime = 10;

	bool m_abilityActive = false;
	bool m_abilityRunning = false;

	float m_lastAbilityTime = 0;
	float m_abilityActiveTime = 0;
	float m_abilityChance = 0;

	int m_currentAbility = 0;

	// Update is called once per frame
	void Update () {
		m_lastAbilityTime += Time.deltaTime;

		if(m_abilityChance < abilityMaxActivateChance){
			m_abilityChance += abilityChanceIncrease * Time.deltaTime;
		}

		if(!m_abilityActive && m_lastAbilityTime > timeBetweenAbilities){
			if(Random.Range(0.0f, 100.0f) <= m_abilityChance){
				m_abilityActive = true;
				StartCoroutine(StartRandomAbility());
			}
		}

		if(m_abilityRunning){
			m_abilityActiveTime += Time.deltaTime;
			if(m_abilityActiveTime >= abilityActiveTime){
				m_abilityRunning = false;
				StartCoroutine(StopAbility());
			}
		}
	}

	void ResetAbilityData(){
		m_abilityActive = false;
		m_abilityChance = 0;
		m_lastAbilityTime = 0;
		m_abilityActiveTime = 0;
	}

	IEnumerator StartRandomAbility(){
		yield return new WaitForSeconds(abilityStartWarning);
		m_currentAbility = Random.Range(0, Abilities.Length);
		yield return StartCoroutine(Abilities[m_currentAbility].beginAbility());
		m_abilityRunning = true;
	}

	IEnumerator StopAbility(){
		yield return StartCoroutine(Abilities[m_currentAbility].finishAbility());
		ResetAbilityData();
	}
}
