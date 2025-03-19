using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    private Weapon weaponPrimary;

    public WeaponData axeData;
    public WeaponData gunData;

    private int weaponUse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weaponPrimary = new WeaponAxe(axeData);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponPrimary = new WeaponAxe(axeData);
            Debug.Log("Primary weapon changed to [AXE]");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponPrimary = new WeaponGun(gunData);
            Debug.Log("Primary weapon changed to [GUN]");
        }

        if (Input.GetMouseButtonDown(0))
            weaponPrimary.Use();
    }
}
