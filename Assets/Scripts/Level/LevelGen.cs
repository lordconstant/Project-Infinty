//copyright ©, Corey Bradford - Whodok Games, 2014
//Version: 1.0
//Date Modified: 11/05/2014

/*
 * Version 1.0 ----------
 * + Initial code
 * 
 */

using UnityEngine;
using System.Collections;

public class LevelGen : MonoBehaviour {

	public enum ERA{
		MODERN = 0,
		FUTURE,
		DINO,
		COUNT
	}
	public GameObject[] modernLevels;
	public GameObject[] futureLevels;
	public GameObject[] dinosaLevels;

	GameObject currentLevel;
	GameObject oldLevel;

	public void Start(){
		currentLevel = GameObject.Find("levelRoot");
	}

	public void SpawnLevel(ERA era){
		GameObject t_level = null;
		Destroy(oldLevel);

		switch (era){
		case ERA.MODERN:
			t_level = Instantiate(modernLevels[Random.Range(0, modernLevels.Length)], currentLevel.transform.Find("levelSpawn").position, Quaternion.identity) as GameObject;
			break;
		case ERA.FUTURE:
			t_level = Instantiate(futureLevels[Random.Range(0, futureLevels.Length)], currentLevel.transform.Find("levelSpawn").position, Quaternion.identity) as GameObject;
			break;
		case ERA.DINO:
			t_level = Instantiate(dinosaLevels[Random.Range(0, dinosaLevels.Length)], currentLevel.transform.Find("levelSpawn").position, Quaternion.identity) as GameObject;
			break;
		default:
			break;
		}
		oldLevel = currentLevel;
		currentLevel = t_level;
	}
}
