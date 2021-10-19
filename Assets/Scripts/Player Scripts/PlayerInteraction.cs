using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerInteraction : MonoBehaviour
{

    private CharacterAnimator character_Anim;
    private Rigidbody myBody;
    private CameraFollow cameraFollow;
    private bool playerDied;
    

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        character_Anim = GetComponent<CharacterAnimator>();
    }

    void Update()
    {
        if (!playerDied)
        {
            if (myBody.velocity.sqrMagnitude > 140  )
            {
                playerDied = true;
                cameraFollow.CanFollow = false;
                GameController.instance.RestartGame();
            }

        }
                
    }
    
    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.CompareTag(Tags.STATIC_OBS))
        {
            
            
            cameraFollow.CanFollow = false;
            GameController.instance.RestartGame();
            gameObject.SetActive(false);

        }
        
        if (target.gameObject.CompareTag(Tags.HORIZONTAL_OBS))
        {
                       
            cameraFollow.CanFollow = false;
            GameController.instance.RestartGame();
            gameObject.SetActive(false);
        }
        
        if (target.gameObject.CompareTag(Tags.ROTATOR_STICK))
        {
           
            myBody.AddRelativeForce(Vector3.forward, ForceMode.Impulse);
            character_Anim.Fall();
            

        }
        if (target.gameObject.CompareTag(Tags.DONUT_STICK))
        {
            
            
            myBody.AddRelativeForce(Vector3.back, ForceMode.Impulse);
            character_Anim.Fall();
            
        }
        if (target.gameObject.CompareTag(Tags.END_PLATFORM))
        {
           
                       
            character_Anim.Celebrate();
            character_Anim.Idle(true);
            GameController.instance.RestartGame();

            

        }
        if (target.gameObject.CompareTag(Tags.OPPONENT)) { }

    }//on collision





}

