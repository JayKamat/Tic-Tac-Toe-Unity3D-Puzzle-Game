using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrefab : MonoBehaviour {

    //Private Variables
    GameObject goParent;
    GameObject goChild;
    int iButtonSiblingIndex;

    //Variables to be Passed by Value
    int iM;
    int iN;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClickThis()
    {
        //Get he the position of the child being clicked in the Grid.
        goChild = transform.gameObject;
        iButtonSiblingIndex = goChild.transform.GetSiblingIndex();

        //Get Matrix Position of the Child in the Grid
        iM = iButtonSiblingIndex / GameSettings.iNvalue;
        iN = iButtonSiblingIndex - (iM * GameSettings.iNvalue);
        Debug.Log(iM + "  " + iN);

    }
}