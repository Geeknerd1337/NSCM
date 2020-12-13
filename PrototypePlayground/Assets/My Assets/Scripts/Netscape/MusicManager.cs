using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource ambientSource;
    public AudioSource combatSource;

    public AudioClip combatStart;
    public AudioClip combatLoop;


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


   public void PlayAmbience()
   {
        ambientSource.volume = 0;
        StartCoroutine("AmbienceFadeIn");
   }

   IEnumerator AmbienceFadeIn()
    {
        while(ambientSource.volume < 1)
        {
            ambientSource.volume += Time.deltaTime / 4f;
            yield return null;
        }
    }

    IEnumerator CombatFade()
    {
        while(combatSource.volume < 1)
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
