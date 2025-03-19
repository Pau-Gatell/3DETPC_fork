using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance;

    public float health = 100f;

    public static UnityEvent<float> damageEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Take damage
    public void TakeDamage(float dmg)
    {
        health = health + dmg;

        damageEvent.Invoke(health);
        //UIHealth uiHealth = FindObjectOfType<UIHealth>();
        //uiHealth.UpdateHealth(health);
    }

    // Regenerate health
    public void RegenHealth(float hp)
    {
        health = health + hp;

        damageEvent.Invoke(health);
    }
}
