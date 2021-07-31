using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private playerAnimation player_animation;
    private Rigidbody myBody;
    public float walkSpeed=3f;
    public float zSpeed=1.5f;
    private float rotationY=-90f;
    private float rotationSpeed=15f;
    void Awake()
    {
        myBody=GetComponent<Rigidbody>();
        player_animation=GetComponentInChildren<playerAnimation>();
    }

    void Update() {
        rotatePlayer();
        animatePlayerWalk();
    }

    void FixedUpdate() {
        DetectMovement();
    }

    void DetectMovement(){
        myBody.velocity=new Vector3(Input.GetAxisRaw("Horizontal")*(-walkSpeed), myBody.velocity.y, Input.GetAxisRaw("Vertical")*(-zSpeed));
    }

    void rotatePlayer(){
       if(Input.GetAxisRaw("Horizontal")>0){
           transform.rotation=Quaternion.Euler(0f, rotationY, 0f);
       }
       else if(Input.GetAxisRaw("Vertical")<0){
           transform.rotation=Quaternion.Euler(0f, Mathf.Abs(rotationY), 0f);
       } 
    }

    void animatePlayerWalk(){
        if(Input.GetAxisRaw("Horizontal")!=0||Input.GetAxisRaw("Vertical")!=0){
            player_animation.Walk(true);
        }
        else{player_animation.Walk(false);}
    }
}
