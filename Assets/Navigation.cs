using UnityEngine;

public class Navigation : MonoBehaviour {
    public static Transform[] waypoints; //Array that stores game objects using transform

    void Awake() //method set to Awake is called when the program starts, rather than when an object is initialised into it.
    {
        waypoints = new Transform[transform.childCount]; // create new Array of the number of child objects under Navigation (13 points)
        for (int i = 0; i < waypoints.Length; i++) //Loop through so i = 1, 2, 3 etc. For every i = 0 or i less than length of the waypoints array (how many there are), increase value
        {
            waypoints[i] = transform.GetChild(i); //index stores the value of i, which starts at 0 and increments to the total amount of child objects (13)
        }

    }

}
