using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a simple class used for controlling the music in each level. Right now it just contains 2 audio sources one for ambience, one for combat.
/// TODO: Replace this system entirely
/// </summary>
public class MusicManager : MonoBehaviour
{
    /// <summary>
    /// The ambient sound source
    /// </summary>
    public AudioSource ambientSource;
    /// <summary>
    /// The higher energy combat sound
    /// </summary>
    public AudioSource combatSource;

    /// <summary>
    /// The ambient track.
    /// </summary>
    public AudioClip combatStart;
    /// <summary>
    /// The combat track
    /// </summary>
    public AudioClip combatLoop;
    /// <summary>
    /// Volume of the music
    /// </summary>
    public float musicVolume = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        combatSource.Play();
        ambientSource.Play();
        combatSource.volume = 0f;
        ambientSource.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Plays the music by starting AmbienceFadeIn coroutine
    /// </summary>
   public void PlayAmbience()
   {
        ambientSource.volume = 0;
        StartCoroutine("AmbienceFadeIn");
   }

    /// <summary>
    /// TODO: REMOVE
    /// </summary>
    public void PlayAmbienceSmall()
    {
        ambientSource.volume = 0;
        StartCoroutine("AmbienceFadeInSmall");
    }

    IEnumerator AmbienceFadeIn()
    {
        while(ambientSource.volume < musicVolume)
        {
            ambientSource.volume += Time.deltaTime / 4f;
            yield return null;
        }
    }


    IEnumerator AmbienceFadeInSmall()
    {
        while (ambientSource.volume < 0.6f)
        {
            ambientSource.volume += Time.deltaTime / 4f;
            yield return null;
        }
    }

    IEnumerator CombatFade()
    {
        while(combatSource.volume < musicVolume)
        {
            combatSource.volume += Time.deltaTime / 4f;
            ambientSource.volume -= Time.deltaTime / 4f;
            yield return null;
        }
    }

    public void StartCombatMusic()
    {
        StartCoroutine("CombatFade");
    }
}
