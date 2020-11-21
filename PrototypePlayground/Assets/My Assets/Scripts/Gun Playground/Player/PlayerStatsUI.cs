using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatsUI : MonoBehaviour
{

    public Text healthText;
    public Text shieldText;
    public Text ammoText;
    private PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = Mathf.RoundToInt(playerStats.Health).ToString();
        shieldText.text = Mathf.RoundToInt(playerStats.Shield).ToString();
        ammoText.text = playerStats.PlayerWeapon.ShotsLeft.ToString() + "| " + playerStats.ammoTypes[playerStats.PlayerWeapon.AmmoType].ToString();

    }
}
