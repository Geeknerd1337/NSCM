using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //Player Instance
    //TODO: Eventually stuff like the player stats, weapons, and the like need to be combined into a single reference within a generalized singleton
    private PlayerStats playerStats;
    [SerializeField]
    private float health;
    [SerializeField]
    private float shield;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void EquipPack()
    {
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


                

            }
        }
    }
}
