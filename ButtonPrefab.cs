﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPrefab : MonoBehaviour {

    //Private Variables
    GameObject goChild;
    Button btChildButton;
    int iButtonSiblingIndex;

    //Variables to be Passed by Value
    int iM;
    int iN;

    //Public reference for Audio
    public AudioSource asSoundEffect;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClickThis()
    {
        if (!GameManager.GameWin)
        {
            asSoundEffect.Play();

            //Increment Clicked Buttons
            GameManager.iTotalClickedButtons += 1;

            //Get the the position of the child being clicked in the Grid.
            goChild = transform.gameObject;
            iButtonSiblingIndex = goChild.transform.GetSiblingIndex();

            //Get Matrix Position of the Child in the Grid
            iM = iButtonSiblingIndex / GameSettings.iNvalue;
            iN = iButtonSiblingIndex - (iM * GameSettings.iNvalue);

            //Disable Button on Click.
            btChildButton = goChild.GetComponent<Button>();
            btChildButton.interactable = false;

            if (GameManager.iPlayerTurn == 1)
            {
                btChildButton.image.color = Color.red;
            }
            else
            {
                btChildButton.image.color = Color.blue;
            }

            if (!GameManager.GameWin)
            {
                //Call static Check Win Event.
                GameManager.CheckWin(iM, iN);
            }
        }
        
    }
}