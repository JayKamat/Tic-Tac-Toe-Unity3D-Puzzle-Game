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

    //Reference to Sound Effects
    public AudioSource asSoundEffects;

    //Reference To Errors
    public GameObject goWinValueError;
    public GameObject goArenaValueError;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //StartLevel function is called to load the level with the current settings.
    public void StartLevel()
    {
        asSoundEffects.Play();

        //Check first then Copy Game Setting values
        if (int.Parse(InputM.text) > 0 && int.Parse(InputM.text) <= 32)
            iMvalue = int.Parse(InputM.text);
        else
        {
            goArenaValueError.SetActive(true);
            return;
        }

        if (int.Parse(InputN.text) > 0 && int.Parse(InputN.text) <= 32)
            iNvalue = int.Parse(InputN.text);
        else
        {
            goArenaValueError.SetActive(true);
            return;
        }

        if (int.Parse(InputWin.text) > 0 && int.Parse(InputWin.text) <= int.Parse(InputN.text) || int.Parse(InputWin.text) <= int.Parse(InputM.text))
            iWinValue = int.Parse(InputWin.text);
        else
        {
            goWinValueError.SetActive(true);
            return;
        }
            

        //Start Game
        StartCoroutine(StartWait());
    }

    public void ExitLevel()
    {
        asSoundEffects.Play();
        StartCoroutine(ExitWait());
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("002_GameScene");
    }

    IEnumerator ExitWait()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}
