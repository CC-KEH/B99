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

    void FixedUpdate() {
        DetectMovement();
    }

    void DetectMovement(){
        myBody.velocity=new Vector3(Input.GetAxisRaw("Horizontal")*(-walkSpeed), myBody.velocity.y, Input.GetAxisRaw("Vertical")*(-zSpeed));
    }
}
