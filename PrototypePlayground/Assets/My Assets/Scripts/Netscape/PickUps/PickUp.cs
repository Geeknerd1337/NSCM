using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    /// <summary>
    /// Reference to the player stats class
    /// TODO: Make global scope
    /// </summary>
    private PlayerStats playerStats;
    /// <summary>
    /// The amount of health this pick up gives
    /// </summary>
    [SerializeField]
    private float health;
    /// <summary>
    /// The amount of shield this pickup gives
    /// </summary>
    [SerializeField]
    private float shield;
    /// <summary>
    /// A reference to the audio source for this pickup
    /// </summary>
    private AudioSource sound;

    /// <summary>
    /// The 'ammo type' that this refills on the player stats class
    /// </summary>
    [SerializeField]
    private int ammoIndex;
    /// <summary>
    /// The amount of ammo to give.
    /// </summary>
    public int ammoAmount;

    /// <summary>
    /// Basically, this helps double as a a weapon pick up as well so this decides what weapon the pickup gives you.
    /// </summary>
    [SerializeField]
    private int weaponIndex;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This plays the sound and destroys the pickup
    /// </summary>
    void EquipPack()
    {
        //This code lets the sound play and destroys the object
        sound.transform.SetParent(null);
        sound.Play();
        Destroy(sound.gameObject, 2f);
        Destroy(gameObject);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        //Check to make sure we're colliding with player
        if (other.gameObject.tag == "Player")
        {

            playerStats = other.gameObject.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                //Basically if health isn't already at max
                if (health != 0 && playerStats.Health < playerStats.MaxHealth)
                {
                    playerStats.Health += health;
                    EquipPack();
                }


                //If Shield isn't already at max
                if (shield != 0 && playerStats.Shield < playerStats.MaxShield)
                {
                    playerStats.Shield += shield;
                    EquipPack();
                }

                //If the ammo amount is a non zero value, give the player the ammo.
                if(ammoAmount != 0)
                {
                    playerStats.ammoTypes[ammoIndex] += ammoAmount;
                    EquipPack();
                }

                if(weaponIndex != 0)
                {

                    //TODO: Store reference to weapon manager in singleton
                    WeaponManager w = FindObjectOfType<WeaponManager>();

                    if (w != null)
                    {
                        w.UnlockWeapon(weaponIndex);
                        EquipPack();
                    }

                }


                

            }
        }
    }
}
