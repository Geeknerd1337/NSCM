using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A class with references to the various UI elements that make up the player's stats.
/// </summary>
public class PlayerStatsUI : MonoBehaviour
{
    /// <summary>
    /// The text of the player's health
    /// </summary>
    public Text healthText;
    /// <summary>
    /// The text of the player's shield
    /// </summary>
    public Text shieldText;
    /// <summary>
    /// The text of the players current ammo
    /// </summary>
    public Text ammoText;
    /// <summary>
    /// A reference to the player statrs object
    /// </summary>
    private PlayerStats playerStats;
    /// <summary>
    /// A slider representing the hack mana the player currently has.
    /// </summary>
    private Slider hackSlider;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        hackSlider = FindObjectOfType<UIMaster>().hackSlider;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = Mathf.RoundToInt(playerStats.Health).ToString();
        shieldText.text = Mathf.RoundToInt(playerStats.Shield).ToString();
        ammoText.text = playerStats.PlayerWeapon.ShotsLeft.ToString() + "| " + playerStats.ammoTypes[playerStats.PlayerWeapon.AmmoType].ToString();
        hackSlider.value = Mathf.Lerp(hackSlider.value,(float) playerStats.Hack / playerStats.MaxHack, 5f * Time.deltaTime);
    }
}
