using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField] private float downSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private int healthValue = 20;
    [SerializeField] private ParticleSystem blustEffect;
    private Rigidbody rb;
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
 
    }  
    void Update()
    {
        DownMovement();
    }
    void DownMovement()
    {
        transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Detector"))
        {
            HealthManager.instance.TakeDamage(healthValue);

           ObostaclePool.instance .ReturnObstacle(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.isGameOver)
            return;
        ScoreManager.instance.updateScore(scoreValue);
        Blust();
    }
    void Blust()
    {
        if (blustEffect == null) return;

        var blast = Instantiate(blustEffect, transform.position, Quaternion.identity);
        blast.Play();
        Destroy(blast.gameObject, 1f);
        ObostaclePool. instance.ReturnObstacle(gameObject);
        AudioManager.instance.PlayExplosionSound();
    }
}
