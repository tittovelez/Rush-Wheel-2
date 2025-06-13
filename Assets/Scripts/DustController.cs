using UnityEngine;

public class DustController : MonoBehaviour
{
    public ParticleSystem dustParticles;
    public Rigidbody2D rb; // Usa Rigidbody si estás en 3D

    void Update()
    {
        if (Mathf.Abs(rb.velocity.x) > 0.1f && IsGrounded())
        {
            if (!dustParticles.isPlaying)
                dustParticles.Play();
        }
        else
        {
            if (dustParticles.isPlaying)
                dustParticles.Stop();
        }
    }

    bool IsGrounded()
    {
        // Aquí puedes hacer un Raycast o usar un Collider para saber si toca el suelo
        return true;
    }
}


