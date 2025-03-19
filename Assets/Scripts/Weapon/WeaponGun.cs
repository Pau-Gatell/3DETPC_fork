using UnityEngine;

public class WeaponGun : Weapon
{
    public Transform projectile;

    public WeaponGun(WeaponData data, Transform projectile)
    {
        this.data = data;
        this.projectile = projectile;
    }

    public override void Use()
    {
        Debug.Log($"Gun attacking with range{data.Range}");

        Transform obj = ProjectileController.Instance.GetProjectile();
        obj.position = PlayerDamageController.Instance.transform.position + new Vector3(0, 1.5f, 0);
        obj.rotation = PlayerDamageController.Instance.transform.rotation;
    }

    public override void Render()
    {

    }
}
