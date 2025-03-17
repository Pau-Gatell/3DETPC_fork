using UnityEngine;

public class WeaponDestroy : MonoBehaviour
{
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
        Character[] npcs = FindObjectsOfType<Character>();

        for (int i = 0; i < npcs.Length; i++)
        {
            //npcs[i].Kill();
            npcs[i].Attack();
        }
    }
}
