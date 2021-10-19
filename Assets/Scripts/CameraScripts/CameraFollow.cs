using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private float damping= 2f;
    private Vector3 startPos;
   
    private float camera_x= -3.98f, camera_y= 4.45f, camera_z = 0.07f;
    private bool can_Follow;

    
     void Start()
    {
        player = GameObject.FindWithTag(Tags.PLAYER).transform;
        startPos = transform.position;
        can_Follow = true;
        
    }
    void Update()
    {
        Follow();


    }
    void Follow()
    {
        if (can_Follow)
        {
            transform.position=Vector3.Lerp(transform.position,
                new Vector3(player.position.x+camera_x,player.position.y+camera_y,player.position.z+camera_z),damping);
        }

    }
    public bool  CanFollow {
        get { return can_Follow; }
        set { can_Follow = value; }

    }
}
