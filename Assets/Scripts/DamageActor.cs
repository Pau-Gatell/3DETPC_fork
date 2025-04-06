using UnityEngine;

public class DamageActor : MonoBehaviour
{
    public float damage;
    public bool isRegen = true;

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
        PlayerHealthController hCtr = other.transform.parent.GetComponentInChildren<PlayerHealthController>();

        if (isRegen && hCtr.CanRegen())
        {
            hCtr.RegenHealth(damage);

            Destroy(this.gameObject);
        }
        else if(!isRegen)
        {
            hCtr.TakeDamage(damage);

            Destroy(this.gameObject);
        }
    }
}
