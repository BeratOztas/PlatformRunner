using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    
    [SerializeField]
    private Transform[] obstacles;
    

    
    void Start()
    {
        ActivePlatform();
        


    }
    void ActiveObstacle() {
        int index = Random.Range(0, obstacles.Length);
        obstacles[index].gameObject.SetActive(true);
        if (index == 2)
        {

            obstacles[index].GetChild(0).DOLocalMoveZ(1f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
            obstacles[index].GetChild(1).DOLocalMoveZ(-1f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
            
        }
    
    }
    

   void ActivePlatform() {
        int chance = Random.Range(0, 10);
        if(chance > 1)
        {
            int type = Random.Range(0, 9);
            switch (type)
            {
                case 0:
                    ActiveObstacle();
                    break;
                case 1:
                    ActiveObstacle();
                    break;
                case 2:
                    ActiveObstacle();
                    break;
                case 3:
                    ActiveObstacle();
                    break;
                case 4:
                    ActiveObstacle();
                    break;
                case 5:
                    ActiveObstacle();
                    break;
                case 6:
                    ActiveObstacle();
                    break;
                case 7:
                    ActiveObstacle();
                    break;
                case 8:
                    ActiveObstacle();
                    break;


            }

        }

    }
    
}//class
