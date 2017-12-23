using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameSettings : MonoBehaviour {
    
    //**Global Variables
    //Rows & Columns in the Game
    public static int iMvalue;
    public static int iNvalue;
    //Win Condition Value
    public static int iWinValue=3;

    //References to Input Field
    public TMP_InputField InputM;
    public TMP_InputField InputN;
    public TMP_InputField InputWin;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //StartLevel function is called to load the level with the current settings.
    public void StartLevel()
    {

        //Copy Game Setting values
        iMvalue = int.Parse(InputM.text);
        iNvalue = int.Parse(InputN.text);
        iWinValue = int.Parse(InputWin.text);

        //Start Game
        SceneManager.LoadScene("002_GameScene");
    }
}
