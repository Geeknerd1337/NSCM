using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Kino;
public class GlitchControl : MonoBehaviour
{

    public DigitalGlitch[] glitches;
    [Range(0, 1)]
    public float amt = 0;

    public float glitchTime;
    private float glitchTimer;
    public AudioSource transition;

    private bool loading;
    private float loadTimer;
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
