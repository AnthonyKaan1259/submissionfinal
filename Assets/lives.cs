using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class lives : MonoBehaviour {

    public Text health;
	
	// Update is called once per frame
	void Update () {
        health.text = Player.health.ToString() + " lives remaining."; //Convert the player health var to a string and concatinate
	}
}
