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
