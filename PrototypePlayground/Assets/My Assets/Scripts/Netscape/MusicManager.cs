using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource ambientSource;
    public AudioSource combatSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void PlayAmbience()
   {
        ambientSource.Play();
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
}
