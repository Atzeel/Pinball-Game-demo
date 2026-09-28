using UnityEngine;

public class BallTeleport : MonoBehaviour
{
    public Transform blackHoleExit;

    public Transform whiteHoleExit;
    
    public float teleportCooldown = 0.3f;

    float nextTeleportTime;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Time.time < nextTeleportTime) return;

        if (other.CompareTag("BlackHole"))
        {
            Teleport(whiteHoleExit);
        }
        else if (other.CompareTag("WhiteHole"))
        {
            Teleport(blackHoleExit);
        }
        
    }

    void Teleport(Transform destination)
    {
        if (destination == null) return;

        transform.position = destination.position;
        nextTeleportTime = Time.time + teleportCooldown;
    }

}

