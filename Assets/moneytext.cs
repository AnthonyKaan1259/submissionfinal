using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class moneytext : MonoBehaviour {

    public Text moneyplayer;

    // Update is called once per frame
    void Update()
    {
        moneyplayer.text = "£" + Player.money.ToString() + " remaining."; //convert to string, concatinate
    }
}
