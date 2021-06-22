using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeapon : MonoBehaviour
{
    public AIEntity controller;

    public virtual void FireWeapon(int count, float time) { }
}
