using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The weapon manager is partially what handles the UI and also what weapon the player is currently using. It also tracks certain elements of the players weapon selection.
/// </summary>
public class WeaponManager : MonoBehaviour
{
    /// <summary>
    /// A list of game objects representing the physical game objects of each weapon the player has. These are tracked at all times
    /// </summary>
    public List<GameObject> guns;
    /// <summary>
    /// The current gun we have selected on the UI, relates to the guns list
    /// </summary>
    private int gunIndex;
    /// <summary>
    /// The current index of the weapon we are holding in our hand, relates to the guns list
    /// </summary>
    private int gunIndexActual;
    /// <summary>
    /// The current weapon we have selected
    /// </summary>
    public Weapon currentWeapon;

    /// <summary>
    /// A reference to the gun selection UI class
    /// </summary>
    [SerializeField]
    private GunSelectionUI gunUI;

    /// <summary>
    /// An audio source for playing various sounds such as hovering over a weapon in the UI or selecting one
    /// </summary>
    [SerializeField]
    private AudioSource sounds;

    /// <summary>
    /// An audio clip of the sound made when hovering over weapons in the UI
    /// </summary>
    [SerializeField]
    private AudioClip hoverSound;
    /// <summary>
    /// An audio clip of the sound made when selecting a weapon
    /// </summary>
    [SerializeField]
    private AudioClip selectSound;

    /// <summary>
    /// Public reference to the gun UI
    /// </summary>
    public GunSelectionUI GunUI
    {
        get
        {
            return gunUI;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gunIndex = 0;
        gunIndexActual = 0;
        ActivateGun(gunIndexActual);
  

        
    }

    private void Awake()
    {
        gunUI = FindObjectOfType<GunSelectionUI>();
        gunUI.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        ScrollWeapon();
        NumberWeapon();
    }

    /// <summary>
    /// This is a function that essentially allows us to select weapons using the number keys ala Half-Life
    /// </summary>
    void NumberWeapon()
    {
        //A for loop that loops through every weapon category, this is how we check if you're pressing a number key
        for(int i = 1; i < gunUI.weaponCategories.Count + 1; i++)
        {
            if(Input.GetKeyDown("" + i))
            {
                //If the gun UI object (the UI element) is not activated
                if (!gunUI.gameObject.activeSelf)
                {
                    //Activate it
                    gunUI.gameObject.SetActive(true);
                    Debug.Log(i);
                    //Use a function to get the relevant slot
                    int slot = gunUI.GetSlotFromCategory(i - 1);
                    //If the slot is not -1, set the 
                    if (slot != -1)
                    {
                        //Set the gun index to the slot we are selecting
                        gunIndex = slot;
                        //Player the hover sound
                        PlayHoverSound();
                    }
                    else
                    {
                        //Other wise make sure we are not making this visible
                        gunUI.gameObject.SetActive(false);
                    }
                }
                else
                {
                    //If the gun UI eelement we are tying to select is already activated, we want to basically do the same as above, but this time increment up by one in the slots.
                    //What this does is essentially allow us to cycle through the different weapons in a category by pressing the relevant number key multiple times
                    gunUI.weaponCategories[i - 1].Increment();
                    int slot = gunUI.GetSlotFromCategory(i - 1);
                    if (slot != -1)
                    {
                        gunIndex = slot;
                        PlayHoverSound();
                    }
                    Debug.Log(gunIndex);
                }
            }
        }

    }

    /// <summary>
    /// Good old fashioned mouse wheel scrolling to scroll through the gun UI
    /// </summary>
    void ScrollWeapon()
    {
        //Get the input from the scroll wheel.
        float f = Input.mouseScrollDelta.y;

        //If we are scrolling, activate the gun UI
        if(Mathf.Abs(f) > 0)
        {
            if (!gunUI.gameObject.activeSelf)
            {
                gunUI.gameObject.SetActive(true);
            }
        }

        if(f > 0)
        {
            PlayHoverSound();
            Decrement();
        }

        if(f < 0)
        {
            PlayHoverSound();
            Increment();
        }



        //Take the weapon slot for the relevant gun index and store it
        WeaponSlot w = gunUI.SelectWeapon(gunIndex);
        //If we press left click
        if (Input.GetMouseButtonDown(0))
        {
            //If the gun we are selecting is not active, activate the gun
            if (!guns[gunIndex].activeSelf)
            {
                PlaySelectSound();
                ActivateGun(w.gunIndex);
            }
            else {
                //Otherwise, if the gun we are selecting is one we have equiped, pause firing long enough to close the UI
                if (gunUI.gameObject.activeSelf)
                {
                    currentWeapon.StartCoroutine("WaitToAllowFire");
                }
            }
            //Turn the UI off
            gunUI.gameObject.SetActive(false);
            gunUI.ResetAllGunCategories();
        }
    }

    /// <summary>
    /// Incremments the gun index up by one, resetting to zero and skipping over weapons we don't already have
    /// </summary>
    void Increment()
    {
        gunIndex++;

        

        if(gunIndex > gunUI.weaponSlots.Count - 1)
        {
            gunIndex = 0;
        }

        while (!gunUI.SlotHasWeapon(gunIndex))
        {
            gunIndex++;
            if (gunIndex > gunUI.weaponSlots.Count - 1)
            {
                gunIndex = 0;
            }
        }
    }

    /// <summary>
    /// Unlocks a weapon from the gunUI weaponslots and activated the gun for us, effectively equipping on pick up.
    /// TODO: Make equip on pick up a setting
    /// </summary>
    /// <param name="i">The index of the weapon that we are unlocking</param>
    public void UnlockWeapon(int i)
    {
        gunUI.gameObject.SetActive(true);
        gunUI.weaponSlots[i].HasWeapon = true;
        gunUI.weaponSlots[i].EnableSlot();
        gunUI.SelectWeapon(i);
        gunIndex = i;
        ActivateGun(i);
        gunUI.gameObject.SetActive(false);
    }

    /// <summary>
    /// Same as increment, but in reverse.
    /// </summary>
    void Decrement()
    {
        gunIndex--;
        if(gunIndex < 0)
        {
            gunIndex = gunUI.weaponSlots.Count - 1;
        }

        while (!gunUI.SlotHasWeapon(gunIndex))
        {
            gunIndex--;
            if (gunIndex < 0)
            {
                gunIndex = gunUI.weaponSlots.Count - 1;
            }
        }
    }

    /// <summary>
    /// Activates the gun we want to equip. 
    /// </summary>
    /// <param name="gun">The index of the gun we are activating</param>
    void ActivateGun(int gun)
    {
        
        for (int i = 0; i < guns.Count; i++)
        {
            if (i == gun)
            {
                guns[i].SetActive(true);
                gunIndexActual = i;
                gunIndex = i;
            }
            else
            {
                guns[i].SetActive(false);
            }

            currentWeapon = CurrentWeapon();
        }
    }

    /// <summary>
    /// Gets the relevant weapon object from a given index.
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public Weapon GetWeaponFromIndex(int i )
    {
        if (guns[i] != null)
        {
        return guns[i].GetComponent<Weapon>();

        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Gets the current weapon the player is holding
    /// </summary>
    /// <returns>The weapon the player is holding</returns>
    public Weapon CurrentWeapon()
    {
        if (guns[gunIndexActual] != null)
        {
            return guns[gunIndexActual].GetComponent<Weapon>();
        }
        else
        {
            return null;
        }
    }

    public void PlaySelectSound()
    {
        sounds.clip = selectSound;
        sounds.Play();
    }

    public void PlayHoverSound()
    {
        sounds.clip = hoverSound;
        sounds.Play();
    }
}
