using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerStateMachine : MonoBehaviour
{
    private IDeerState deerState;

    public Rigidbody rb;

    public bool IsGrounded {get; set;} = true;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        deerState = new DeerWalk(this);
        if (rb == null){
            Debug.LogError("Rigidbody missing");
        }
        animator = transform.Find("Deer_001").GetComponent<Animator>();
    }
    public void setState(IDeerState d){
        deerState = d;
    }

    void Update()
    {
        if (deerState == null){
            Debug.LogError("deerstate null");
            return;
        }
        animator.SetFloat("speed", rb.velocity.magnitude);
        if (Input.GetKey(KeyCode.W)) deerState.handleForward();
        if (Input.GetKey(KeyCode.A)) deerState.handleLeft();
        if (Input.GetKey(KeyCode.D)) deerState.handleRight();
        if (Input.GetKeyDown(KeyCode.Space)) deerState.handleSpace();
        if (Input.GetKeyDown(KeyCode.LeftShift)) deerState.handleShift();
        deerState.handleGravity();
        deerState.advanceState();
        Debug.Log(rb.velocity.magnitude);
    }

    void OnCollisionEnter(Collision c){
        IsGrounded = true;
    }
}
