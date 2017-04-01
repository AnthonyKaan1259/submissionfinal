using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu : MonoBehaviour {

	// Use this for initialization
	public void play () {
        SceneManager.LoadScene("Stage one - making the map");
	}

    public void rules()
    {
        SceneManager.LoadScene("stage two - game rules"); //loads the rules screen
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu"); //Loads the main menu for any backbuttons
    }
	
	// Update is called once per frame
	public void exit () {
        Application.Quit();
	}
}
