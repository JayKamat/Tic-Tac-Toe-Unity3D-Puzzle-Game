using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //Created a 2D Matrix of Int to hold the values of Button from the Arena.
    int[,] aArenaMatrix = new int[GameSettings.iMvalue, GameSettings.iNvalue];

    //The total Number of Buttons Required. //Deprecated!
    int iTotalButtons = GameSettings.iMvalue * GameSettings.iNvalue;

    //Public Variables accessible in the editor
    public GameObject goButtonPrefab;
    public GameObject goArenaPanel;


    //*Private Variables.
    //Which Player playing next
    private bool iPlayerTurn;


    // Use this for initialization
    void Start () {

        //Calculate Grid Cell dimension values to be set.
        float GridX = 512 / GameSettings.iMvalue;
        float GridY = 512 / GameSettings.iNvalue;
        
        ///Set Grid Cell Size.
        goArenaPanel.GetComponent<GridLayoutGroup>().cellSize.Set(GridX, GridY);

        
        //Temporary variable to store game object instantiated.
        GameObject goPrefab;

        //Instantiate the button prefabs and set their parent to the Arena Panel to include them in the grid.
        for(int iM=0; iM < GameSettings.iMvalue; iM++)
        {
            for (int iN = 0; iN < GameSettings.iNvalue; iN++)
            {
                goPrefab = Instantiate(goButtonPrefab);
                goPrefab.transform.SetParent(goArenaPanel.transform, false);
                aArenaMatrix[iM, iN] = 0;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(EventSystem.current.currentSelectedGameObject.);    //Deprecated
	}

    public void CheckWin(int iM, int iN)
    {

    }
    
}
