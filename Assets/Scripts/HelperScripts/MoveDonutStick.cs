using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDonutStick : MonoBehaviour
{

    private float donut_Stick_speed = 5f;
           
    void Update()
    {
        Move(); 
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.x -= donut_Stick_speed*Time.deltaTime;
        transform.position = temp;
    }
     
}
