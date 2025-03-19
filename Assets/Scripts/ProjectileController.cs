using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController
{
    public static ProjectileController Instance;

    public int Count;

    public Queue<Transform> projecileStack;

    public void Init(int count, Transform projectile)
    {
        Instance = this;
        this.Count = count;

        projecileStack = new Queue<Transform>();

        for (int i = 0; i < Count; i++)
        {
            Transform obj = GameObject.Instantiate(projectile);
            obj.gameObject.SetActive(false);
            projecileStack.Enqueue(obj);
        }
    }

    public Transform GetProjectile()
    {
        Transform projectile = projecileStack.Dequeue();
        projecileStack.Enqueue(projectile);
        projectile.gameObject.SetActive(true);

        return projectile;
    }
}
