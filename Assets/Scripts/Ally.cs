using UnityEngine;

public class Ally : Character
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"My name is: {Name}");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Talk()
    {

    }

    public override void Attack()
    {
        Debug.Log("Yo voy a atacar como aliado");
    }
}
