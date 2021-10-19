using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField]
    private float rotating_Platform_Speed = 0.3f;
    private float movement_platform_speed_left = 8f,movement_platform_speed_right = -8f;
    private bool isLeft_Platform, isRight_Platform;
   
    private int right;

    void Awake()
    {
        right = Random.Range(0, 2);
        if (right == 0)
            isRight_Platform = true;
        else
            isLeft_Platform = true;
    }
    void Update()
    {
        rotatePlatform();
    }
    void rotatePlatform()
    {
        
        if(right==0)
        transform.Rotate(0, 0, -rotating_Platform_Speed);

        else
        {
          transform.Rotate(0, 0, rotating_Platform_Speed);

        }
    }
    
    void OnCollisionStay(Collision target)
    {
        if (target.gameObject.CompareTag(Tags.PLAYER))
        {
            if (isLeft_Platform)
            {
                target.gameObject.GetComponent<PlayerMovement>().platformMove(movement_platform_speed_left);
            }
            if (isRight_Platform)
            {
                target.gameObject.GetComponent<PlayerMovement>().platformMove(movement_platform_speed_right);
            }
                   

        }
        if (target.gameObject.CompareTag(Tags.OPPONENT))
        {
            if (isLeft_Platform)
            {
                target.gameObject.GetComponent<CharacterMovement>().platformMove(movement_platform_speed_left);
            }
            if (isRight_Platform)
            {
                target.gameObject.GetComponent<CharacterMovement>().platformMove(movement_platform_speed_right);
            }

        }

    }
}
