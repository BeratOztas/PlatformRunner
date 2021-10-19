using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator anim;
    
     void Awake()
    {
        anim = GetComponent<Animator>();
        
    }
    
    public void Run(bool run)
    {
        anim.SetBool(AnimationTags.RUN, run);
    }
    public void Fall()
    {
        anim.SetTrigger(AnimationTags.FALL);
    }
    public void Celebrate()
    {
        anim.SetTrigger(AnimationTags.CELEBRATE);
    }
    public void Idle(bool idle)
    {
        anim.SetBool(AnimationTags.IDLE,idle);
    }    

}

