using UnityEngine;

/// <summary>
/// Player stats is a class that holds things like the players shield, health, and hack mana.
/// </summary>
public class PlayerStats : MonoBehaviour
{
    /// <summary>
    /// Players health
    /// </summary>
    private float health;
    /// <summary>
    /// Player's shield/
    /// </summary>
    private float shield;
    /// <summary>
    /// The max health value of the player
    /// </summary>
    [SerializeField]
    private float maxHealth;
    /// <summary>
    /// The max shield value of the player
    /// </summary>
    [SerializeField]
    private float maxShield;
    /// <summary>
    /// A reference to the weapon manager
    /// </summary>
    [SerializeField]
    private WeaponManager weaponManager;

    /// <summary>
    /// The amount of hack mana we have
    /// </summary>
    private int hack;
    /// <summary>
    /// The max amount of hack mana we have
    /// </summary>
    [SerializeField]
    private int maxHack;

    /// <summary>
    /// A reference to the hurt icons UI, these are the UI elements that tell us where the player is being hurt from
    /// </summary>
    private HurtIconsUI hurtIcons;

    /// <summary>
    /// A reference to the level save data controller
    /// </summary>
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

    public int Hack
    {
        get { return hack; }
        set { hack = Mathf.Clamp(value, 0, maxHack); }
    }

    public float MaxHealth { get { return maxHealth; } }
    public float MaxShield { get { return maxShield; } }
    public int MaxHack { get { return maxHack; } }

    /// <summary>
    /// The current player weapon
    /// </summary>
    public Weapon PlayerWeapon { get { return weaponManager.currentWeapon; } }

    /// <summary>
    /// The different ammo types the player has. This is what weapons and pickups reference for ammo
    /// </summary>
    public int[] ammoTypes;

    
    void Start()
    {
        weaponManager = GetComponentInChildren<WeaponManager>();
        hurtIcons = FindObjectOfType<HurtIconsUI>();
        health = maxHealth;
        shield = maxShield;
        hack = maxHack;

        levelController = FindObjectOfType<LevelSaveDataController>();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// A function that damages the player, taking only a small portion of health and shielf if their shield is greater than 0, additionall 
    /// </summary>
    /// <param name="f">The amount of damage to do to the player</param>
    /// <param name="position">The position in the world where the damage is coming from, used to calculate which icon to enable</param>
    public void DamagePlayer(float f, Vector3 position)
    {
        //Direction from the source of damage to the player
        Vector3 hitDirection = (position - transform.position).normalized;
        hurtIcons.AlertPlayer(hitDirection, transform);

        if (shield > 0)
        {
            shield -= f * 0.6f;
            health -= f * 0.4f;
            if(shield <= 0)
            {
                shield = 0;
            }
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
