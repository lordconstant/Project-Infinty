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

public abstract class AbilityBase : MonoBehaviour {

	public GameObject m_player;

	// Use this for initialization
	void Start () {
		m_player = GameObject.FindGameObjectWithTag("Player");
	}

	public abstract IEnumerator beginAbility();

	public abstract IEnumerator finishAbility();
}
