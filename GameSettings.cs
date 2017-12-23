using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameSettings : MonoBehaviour {
    
    //**Global Variables
    //Rows & Columns in the Game
    public static int iMvalue=3;
    public static int iNvalue=3;
    //Win Condition Value
    public static int iWinValue=3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //StartLevel function is called to load the level with the current settings.
    public void StartLevel()
    {
        SceneManager.LoadScene("002_GameScene");
    }
}
