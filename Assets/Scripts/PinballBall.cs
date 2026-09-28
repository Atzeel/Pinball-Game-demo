using UnityEngine;
using System.Collections;
using TMPro;

public class PinballBall : MonoBehaviour
{

    public Transform spawnPoint;

    public TMP_Text scoreText;

    public float respawnDelay = 1f;

    Rigidbody2D rb;
    SpriteRenderer sr;

    int score;

    bool isDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        UpdateScoreText();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.collider.CompareTag("ScoreTarget"))
        {
            score += 1;
            UpdateScoreText();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("DeathZone"))
        {
            StartCoroutine(DieAndRespawn());
        }
    }

    IEnumerator DieAndRespawn()
    {
        isDead = true;
        score = 0;
        UpdateScoreText();

        sr.enabled = false;
      
        yield return new WaitForSeconds(respawnDelay);
        
        //spawn it somewhere else i.e. transform.position = new position;
        transform.position = spawnPoint.position;
        
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        sr.enabled = true;
        isDead = false;
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score:" + score;

        }
    }
}
