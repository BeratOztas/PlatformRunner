using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerMovement : MonoBehaviour
{
   
    private Transform movePoint;
    private CharacterAnimator character_Anim;
    private Rigidbody myBody;

    [SerializeField]
    private float move_Speed = 2f;
    [SerializeField]
    private float horizontal_Speed = 5f;
    private float damping=5f;
    private float minZ = -6.250f, maxZ = 6.250f;
    private Vector3 temp;

    public  float playerDistance=0f;
    private GameObject[] checkPoints;
    public PositionController master;
    private GameObject playerFollower;
    
   
    
   
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        character_Anim = GetComponent<CharacterAnimator>();
        
        playerFollower = GameObject.FindGameObjectWithTag(Tags.PLAYER_FOLLOWER);
       
        checkPoints = GameObject.FindGameObjectsWithTag(Tags.CHECK_POINT);


    }

    void Start()
    {
        movePoint = GameObject.FindWithTag(Tags.END_PLATFORM).transform;

    }
    public void FindPosition()
    {
        playerDistance = Vector2.Distance(playerFollower.transform.position, checkPoints[master.currentPoint].transform.position);
       
    }

    
    void Update()
    {

        GetInput();
        playerBounds();
        FindPosition();
    }

    public void MoveLeft() {
        
        temp = new Vector3(myBody.velocity.x, myBody.velocity.y, +horizontal_Speed);
        myBody.velocity = Vector3.Slerp(myBody.velocity, temp, damping);
        
        
    }
    public void MoveRight() {
        
        temp = new Vector3(myBody.velocity.x, myBody.velocity.y, -horizontal_Speed);
      myBody.velocity = Vector3.Slerp(myBody.velocity,  temp, damping);
        
        
    }
    

    
   
    void GetInput()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, move_Speed*Time.deltaTime);

        

        if (myBody.velocity.sqrMagnitude > 0)
        {
            character_Anim.Run(true);
            character_Anim.Idle(false);
        }


        float x = Input.GetAxisRaw(Axis.HORIZONTAL);

        if (x > 0)
        {
            MoveRight();
        }
        else if (x < 0)
        {
            MoveLeft();
        }
       


    }
    void playerBounds()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,
            Mathf.Clamp(transform.position.z, minZ, maxZ));
    }
    public void platformMove(float z)
    {
        myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y, z);
    }

}
