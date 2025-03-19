using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody body;
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.linearVelocity = transform.forward * speed * Time.fixedDeltaTime;
    }
}
