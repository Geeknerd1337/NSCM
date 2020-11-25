using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Create/Weapons")]
public class Weapon_SO : ScriptableObject
{
    [Header("Animations")]
    public string fireAnimation;
    public string dryFireAnimation;
    public string aimFireAnimation;
    public string aimDryFireAnimation;
    public string reloadAnimation;
    public string drawAnimation;
    public string idleAnimation;

    [Header("Stats")]
    public float damage;
    public int clipSize;
    public float recoil;
    public int numberOfShots;
    [Range(0, 30)]
    public float maxFireAngle;
    public float effectiveRange;

    [Range(0, 1)]
    public float shakeAmmount;

    [Header("Sounds")]
    public WeaponSound reloadSound;
    public WeaponSound fireSound;
    public WeaponSound dryFireSound;

    
}
[System.Serializable]
public class WeaponSound
{
    public AudioClip sound;
    public Vector2 pitchRange;
    public float volume;

}
