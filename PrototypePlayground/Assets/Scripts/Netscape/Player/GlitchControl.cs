using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Kino;

/// <summary>
/// This class controls the glitch effect for the camera. Currently used for level transitions.
/// </summary>
public class GlitchControl : MonoBehaviour
{

    public DigitalGlitch[] glitches;
    [Range(0, 1)]
    public float amt = 0;

    /// <summary>
    /// How long the glitch is
    /// </summary>
    public float glitchTime;
    /// <summary>
    /// A float telling us the current time of the glitch
    /// </summary>
    private float glitchTimer;
    /// <summary>
    /// An audio source used for playing the transition sound
    /// </summary>
    public AudioSource transition;

    /// <summary>
    /// Whether or not we are loading a level
    /// </summary>
    private bool loading;
    /// <summary>
    /// The load timer essentially will auto force the level to change if for some reason it does not. 
    /// TODO: Look into depreceating.
    /// </summary>
    private float loadTimer;
    /// <summary>
    /// The build index of the scene we intend to load
    /// </summary>
    private int levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        glitches = GetComponentsInChildren<DigitalGlitch>();
        //transition = GetComponent<AudioSource>();
        glitchTimer = glitchTime;
        amt = 1;
        StartCoroutine("FadeIn");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(DigitalGlitch g in glitches)
        {
            g.intensity = amt;
        }

        if (loading)
        {
            loadTimer += Time.deltaTime;
            if(loadTimer > 15f)
            {
                FindObjectOfType<LevelSaveDataController>().Save();
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    /// <summary>
    /// A coroutine used to transition to a given level.
    /// </summary>
    /// <param name="i">The build index of the level we are transitioning to.</param>
    /// <returns></returns>
    IEnumerator TransitionToLevel(int i)
    {
        transition.Play();

        loading = true;
        levelToLoad = i;

        while(glitchTimer > 0)
        {
            glitchTimer -= Time.deltaTime;
            amt = (1 - glitchTimer / glitchTime);
            yield return null;

        }

        FindObjectOfType<LevelSaveDataController>().Save();
        SceneManager.LoadScene(i);
    }

    IEnumerator FadeIn()
    {
        while(amt > 0)
        {
            amt -= Time.deltaTime / 2f;
            yield return null;
        }
    }
}
