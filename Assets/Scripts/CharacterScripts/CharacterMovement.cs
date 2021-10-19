using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static CharacterMovement instance;
    private Transform movePoint;
    private CharacterAnimator character_Anim;
    private Rigidbody myBody;
    [SerializeField]
    private float move_Speed = 2f;
    [SerializeField]
    private float horizontal_Speed = 5f;
    private float damping = 5f;
    private float minZ = -6.250f, maxZ = 6.250f;
    private Vector3 temp;
    private bool moveLeft;

    public float opponentDistance = 0f;
    private GameObject[] checkPoints;
    public PositionController master;



    void Awake()
    {
        MakeInstance();
        myBody = GetComponent<Rigidbody>();
        character_Anim = GetComponent<CharacterAnimator>();
        //character_anim,
        checkPoints = GameObject.FindGameObjectsWithTag(Tags.CHECK_POINT);
    }
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    void Start()
    {
       
        movePoint = GameObject.FindWithTag(Tags.END_PLATFORM).transform;
        moveLeft = Random.Range(0, 2) > 0 ? true : false;
        StartCoroutine("randomMovement");
       
        
    }
    public void FindPosition()
    {
        opponentDistance = Vector3.Distance(checkPoints[master.currentPoint].transform.position, this.transform.position);
       
    }
    void Update()
    {

        GetInput();
        playerBounds();
        FindPosition();

    }

    public void MoveLeft()
    {

        temp = new Vector3(myBody.velocity.x, myBody.velocity.y, +horizontal_Speed);
        myBody.velocity = Vector3.Slerp(myBody.velocity, temp, damping);
        

    }
    public void MoveRight()
    {

        temp = new Vector3(myBody.velocity.x, myBody.velocity.y, -horizontal_Speed);
        myBody.velocity = Vector3.Slerp(myBody.velocity, temp, damping);

        
    }
    IEnumerator randomMovement()
    {
        int random = Random.Range(3, 4);
        yield return new WaitForSeconds(random);
        moveLeft = Random.Range(0, 2) > 0 ? true : false;
        if (moveLeft)
            MoveLeft();
        else
            MoveRight();
        StartCoroutine(randomMovement());

      }
    public void StopMovement()
    {
        StopCoroutine(randomMovement());
    }


   
   

    void GetInput()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, move_Speed * Time.deltaTime);

        if (myBody.velocity.sqrMagnitude > 0)
        {
            character_Anim.Run(true);
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
