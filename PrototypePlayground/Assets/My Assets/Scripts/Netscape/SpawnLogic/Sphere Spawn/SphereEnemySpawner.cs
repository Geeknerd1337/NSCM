using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This is the newer version of the enemy spawner. This is what is used to not only control the effect, but the spawning of enemies. Intended to be a less flashy, faster, and less obnoxious
/// version of the giant spawn beam that existed previously.
/// </summary>
public class SphereEnemySpawner : MonoBehaviour
{

    /// <summary>
    /// The transform of the sphere
    /// </summary>
    [Header("Spawn Effect")]
    [SerializeField]
    private Transform sphereTransform;
    /// <summary>
    /// The renderer for the sphere transform
    /// </summary>
    private Renderer sphereRenderer;
    /// <summary>
    /// The material for the sphere renderer.
    /// </summary>
    private Material sphereMaterial;


    /// <summary>
    /// Reference to the particle system that is around the central sphere
    /// </summary>
    [SerializeField]
    private ParticleSystem centralLightning;

    /// <summary>
    /// Reference to a light centered on the sphere
    /// </summary>
    [SerializeField]
    private Light centralLight;

    /// <summary>
    /// Float value between zero and one that determines the progress of the effect animation
    /// </summary>
    [SerializeField]
    [Range(0, 1)]
    private float sphereProgress;

    /// <summary>
    /// An animation curve denoting the progression of the vertical displacement
    /// </summary>
    [SerializeField]
    private AnimationCurve verticalDisplacementCurve;

    /// <summary>
    /// An animation curve denoting the progression of the sphere size
    /// </summary>
    [SerializeField]
    private AnimationCurve sphereSizeCurve;

    /// <summary>
    /// An animation curve denoting the progression of the size of the central particle system
    /// </summary>
    [SerializeField]
    private AnimationCurve centralPartSizeCurve;

    /// <summary>
    /// An animation curve denoting the progression of the intensity of the central light
    /// </summary>
    [SerializeField]
    private AnimationCurve centralLightCurve;

    /// <summary>
    /// The point at whiich lightning beams start spawning
    /// </summary>
    [SerializeField]
    private float lightningStartPoint;

    private bool lightningSpawned;


    [Header("EnemySpawning")]
    [SerializeField]
    private GameObject enemyObject;
    [SerializeField]
    private ParticleSystem enemySpawn;
    [SerializeField]
    private float spawnTime;
    private bool isSpawning;

    /// <summary>
    /// This is the number of rays we are going to attempt to find directions for so that the lightning can connect to the ground, this way it only collects to physical things.
    /// </summary>
    [Header("Lightning")]
    [SerializeField]
    private int rayCount;
    /// <summary>
    /// The range of each ray
    /// </summary>
    [SerializeField]
    private float rayRange;
    /// <summary>
    /// Layer mask so we can decide what it hits
    /// </summary>
    [SerializeField]
    private LayerMask lm;
    /// <summary>
    /// This holds all our line renders for the actual lightning effect
    /// </summary>
    [SerializeField]
    private List<LineRenderer> lines;

    


    // Start is called before the first frame update
    void Start()
    {
        
        sphereRenderer = sphereTransform.gameObject.GetComponent<Renderer>();
        sphereMaterial = sphereRenderer.material;
        StopSpawn();
    }


    void StopSpawn()
    {
        centralLight.enabled = false;
        sphereRenderer.enabled = false;
        ResetLines();
        sphereProgress = 0;
        isSpawning = false;
    }

    public void StartSpawn()
    {
        if (!isSpawning)
        {
            centralLight.enabled = true;
            sphereRenderer.enabled = true;
            isSpawning = true;
        }
    }

    void SpawnEnemy()
    {
        enemySpawn.Play();
        GameObject g = Instantiate(enemyObject);

        NavMeshAgent agent = g.GetComponent<NavMeshAgent>();
        if(agent == null)
        {
            agent = g.GetComponentInChildren<NavMeshAgent>();
        }
        if(agent != null)
        {
            agent.Warp(transform.position);
        }
    }

    /// <summary>
    /// Function that 'disappears' the lines when no longer needed.
    /// </summary>
    void ResetLines()
    {
        foreach(LineRenderer r in lines)
        {

            r.SetPosition(0, Vector3.zero);
            r.SetPosition(1, Vector3.one);
        }
    }

    void SetLine()
    {
        List<Vector3> positions = GetRayPositions();
        int lesser = Mathf.Min(lines.Count, positions.Count);

        for(int i = 0; i < lesser; i++)
        {
            LineRenderer r = lines[i];
            r.SetPosition(0, sphereTransform.position);
            r.SetPosition(1, positions[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawner();
        if (isSpawning)
        {
            sphereProgress += Time.deltaTime / spawnTime;

            if(sphereProgress >= 1)
            {
                SpawnEnemy();
                StopSpawn();
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            StartSpawn();
        }
    }

    void UpdateSpawner()
    {
        if (sphereMaterial != null)
        {
            sphereMaterial.SetFloat("_upwardDisp", verticalDisplacementCurve.Evaluate(sphereProgress));
            sphereMaterial.SetFloat("_size", sphereSizeCurve.Evaluate(sphereProgress));
        }
        centralLightning.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 2.5f, centralPartSizeCurve.Evaluate(sphereProgress));

        centralLight.range = Mathf.Lerp(0,10f,centralLightCurve.Evaluate(sphereProgress));

        if(sphereProgress > lightningStartPoint)
        {
            SetLine();
            lightningSpawned = true;
            lightningStartPoint += 0.05f;
        }
    }


    /// <summary>
    /// This is what is used to get the end points for the lightning renderers
    /// </summary>
    /// <returns></returns>
    List<Vector3> GetRayPositions()
    {
        List<Vector3> list = new List<Vector3>();
        for(int i = 0; i < rayCount; i++)
        {
            RaycastHit hit;
            Vector3 dir = Random.insideUnitSphere.normalized;
            if(Physics.Raycast(sphereTransform.position,dir,out hit, rayRange, lm))
            {
                list.Add(hit.point);
            }
        }

        return list;
    }

}
