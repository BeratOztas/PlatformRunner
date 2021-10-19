using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private CharacterAnimator character_Anim;
    private Rigidbody myBody;
    private Vector3 startPos;
    private bool playerDied;


    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        
        character_Anim = GetComponent<CharacterAnimator>();
    }

    void Update()
    {
        if (myBody.velocity.sqrMagnitude > 140)
        {
            StartCoroutine(ReturnSpawnPos(startPos));
        }
        

    }
     void Start()
    {
        startPos = transform.position;  
    }
    IEnumerator ReturnSpawnPos(Vector3 spawnPos)
    {
        yield return new WaitForSeconds(1f);
        transform.position = spawnPos;
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.CompareTag(Tags.STATIC_OBS))
        {
            
            StartCoroutine(ReturnSpawnPos(startPos));

            

        }

        if (target.gameObject.CompareTag(Tags.HORIZONTAL_OBS))
        {
            
            StartCoroutine(ReturnSpawnPos(startPos));
            

        }
        //You can stick.
        if (target.gameObject.CompareTag(Tags.ROTATOR_STICK))
        {
            
            myBody.AddRelativeForce(Vector3.forward, ForceMode.Impulse);
            character_Anim.Fall();
            //character_anim

        }
        if (target.gameObject.CompareTag(Tags.DONUT_STICK))
        {
            
           
            myBody.AddRelativeForce(Vector3.back, ForceMode.Impulse);
            character_Anim.Fall();
            
        }
        if (target.gameObject.CompareTag(Tags.END_PLATFORM))
        {
            
            CharacterMovement.instance.StopCoroutine("randomMovement");
            character_Anim.Celebrate();
            character_Anim.Idle(true);
            

        }
        

    }//on collision

}
