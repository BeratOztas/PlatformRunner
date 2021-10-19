using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private bool isUsed;
    public PositionController master;

   void OnTriggerEnter(Collider other)
    {
        if(other.tag ==Tags.OPPONENT && !isUsed || other.tag==Tags.PLAYER && !isUsed)
        {
            
            isUsed = true;
            master.currentPoint++;
        }
        
    }


}
