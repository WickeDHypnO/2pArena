using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<GameObject> playersList;
	public static List<GameObject> players;

	void Start()
	{
		players = playersList;
	}
}
