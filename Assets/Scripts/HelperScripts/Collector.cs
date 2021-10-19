using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{


     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.MOVING_STICK))
        {
            
            Destroy(other.gameObject);
        }
        
    }



}
