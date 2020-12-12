using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEvent : MonoBehaviour
{
    public float time;
    private float totalTime;
    private bool started = false;
    private bool ended;
    public Renderer r;
    public int matIndex;
    private Material m;
    public GlitchControl gc;
    public int levelToLoad = 1;
    // Start is called before the first frame update
    void Start()
    {
        totalTime = time;
        m = r.materials[matIndex];
        gc = FindObjectOfType<GlitchControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            time -= Time.deltaTime;
            float value = time / totalTime;
            value = Mathf.Floor(value * 20f) / 20f;
            m.SetFloat("_amt", 1 - value);
            if(!ended && time <= 0)
            {
                gc.StartCoroutine("TransitionToLevel", levelToLoad);
                ended = true;
            }
        }
    }

    public void StartThisThing()
    {
        started = true;
    }
}
