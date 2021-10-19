using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touch_Pos = Camera.main.ScreenToViewportPoint(touch.position);
            

            if (touch_Pos.x > 0.6)
            {
                playerMovement.MoveRight();
                
            }
            else if (touch_Pos.x < 0.6)
            {
                playerMovement.MoveLeft();
            }

        }

        //if (Input.touchCount > 0)
        //{

        //    Touch t = Input.GetTouch(0);

        //    if (t.phase == TouchPhase.Began)
        //    {
        //        print("Touch BEGAN");
        //    }

        //    if (t.phase == TouchPhase.Ended)
        //    {
        //        print("Touch ENDED");
        //    }

        //    if (t.phase == TouchPhase.Moved)
        //    {
        //        print("Touch MOVING");
        //    }

        //}

    }
}
