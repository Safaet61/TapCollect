using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float downSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int scorevalue = 10;
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
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        ScoreManager.instance.updateScore(scorevalue);
        Destroy(gameObject);
    }
}
