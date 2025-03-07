using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using Cinemachine;
=======
>>>>>>> dashAndJump
using UnityEngine;

public class DeerStateMachine : MonoBehaviour
{
    private IDeerState deerState;
<<<<<<< HEAD
    private bool isAlive;

    public Rigidbody rb;

    public bool IsGrounded { get; set; } = true;
    private Animator animator;

    [SerializeField] CinemachineFreeLook mainCam;
    [SerializeField] CinemachineFreeLook deadCam;

    [SerializeField] RagdollController ragdollController;

    void Start()
    {
        mainCam.Priority = 1;
        deadCam.Priority = 0;

        rb = GetComponent<Rigidbody>();
        deerState = new DeerWalk(this);
        if (rb == null)
        {
            Debug.LogError("Rigidbody missing");
        }
        animator = transform.Find("Deer_001").GetComponent<Animator>();
        isAlive = true;
    }

    public void setState(IDeerState d)
    {
=======

    public Rigidbody rb;

    public bool IsGrounded {get; set;} = true;

    private Animator animator;
    private GameManagerScript gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        deerState = new DeerWalk(this);
        animator = transform.Find("Deer_001").GetComponent<Animator>();
        gameManager = new GameManagerScript();
    }
    public void setState(IDeerState d){
>>>>>>> dashAndJump
        deerState = d;
    }

    void Update()
    {
<<<<<<< HEAD
        if (deerState == null)
        {
            Debug.LogError("deerstate null");
            return;
        }
        animator.SetFloat("speed", rb.velocity.magnitude);
        if (isAlive)
        {
            if (Input.GetKey(KeyCode.W)) deerState.handleForward();
            if (Input.GetKey(KeyCode.A)) deerState.handleLeft();
            if (Input.GetKey(KeyCode.D)) deerState.handleRight();
            if (Input.GetKeyDown(KeyCode.Space)) deerState.handleSpace();
            if (Input.GetKeyDown(KeyCode.LeftShift)) deerState.handleShift();
        }
        deerState.handleGravity();
        deerState.advanceState();
        //Debug.Log(rb.velocity.magnitude);
        if (Input.GetKey(KeyCode.P))
        {
            ActivateDeath();
        }
    }

    void ActivateDeath()
    {
        mainCam.Priority = 0;
        deadCam.Priority = 1;
        animator.SetTrigger("Death");
        animator.enabled = false;
    }

    void OnCollisionEnter(Collision c)
    {
        IsGrounded = true;
        if (c.gameObject.tag == "Obstacle")
        {
            ActivateDeath();
            ragdollController.SetRagdoll(true);
            isAlive = false;
        }
=======
        
        animator.SetFloat("speed", rb.velocity.magnitude);
        if (Input.GetKey(KeyCode.W)) deerState.handleForward();
        if (Input.GetKey(KeyCode.A)) deerState.handleLeft();
        if (Input.GetKey(KeyCode.D)) deerState.handleRight();
        if (Input.GetKeyDown(KeyCode.Space)) deerState.handleSpace();
        if (Input.GetKeyDown(KeyCode.LeftShift)) deerState.handleShift();
        // this.transform.rotation = gameManager.camRotation;
        deerState.handleGravity();
        deerState.advanceState();

    }

    void OnCollisionEnter(Collision c){
        IsGrounded = true;
>>>>>>> dashAndJump
    }
}
