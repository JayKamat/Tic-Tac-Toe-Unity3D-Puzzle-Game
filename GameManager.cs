using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //Created a 2D Matrix of Int to hold the values of Button from the Arena.
    public static int[,] aArenaMatrix = new int[GameSettings.iMvalue, GameSettings.iNvalue];

    //The total Number of Buttons Required. //Deprecated!
    int iTotalButtons = GameSettings.iMvalue * GameSettings.iNvalue;

    //Public Variables accessible in the editor
    public GameObject goButtonPrefab;
    public GameObject goArenaPanel;


    //*Private Variables.
    //Which Player playing next
    public static int iPlayerTurn = 1;

    // Use this for initialization
    void Start () {

        //Calculate Grid Cell dimension values to be set.
        float GridX = 512 / GameSettings.iNvalue;
        float GridY = 512 / GameSettings.iMvalue;

        ///Set Grid Cell Size.
        goArenaPanel.GetComponent<GridLayoutGroup>().cellSize = new Vector2(GridX, GridY);

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

    //Check if player Wins after every turn end.
    public static void CheckWin(int iM, int iN)
    {
        //Check Win Variables
        int isum = 1;
        int icurrentValue = 0;

        Debug.Log(iM +"  "+ iN);

        //Set and Get Value
        icurrentValue = iPlayerTurn;
        aArenaMatrix[iM, iN] = icurrentValue;

        //Extra Temp Variables
        int iMtemp = iM;
        int iNtemp = iN;

        ///Check Horizontal
        //Check Horizontal Right
        while(iNtemp + 1 < GameSettings.iNvalue)
        {
            if(aArenaMatrix[iM, iNtemp + 1] == iPlayerTurn)
            {
                isum += 1;
                iNtemp++;
            }
            else
            {
                break;
            }
        }
        //Reset
        iNtemp = iN;

        //Check Horizontal Left
        while (iNtemp - 1 >= 0)
        {
            if (aArenaMatrix[iM, iNtemp - 1] == iPlayerTurn)
            {
                isum += 1;
                iNtemp--;
            }
            else
            {
                break;
            }
        }
        //Reset
        iNtemp = iN;

        //Check Win
        if (isum==GameSettings.iWinValue)
        {
            Debug.Log("Player " + iPlayerTurn + " Wins with " + isum + " in a row" );
        }



        ///Check Vertical
        isum=1;
        //Check Vertical Down
        while (iMtemp + 1 < GameSettings.iMvalue)
        {
            if (aArenaMatrix[iMtemp+1, iN] == iPlayerTurn)
            {
                isum += 1;
                iMtemp++;
            }
            else
            {
                break;
            }
        }
        //Reset
        iMtemp = iM;

        //Check Vertical Up
        while (iMtemp - 1 >= 0)
        {
            if (aArenaMatrix[iMtemp-1, iN] == iPlayerTurn)
            {
                isum += 1;
                iMtemp--;
            }
            else
            {
                break;
            }
        }
        //Reset
        iMtemp = iM;

        //Check Win
        if (isum == GameSettings.iWinValue)
        {
            Debug.Log("Player " + iPlayerTurn + " Wins with " + isum + " in a column");
        }




        ///Check Diagonal 1 L-R
        isum = 1;
        //Check Diagonal 1 Down
        while (iMtemp + 1 < GameSettings.iMvalue && iNtemp + 1 < GameSettings.iNvalue)
        {
            if (aArenaMatrix[iMtemp + 1, iNtemp + 1] == iPlayerTurn)
            {
                isum += 1;
                iMtemp++;
                iNtemp++;
            }
            else
            {
                break;
            }
        }
        //Reset
        iMtemp = iM;
        iNtemp = iN;

        //Check Diagonal 1 Up
        while (iMtemp - 1 >= 0 && iNtemp - 1 >= 0)
        {
            if (aArenaMatrix[iMtemp - 1, iNtemp - 1] == iPlayerTurn)
            {
                isum += 1;
                iMtemp--;
                iNtemp--;
            }
            else
            {
                break;
            }
        }
        //Reset
        iMtemp = iM;
        iNtemp = iN;

        //Check Win
        if (isum == GameSettings.iWinValue)
        {
            Debug.Log("Player " + iPlayerTurn + " Wins with " + isum + " in a Diagonal L-R");
        }





        ///Check Diagonal 2 R-L
        isum = 1;
        //Check Diagonal 2 Down
        while (iMtemp + 1 < GameSettings.iMvalue && iNtemp - 1 >= 0)
        {
            if (aArenaMatrix[iMtemp + 1, iNtemp -1] == iPlayerTurn)
            {
                isum += 1;
                iMtemp++;
                iNtemp--;
            }
            else
            {
                break;
            }
        }
        //Reset
        iMtemp = iM;
        iNtemp = iN;

        //Check Diagonal 2 Up
        while (iMtemp - 1 >= 0 && iNtemp + 1 < GameSettings.iNvalue)
        {
            if (aArenaMatrix[iMtemp - 1, iNtemp + 1] == iPlayerTurn)
            {
                isum += 1;
                iMtemp--;
                iNtemp++;
            }
            else
            {
                break;
            }
        }
        //Reset
        iMtemp = iM;
        iNtemp = iN;

        //Check Win
        if (isum == GameSettings.iWinValue)
        {
            Debug.Log("Player " + iPlayerTurn + " Wins with " + isum + " in a Diagonal R-L");
        }


        //Change Turn
        if (iPlayerTurn == 1)
        { iPlayerTurn = 2; }
        else
        { iPlayerTurn = 1; }
    }
    
}
