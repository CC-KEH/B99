using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody myBody;
    public float walkSpeed=3f;
    public float zSpeed=1.5f;
    private float rotationY=-90f;
    private float rotationSpeed=15f;
    void Awake()
    {
        myBody=GetComponent<Rigidbody>();
    }

    void Update() {
        rotatePlayer();
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
}
