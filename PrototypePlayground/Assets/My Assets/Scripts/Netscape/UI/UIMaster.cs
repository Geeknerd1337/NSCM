using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMaster : MonoBehaviour
{
    public Transform hackElement;
    public Image hackRadialElement;
    public Image hackFillElement;

    public Transform grappleElement;

    public MessageSystem messageSystem;

    public Slider hackSlider;

    public static PlayerStats playerStats;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }
}
