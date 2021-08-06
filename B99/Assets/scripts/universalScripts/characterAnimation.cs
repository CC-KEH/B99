using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnimation : MonoBehaviour
{
    private Animator animator;


    void Awake(){
        animator=GetComponent<Animator>();
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
     // Enemy Animations
    public void EnemyAttack(int attack)
    {
        if (attack == 0)
        {
            animator.SetTrigger(AniTags.ATTACK_1_TRIGGER);
        }

        if (attack == 1)
        {
            animator.SetTrigger(AniTags.ATTACK_2_TRIGGER);
        }

        if (attack == 2)
        {
            animator.SetTrigger(AniTags.ATTACK_3_TRIGGER);
        }
    }

    public void PlayIdleAnimation()
    {
        animator.Play(AniTags.IDLE_ANIMATION);
    }

    public void KnockDown()
    {
        animator.SetTrigger(AniTags.KNOCK_DOWN_TRIGGER);
    }

    public void StandUp()
    {
        animator.SetTrigger(AniTags.STAND_UP_TRIGGER);
    }

    public void Hit()
    {
        animator.SetTrigger(AniTags.HIT_TRIGGER);
    }

    public void Death()
    {
        animator.SetTrigger(AniTags.DEATH_TRIGGER);
    }
}
