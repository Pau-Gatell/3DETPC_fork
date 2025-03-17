using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public float health = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Take damage
    public void TakeDamage(float dmg)
    {
        health = health + dmg;
        UIHealth uiHealth = FindObjectOfType<UIHealth>();
        uiHealth.UpdateHealth(health);
    }

    // Regenerate health
    public void RegenHealth(float hp)
    {
        health = health + hp;
        UIHealth uiHealth = FindObjectOfType<UIHealth>();
        uiHealth.UpdateHealth(health);
    }
}
