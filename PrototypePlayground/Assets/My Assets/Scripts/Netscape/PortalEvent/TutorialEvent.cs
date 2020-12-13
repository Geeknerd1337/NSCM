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

    public List<SpawnWave> waves;
    private int waveIndex;

    public Material mm;
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
            SpawnWaves();
            if(!ended && time <= 0)
            {
                gc.StartCoroutine("TransitionToLevel", levelToLoad);
                ended = true;
            }
        }
    }


    void SpawnWaves()
    {
        if(waves.Count == 0)
        {
            return;
        }
        if(waveIndex >= waves.Count)
        {
            return;
        }

        SpawnWave wave = waves[waveIndex];
        float value = time / totalTime;
        value = 1 - value;

        if (value > wave.whenToSpawn)
        {
            foreach(EnemySpawner e in wave.spawners)
            {
                e.Spawn();
                
            }
            waveIndex++;
        }
    }

    public void StartThisThing()
    {
        started = true;
        if (mm != null)
        {
            r.materials[matIndex] = mm;
        }
    }
}

[System.Serializable]
public class SpawnWave
{
    public float whenToSpawn;
    public EnemySpawner[] spawners;
}
