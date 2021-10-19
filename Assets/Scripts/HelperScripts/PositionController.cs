using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionController : MonoBehaviour
{
    private float[] characterPositions = new float[11];
    private GameObject Player;
    private float PlayerPosition;
    private GameObject[] opponents;
    public int currentPos;
    public int currentPoint;
    public Text rankingText;
        


    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        opponents = GameObject.FindGameObjectsWithTag(Tags.OPPONENT);
        rankingText = GameObject.FindGameObjectWithTag(Tags.TEXT).GetComponent<Text>();


    }
    
    void Update()
    {
        
        PositionCalculate();
        
        rankingText.text = currentPos.ToString() + " /  " + characterPositions.Length;
    }

    public void PositionCalculate()
    {
        try
        {
            characterPositions[0] = Player.GetComponent<PlayerMovement>().playerDistance;
            characterPositions[1] = opponents[0].GetComponent<CharacterMovement>().opponentDistance;
            characterPositions[2] = opponents[1].GetComponent<CharacterMovement>().opponentDistance;
            characterPositions[3] = opponents[2].GetComponent<CharacterMovement>().opponentDistance;
            characterPositions[4] = opponents[3].GetComponent<CharacterMovement>().opponentDistance;
            characterPositions[5] = opponents[4].GetComponent<CharacterMovement>().opponentDistance;
            characterPositions[6] = opponents[5].GetComponent<CharacterMovement>().opponentDistance;
            characterPositions[7] = opponents[6].GetComponent<CharacterMovement>().opponentDistance;
            characterPositions[8] = opponents[7].GetComponent<CharacterMovement>().opponentDistance;
            characterPositions[9] = opponents[8].GetComponent<CharacterMovement>().opponentDistance;
            characterPositions[10] = opponents[9].GetComponent<CharacterMovement>().opponentDistance;

            PlayerPosition = Player.GetComponent<PlayerMovement>().playerDistance;
        }
        catch(Exception e)
        {
            
        }

       
        Array.Sort(characterPositions);
        int position = Array.IndexOf(characterPositions, PlayerPosition);

        switch (position)
        {
            case 0:
                currentPos = 11;
                break;
            case 1:
                currentPos = 10;
                break;
            case 2:
                currentPos = 9;
                break;
            case 3:
                currentPos = 8;
                break;
            case 4:
                currentPos = 7;
                break;
            case 5:
                currentPos = 6;
                break;
            case 6:
                currentPos = 5;
                break;
            case 7:
                currentPos = 4;
                break;
            case 8:
                currentPos = 3;
                break;
            case 9:
                currentPos = 2;
                break;
            case 10:
                currentPos = 1;
                break;

        }

    }//void 
}





