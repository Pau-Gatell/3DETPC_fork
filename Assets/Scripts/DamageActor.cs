using UnityEngine;

public class DamageActor : MonoBehaviour
{
    public float damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealthController hCtr = other.GetComponent<PlayerHealthController>();

        if(damage > 0)
        {
            hCtr.RegenHealth(damage);
        }
        else
        {
            hCtr.TakeDamage(damage);
        }

        Destroy(this.gameObject);
    }
}
