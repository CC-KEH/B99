using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimations : MonoBehaviour
{
    private Animator animator;
    
    void Awake(){
        animator=GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EnemyAttack(int attack){
        if(attack==0){
            animator.SetTrigger(AniTags.ATTACK_1_TRIGGER);
        }

        if(attack==1){
            animator.SetTrigger(AniTags.ATTACK_2_TRIGGER);
        }

        if(attack==2){
            animator.SetTrigger(AniTags.ATTACK_3_TRIGGER);
        }
    }

    public void playIdleAnimation(){
        animator.Play(AniTags.IDLE_ANIMATION);
    }

    public void KnockDown(){
        animator.SetTrigger(AniTags.KNOCK_DOWN_TRIGGER);
    }

    public void StandUp(){
        animator.SetTrigger(AniTags.STAND_UP_TRIGGER);
    }

    public void Hit(){
        animator.SetTrigger(AniTags.HIT_TRIGGER);
    }

    public void Death(){
        animator.SetTrigger(AniTags.DEATH_TRIGGER);
    }

    public void Walk(bool move){
        animator.SetBool(AniTags.MOVEMENT, move);
    }
}
