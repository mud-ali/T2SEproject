using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private Rigidbody[] ragdollBodies;
    private Rigidbody mainRagdollBody;
    private Animator animator;
    private bool isRagdoll = false;
    public float launchPower = 100f;
    public float collisionDelay = 3f;

    void Start()
    {
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();

        mainRagdollBody = GetComponentInChildren<Rigidbody>();

        SetRagdoll(false);
    }

    public void SetRagdoll(bool activate, bool launchUp = false)
    {
        isRagdoll = activate;
        animator.enabled = !activate;

        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = !activate;
            rb.detectCollisions = activate;
            rb.velocity = Vector3.zero;
        }

        if (activate && launchUp && mainRagdollBody != null)
        {
            DisableCollisionsTemporarily();
            mainRagdollBody.AddForce(Vector3.up * launchPower, ForceMode.Impulse);
        }
    }

    void DisableCollisionsTemporarily()
    {
        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.detectCollisions = false;
        }
        Invoke(nameof(EnableCollisions), collisionDelay);
    }

    void EnableCollisions()
    {
        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.detectCollisions = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car") && !isRagdoll)
        {
            SetRagdoll(true, true);
        }
    }
}
