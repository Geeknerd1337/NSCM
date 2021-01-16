using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{

    public List<GameObject> guns;
    private int gunIndex;
    private int gunIndexActual;
    public Weapon currentWeapon;

    [SerializeField]
    private GunSelectionUI gunUI;

    [SerializeField]
    private AudioSource sounds;

    [SerializeField]
    private AudioClip hoverSound;
    [SerializeField]
    private AudioClip selectSound;

    
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

    void NumberWeapon()
    {
        for(int i = 1; i < gunUI.weaponCategories.Count + 1; i++)
        {
            if(Input.GetKeyDown("" + i))
            {
                if (!gunUI.gameObject.activeSelf)
                {
                    gunUI.gameObject.SetActive(true);
                    Debug.Log(i);
                    //gunIndex = gunUI.weaponCategories[i - 1].GetWeaponSlot(i - 1);
                    int slot = gunUI.GetSlotFromCategory(i - 1);
                    if (slot != -1)
                    {
                        gunIndex = slot;
                        PlayHoverSound();
                    }
                    else
                    {
                        gunUI.gameObject.SetActive(false);
                    }
                }
                else
                {
                    
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

        if (Input.GetMouseButtonDown(0))
        {
            //ActivateGun(w.gunIndex);
           //gunUI.gameObject.SetActive(false);
            //gunUI.ResetAllGunCategories();
        }
    }

    void ScrollWeapon()
    {
        float f = Input.mouseScrollDelta.y;

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



        
        WeaponSlot w = gunUI.SelectWeapon(gunIndex);
        if (Input.GetMouseButtonDown(0))
        {

            if (!guns[gunIndex].activeSelf)
            {
                PlaySelectSound();
                ActivateGun(w.gunIndex);
            }
            else {
                if (gunUI.gameObject.activeSelf)
                {
                    currentWeapon.StartCoroutine("WaitToAllowFire");
                }
            }
            gunUI.gameObject.SetActive(false);
            gunUI.ResetAllGunCategories();
        }
    }

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