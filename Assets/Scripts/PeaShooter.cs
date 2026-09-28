using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    public GameObject peaPrefab;
    public Transform shootPoint;
    public float shootInterval = 1f;
    public float shootSpeed = 8f;

    float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            timer = 0f;
            Shoot();
        }
    }

void Shoot()
{
    GameObject pea = Instantiate(peaPrefab, shootPoint.position, Quaternion.identity);


    Rigidbody2D rb = pea.GetComponent<Rigidbody2D>();
    rb.linearVelocity = Vector2.up * shootSpeed;
}
}