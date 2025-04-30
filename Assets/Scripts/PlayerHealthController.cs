using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance;

    public float health = 100f;
    public float MaxHealth = 100f;

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
        if(health <= 0)
        {
            Animator anim = transform.parent.GetComponentInChildren<Animator>();
            Debug.Log("Player is dead");
            anim.SetBool("Death", true);    
            gameObject.SetActive(false);
        }
    }

    // Take damage
    public void TakeDamage(float dmg)
    {
        health = health + dmg;
        health = Mathf.Clamp(health, 0, MaxHealth);

        damageEvent.Invoke(health);
    }

    // Regenerate health
    public void RegenHealth(float hp)
    {
        health = health + hp;
        health = Mathf.Clamp(health, 0, MaxHealth);

        damageEvent.Invoke(health);
    }

    public bool CanRegen()
    {
        if (health < MaxHealth)
            return true;

        return false;
    }
}
