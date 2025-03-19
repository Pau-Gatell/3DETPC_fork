using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/Data", order = 1)]
public class WeaponData : ScriptableObject
{
    public string Name;
    public float Damage;
    public float Range;
    public float Cooldown;
}
