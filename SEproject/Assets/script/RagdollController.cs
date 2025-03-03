using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private Rigidbody[] ragdollBodies;
    private Animator animator;

    void Start()
    {
        // Get all the rigidbodies in child objects (ragdoll parts)
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();

        // Make sure the ragdoll is OFF when the game starts
        SetRagdoll(false);
    }

    public void SetRagdoll(bool isRagdoll)
    {
        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = !isRagdoll; // Enable physics when ragdoll is active
            rb.detectCollisions = isRagdoll; // Prevent collisions when not ragdoll
        }

        animator.enabled = !isRagdoll; // Disable Animator when using ragdoll
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Simulate getting hit
        {
            SetRagdoll(true); // Activate ragdoll
        }
    }
}
