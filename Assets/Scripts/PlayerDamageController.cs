using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    public static PlayerDamageController Instance;

    private Weapon weaponPrimary;

    public WeaponData axeData;
    public WeaponData gunData;
    public Transform projectile;

    private int weaponUse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
            Instance = this;

        weaponPrimary = new WeaponAxe(axeData);
    }

    private void Start()
    {
        ProjectileController proj = new ProjectileController();
        proj.Init(5, projectile);
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
            weaponPrimary = new WeaponGun(gunData, projectile);
            Debug.Log("Primary weapon changed to [GUN]");
        }

        if (Input.GetMouseButtonDown(0))
            weaponPrimary.Use();
    }
}
