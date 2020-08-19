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

    [Header("Stats")]
    public string damage;
    
}
