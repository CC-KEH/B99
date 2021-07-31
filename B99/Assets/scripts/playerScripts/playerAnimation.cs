using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    private Animator animator;


    void Awake(){
        animator=GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Walk(bool move){
        animator.SetBool(AniTags.MOVEMENT, move);
    }

    public void Punch1(){
        animator.SetTrigger(AniTags.PUNCH_1_TRIGGER);
    }

    public void Punch2(){
        animator.SetTrigger(AniTags.PUNCH_2_TRIGGER);
    }

    public void Punch3(){
        animator.SetTrigger(AniTags.PUNCH_3_TRIGGER);
    }

    public void Kick1(){
        animator.SetTrigger(AniTags.KICK_1_TRIGGER);
    }
    public void Kick2(){
        animator.SetTrigger(AniTags.KICK_2_TRIGGER);
    }
}
