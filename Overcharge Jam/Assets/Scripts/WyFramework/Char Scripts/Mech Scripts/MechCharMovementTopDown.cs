using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
This class explain and describes how the documentation of the Wy framework works.
 
Explanation:
 
Usage:

Integration:

Implement Later:
    - Joystick Twinstick DroneMovement Controls

 */
public class MechCharMovementTopDown : MonoBehaviour
{

    public Vector3 idleForce;
    public float forwardSpeedMultiplier = 1; // multiplier for forward movement force
    public float horiSpeedMultiplier = 1; // multiplier for right movement force


    private float horizontalSpeed = 3f;
    private float verticalSpeed = 3f;

    // Logic
    // public lLogic

    // Non Viewable

    //EditorViewable
    // public var vObj

    //EditorSetRef
    // public var rObj

    // Components in this obj
    //public var myComp;
    private Rigidbody myRB;

    // CustComponents in this obj
    //public var myCustComp;

    // Components in Child
    //public var _child_Comp
    private Animator child_Animator;

    // CustComponents in Child
    //public var _child_CustComp

    // Components in External
    //public var _ex_Comp

    // CustComponents in External
    //public var _ex_CustComp

    // Components in External Child
    //public var _ex_child_Comp

    // CustComponents in External Child
    //public var _ex_child_CustComp


    // Start is called before the first frame update
    void Awake()
    {
        myRB = GetComponent<Rigidbody>();
        child_Animator = GetComponentInChildren<Animator>();
        horizontalSpeed *= horiSpeedMultiplier;
        verticalSpeed *= forwardSpeedMultiplier;

    }

    // Update is called once per frame
    void Update()
    {

        MoveForward(Input.GetAxis("Vertical"));

        MoveRight(Input.GetAxis("Horizontal"));

        //MoveUp(Input.GetAxis("Fire1"));
        //MoveUp(-Input.GetAxis("Fire2"));



        // if no movement button vert or hori press, decelerate and slowdown speed
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            DecelerateOnIdle();
    }

    public void MoveRight(float AxisValue)
    {
        Vector3 direction = transform.right * (horizontalSpeed * AxisValue);
        myRB.AddForce(direction);

        if (AxisValue > 0.1 || AxisValue < -0.1)
        {
            Vector3 meshDirection = direction - transform.position;
            Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
            child_Animator.transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.3f * Time.time);
        }

    }
    public void MoveForward(float AxisValue)
    {
        Vector3 direction = transform.forward * (horizontalSpeed * AxisValue);

        myRB.AddForce(transform.forward * (horizontalSpeed * AxisValue));
        if (AxisValue > 0.1 || AxisValue < -0.1)
        {
            Vector3 meshDirection = direction - transform.position;
            Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);


            toRotation =
            child_Animator.transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.3f * Time.time);

            child_Animator.transform.rotation = Quaternion.Euler(child_Animator.transform.rotation.eulerAngles.x,  child_Animator.transform.rotation.eulerAngles.z, Camera.main.transform.eulerAngles.y);
        }

    }
    public void MoveUp(float AxisValue)
    {
        myRB.AddForce(transform.up * (verticalSpeed * AxisValue));
    }

    public void DecelerateOnIdle()
    {
        myRB.velocity = Vector3.zero;

    }



}