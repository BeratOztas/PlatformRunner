using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    
    [SerializeField]
    private GameObject start_Platform_Prefab, platform_Prefab, end_Platform_Prefab,rotating_Platform_Prefab;
    [SerializeField]
    private int amountToSpawn = 10;
    private int beginCount = 0;
    private float rotating_Platform_Blockwidth = 15.56f,rota_p_y= -3.28f,rota_p_z= 2.38f;
    private float blockWidth = 10.876f;
    [SerializeField]
    private int opponentCount = 10;
    [SerializeField]
    private GameObject player_Prefab, opponent_Prefab;
    private Vector3 last_Opponent_Pos;
    private float opponent_Width = 1.113f;
    private Vector3 lastPos;
    private List<GameObject> platform_List = new List<GameObject>();
    public static List<GameObject> opponent_List = new List<GameObject>();
    private bool is_Rotating_Platform;
    private Vector3 temp_Rot;
    private bool rotating_platform_check;
    private int rotating_platform_count = 0;
   
    void Awake()
    {
        InstantiateLevel();
        
    }
     void Start()
    {
        
    }
    
    
    void InstantiateLevel()
    {
        
        for(int i = beginCount; i < amountToSpawn; i++)
        {
            
            GameObject newPlatform;
            if (i == 0)
            {
                newPlatform = Instantiate(start_Platform_Prefab);
            }
            else if(i==amountToSpawn - 1)
            {
                newPlatform = Instantiate(end_Platform_Prefab);
                newPlatform.tag = Tags.END_PLATFORM;

            }
            else
            {
                
                int chance = Random.Range(0, 10);
                if (chance > 8 && rotating_platform_count <1)
                {
                    
                    is_Rotating_Platform = true;
                    newPlatform = Instantiate(rotating_Platform_Prefab);
                    rotating_platform_count = 1;
                }
                else
                {
                    newPlatform = Instantiate(platform_Prefab);
                }
            }
            newPlatform.transform.parent = transform;
            platform_List.Add(newPlatform);
            if (i == 0)
            {
                lastPos = newPlatform.transform.position;
                Vector3 temp = lastPos;            
                temp.y += 0.214f;
               

                continue;
            }
            if (is_Rotating_Platform)
            {
                
                
                newPlatform.transform.position = new Vector3(lastPos.x + rotating_Platform_Blockwidth, lastPos.y+ rota_p_y, lastPos.z+ rota_p_z);
                lastPos = new Vector3(newPlatform.transform.position.x-2.35f,newPlatform.transform.position.y-rota_p_y*2,newPlatform.transform.position.z-rota_p_z * 2);
                rotating_platform_check = true;
                
                
                is_Rotating_Platform = false;
            }
            else {
                if (rotating_platform_check == true)
                {
                    
                 newPlatform.transform.position
                = new Vector3(lastPos.x+4.50f + blockWidth, 0f, 0f);
                    lastPos =new Vector3(newPlatform.transform.position.x - 2.35f, newPlatform.transform.position.y+rota_p_y*2,newPlatform.transform.position.z-rota_p_z*2);
                    rotating_platform_check = false;
                }
                else { 
            newPlatform.transform.position 
            = new Vector3(lastPos.x + blockWidth, 0,0);

            lastPos = newPlatform.transform.position;
                    
               }
            }
            

        }//for loop

        for(int i = 0; i < opponentCount; i++) {
            GameObject newOpponent;
            if (i == 0) { 
            newOpponent = Instantiate(opponent_Prefab);
            newOpponent.transform.rotation=(Quaternion.Euler(0f, 90f, 0f));
             newOpponent.transform.parent = transform;
                opponent_List.Add(newOpponent);
             last_Opponent_Pos = newOpponent.transform.position;
             continue;
            }
            else
            {
                newOpponent = Instantiate(opponent_Prefab);
                newOpponent.transform.rotation = (Quaternion.Euler(0f, 90, 0f));
            }
            newOpponent.transform.parent = transform;
            opponent_List.Add(newOpponent);
            newOpponent.transform.position = new Vector3(last_Opponent_Pos.x, last_Opponent_Pos.y,last_Opponent_Pos.z+ opponent_Width);
            last_Opponent_Pos = newOpponent.transform.position;
            
            
        }//opponent for loop

    }//instantiate

}
