using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static int money;
    public int startmoney = 100;

    public static int health;
    public int starthealth = 20;

    private void Start() //Sets money to the start money in each scene, so if the player restarts then they have the same starting money
    {
        money = startmoney;
        health = starthealth;
    }
}
