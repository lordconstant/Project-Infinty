//copyright ©, Corey Bradford - Whodok Games, 2014
//Version: 1.0
//Date Modified: 16/05/2014

/* 
 * Version 1.0 ----------
 * + Initial code
 * 
 */

using UnityEngine;
using System.Collections;

public class Abilities : MonoBehaviour {
	const int NUM_ABILITIES = 3;

	public enum ABILITIES{
		GRAVITY = 0,
		SIZE_UP,
		SPEED_UP,
		COUNT
	}

	//Public variables ----------
	public float timeBetweenAbilities = 30;

	[Range (0, 100)] public float abilityMaxActivateChance = 50;
	[Range (0, 100)] public float abilityChanceIncrease = 1;

	public float abilityActiveTime = 10;
	public float playerScaleAbility = 2;
	public float playerSpeedAbility = 10;

	//---------- ---------- ----------

	//Private variables ----------
	public bool m_abilityActive = false;
	public bool m_endAbility = false;

	//time since last ability ended
	float m_lastAbility = 0;
	//time current ability has been active
	float m_abilityTime = 0;
	//countdown for ability to start
	float m_startCountdown = 0;
	//percentage chance ability will activate
	float m_abilityChance = 0;

	float m_playerSpeed;

	GameObject m_player;

	public ABILITIES m_ability;

	//---------- ---------- ----------

	// Use this for initialization
	void Start () {
		m_player = GameObject.FindGameObjectWithTag("Player");
		m_playerSpeed = m_player.transform.parent.GetComponent<CameraController>().speed;
	}
	
	// Update is called once per frame
	void Update () {
		m_lastAbility += Time.deltaTime;

		if(m_abilityChance < abilityMaxActivateChance){
			m_abilityChance += abilityChanceIncrease * Time.deltaTime;
		}

		//Check if enough time has passed between abilities and an ability isnt active - Chance to activate ability if true
		if(!m_abilityActive && m_lastAbility > timeBetweenAbilities){
			if(Random.Range(0, 100) <= m_abilityChance){
				m_abilityActive = true;
				SetRandomAbility();
			}
		}

		//run ability code
		if(m_abilityActive){
			if(m_startCountdown < 10){
				m_startCountdown += Time.deltaTime;
				if(m_startCountdown > 10){
					StartAbility();
				}
			}
			else{
				UpdateAbility();
			}
		}
	}

	void StartAbility(){
		switch (m_ability){
		case ABILITIES.GRAVITY:
			InvertGravity();
			break;
		default:
			break;
		}
	}

	void UpdateAbility(){
		m_abilityTime += Time.deltaTime;

		if(m_abilityTime < abilityActiveTime){
			switch (m_ability){
			case ABILITIES.GRAVITY:
				m_player.transform.localScale = Vector3.Lerp(m_player.transform.localScale, new Vector3( 1, -1, 1), 10 * Time.deltaTime);
				break;
			case ABILITIES.SIZE_UP:
				ChangePlayerSize();
				break;
			case ABILITIES.SPEED_UP:
				ChangePlayerSpeed();
				break;
			default:
				break;
			}
		}
		else{
			m_endAbility = true;
			EndAbility();
		}
	}

	void EndAbility(){
		bool t_canEnd = false;

		switch (m_ability){
		case ABILITIES.GRAVITY:
			InvertGravity();
			t_canEnd = true;
			break;
		case ABILITIES.SIZE_UP:
			ChangePlayerSize();
			if(m_player.transform.localScale == new Vector3(1,1,1)){
				t_canEnd = true;
			}
			break;
		case ABILITIES.SPEED_UP:
			ChangePlayerSpeed();
			t_canEnd = true;
			break;
		default:
			break;
		}

		if(t_canEnd){
			m_abilityTime = 0;
			m_lastAbility = 0;
			m_abilityChance = 0;
			m_startCountdown = 0;
			m_abilityActive = false;
			m_endAbility = false;
		}
	}

	void SetRandomAbility(){
		System.Array A = System.Enum.GetValues(typeof(ABILITIES));
		m_ability = (ABILITIES)A.GetValue(Random.Range(0, A.Length - 1));
	}

	void InvertGravity(){
		Physics2D.gravity = -Physics2D.gravity;
		m_player.GetComponent<PlayerController>().jumpPower = -m_player.GetComponent<PlayerController>().jumpPower;
	}

	void ChangePlayerSize(){
		if(m_endAbility){
			m_player.transform.localScale = Vector3.Lerp(m_player.transform.localScale, new Vector3(1,1, 1), playerScaleAbility * Time.deltaTime);
		}
		else{
			m_player.transform.localScale = Vector3.Lerp(m_player.transform.localScale, new Vector3(playerScaleAbility, playerScaleAbility, 1), playerScaleAbility * Time.deltaTime);
		}
	}

	void ChangePlayerSpeed(){
		if(m_endAbility){
			m_player.transform.parent.GetComponent<CameraController>().speed = Mathf.Lerp(m_player.transform.parent.GetComponent<CameraController>().speed, playerSpeedAbility, playerSpeedAbility * Time.deltaTime);
		}
		else{
			m_player.transform.parent.GetComponent<CameraController>().speed = Mathf.Lerp(m_player.transform.parent.GetComponent<CameraController>().speed, m_playerSpeed, m_playerSpeed * Time.deltaTime);
		}
	}
}
