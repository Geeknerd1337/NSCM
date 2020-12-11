using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float health;
    private float shield;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxShield;
    [SerializeField]
    private WeaponManager weaponManager;

    private HurtIconsUI hurtIcons;

    private LevelSaveDataController levelController;

    public float Health {
        get { return health; }
        set
        {
            health = value;
            health = Mathf.Clamp(health, 0, maxHealth);
        }
        }
    public float Shield {
        get { return shield; }
        set
        {
            shield = value;
            shield = Mathf.Clamp(shield, 0, maxShield);
        }
    }

    public float MaxHealth { get { return maxHealth; } }
    public float MaxShield { get { return maxShield; } }
    public Weapon PlayerWeapon { get { return weaponManager.currentWeapon; } }

    public int[] ammoTypes;

    
    void Start()
    {
        weaponManager = GetComponentInChildren<WeaponManager>();
        hurtIcons = FindObjectOfType<HurtIconsUI>();
        health = maxHealth;
        shield = maxShield;

        levelController = FindObjectOfType<LevelSaveDataController>();
    }

    void Update()
    {
        
    }

    public void DamagePlayer(float f, Vector3 position)
    {
        Vector3 hitDirection = (position - transform.position).normalized;
        hurtIcons.AlertPlayer(hitDirection, transform);

        if (shield > 0)
        {
            shield -= f * 0.6f;
            health -= f * 0.4f;
        }
        else
        {
            health -= f;
        }

        if (health < 0)
        {
            levelController.OnDeath();
        }
    }

}
