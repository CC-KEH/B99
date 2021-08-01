using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private enemyAnimations enemyAnimations;
    private Rigidbody myBody;

    public float Speed=5f;

    private Transform playerTarget;

    public float attackDistance=1f;
    private float chasePlayerAfterAttack=1f;

    private float currentAttackTime;
    private float defaultAttackTime=2f;

    private bool followPlayer, attackPlayer;

    void Awake() {
        enemyAnimations=GetComponentInChildren<enemyAnimations>();
        myBody=GetComponent<Rigidbody>();

        playerTarget=GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }
    void Start()
    {
       followPlayer=true;
       currentAttackTime=defaultAttackTime; 
    }

    void Update() {
        Attack();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followTarget();
    }

    void followTarget(){
        if(!followPlayer)
        return;

        if(Vector3.Distance(transform.position, playerTarget.position)>attackDistance){
            transform.LookAt(playerTarget);
            myBody.velocity=transform.forward*Speed;

            if(myBody.velocity.sqrMagnitude!=0){
                enemyAnimations.Walk(true);
            }

        }
        else if(Vector3.Distance(transform.position, playerTarget.position)<=attackDistance){
                myBody.velocity=Vector3.zero;
                enemyAnimations.Walk(false);

                followPlayer=false;
                attackPlayer=true;
            }
    }

    void Attack(){
        if(!attackPlayer)
        return;

        currentAttackTime+=Time.deltaTime;
        if(currentAttackTime>defaultAttackTime){
            enemyAnimations.EnemyAttack(Random.Range(0,3));
            currentAttackTime=0f;
        }

        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance+chasePlayerAfterAttack){
            attackPlayer=false;
            followPlayer=true;
        }
    }
}
