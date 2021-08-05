using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnimationDelegate : MonoBehaviour
{
    public GameObject left_Arm_Attack_Point, right_Arm_Attack_Point, left_Leg_Attack_Point, right_Leg_Attack_Point;
    public float Stand_Up_Timer=2f;

    private enemyAnimations animationScript;

    private enemyMovement enemy_Movement;

    private AudioSource audioSource;

    [SerializeField]private AudioClip wooshSound, fallSound, groundHitSound, deadSound;

    void Awake(){
        animationScript=GetComponent<enemyAnimations>();
        audioSource=GetComponent<AudioSource>();

        if(gameObject.CompareTag(Tags.ENEMY_TAG)){
            enemy_Movement=GetComponentInParent<enemyMovement>();
        }
    }
    void left_Arm_Attack_On()
    {
        left_Arm_Attack_Point.SetActive(true);
    }
    void left_Arm_Attack_Off()
    {
        if (left_Arm_Attack_Point.activeInHierarchy)
        {
            left_Arm_Attack_Point.SetActive(false);
        }
    }
    void right_Arm_Attack_On()
    {
        right_Arm_Attack_Point.SetActive(true);
    }
    void right_Arm_Attack_Off()
    {
        if (right_Arm_Attack_Point.activeInHierarchy)
        {
            right_Arm_Attack_Point.SetActive(false);
        }
    }
    void right_Leg_Attack_On()
    {
        right_Leg_Attack_Point.SetActive(true);
    }
    void right_Leg_Attack_Off()
    {
        if (right_Leg_Attack_Point.activeInHierarchy)
        {
            right_Leg_Attack_Point.SetActive(false);
        }
    }
    void left_Leg_Attack_On()
    {
        left_Leg_Attack_Point.SetActive(true);
    }
    void left_Leg_Attack_Off()
    {
        if (left_Leg_Attack_Point.activeInHierarchy)
        {
            left_Leg_Attack_Point.SetActive(false);
        }
    } 
     void TagLeft_Arm()
    {
        left_Arm_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }
    void UnTagLeft_Arm()
    {
        left_Arm_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }
    void TagLeft_Leg()
    {
        left_Leg_Attack_Point.tag = Tags.LEFT_LEG_TAG;
    }
    void UnTagLeft_Leg()
    {
        left_Leg_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    void Enemy_StandUp(){
        StartCoroutine(StandUpAfterTime());
    }

    IEnumerator StandUpAfterTime(){
        yield return new WaitForSeconds(Stand_Up_Timer);
        animationScript.StandUp();
    }

    public void Attack_FX_Sound(){
        audioSource.volume=0.2f;
        audioSource.clip=wooshSound;
        audioSource.Play();
    }

    void CharacterDiedSound(){
        audioSource.volume=1f;
        audioSource.clip=deadSound;
        audioSource.Play();
    }

    void Enemy_KnockedDown(){
        audioSource.clip=fallSound;
        audioSource.Play();
    }

    void Enemy_HitGround(){
        audioSource.clip=groundHitSound;
        audioSource.Play();
    }
    void DisableMovement()
    {
        enemy_Movement.enabled = false;
        transform.parent.gameObject.layer = 0;
    }

    void EnableMovement()
    {
        enemy_Movement.enabled = true;
        transform.parent.gameObject.layer = 10;
    }
}

