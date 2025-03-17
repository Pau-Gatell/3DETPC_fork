using UnityEngine;

public class Character : MonoBehaviour
{
    public string Name;
    public float health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Move()
    {

    }

    public virtual void Attack()
    {
        Debug.Log("Voy a atacar como personaje default.");
    }

    public virtual void Kill()
    {
        this.gameObject.SetActive(false);
    }
}
