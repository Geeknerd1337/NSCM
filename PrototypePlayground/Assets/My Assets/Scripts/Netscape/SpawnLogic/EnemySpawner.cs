using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private enum SpawnerState
    {
        Ready,
        Spawning_Anim_Phase01,
        Spawning_Anim_Phase02,
        Unavailable
    }

    

    public GameObject enemyPrefabToSpawn;
    public int level = 1;
    public GameObject spawnEffectMesh;
    public GameObject spawnEffectMeshRaisedPosition;
    public float spawnEffectPhase01Time = 2.0f;
    public float spawnEffectPhase02Time = 2.0f;
    public float spawnEffectScaleGrowthVelocity = 2.0f;
    public Light spawnLight;
    public float spawnLightRangeMultiplier = 2.0f;
    public float spawnLightIntensityMultiplier = 2.0f;
    public Renderer r;
    public int matIndex;
    private Material spawnMaterial;
    public float dissolveSpeed;
    public void Spawn()
    {
        _spawnerState = SpawnerState.Spawning_Anim_Phase01;
        spawnMaterial = r.materials[matIndex];
        spawnEffectMesh.SetActive(true);
        _currentSpawnEffectPhase01Time = spawnEffectPhase01Time;
        spawnEffectMesh.transform.position = _raisedlMeshPosition;
        spawnEffectMesh.transform.localScale = _originalMeshScale;

        spawnLight.gameObject.SetActive(true);
        spawnLight.intensity = _originalLightIntensity;
        spawnLight.range = _originalLightRange;
        spawnMaterial.SetFloat("_dissolveAmt", 0);

        spawnEffectMesh.SetActive(true);
    }

    void Start()
    {
        spawnEffectMesh.SetActive(false);
        _originalMeshPosition = spawnEffectMesh.transform.position;
        var effectMeshPosition = spawnEffectMesh.transform.position;
        effectMeshPosition.y = spawnEffectMeshRaisedPosition.transform.position.y;
        _raisedlMeshPosition = effectMeshPosition;
        _originalMeshScale = spawnEffectMesh.transform.localScale;
        
        spawnLight.gameObject.SetActive(false);
        _originalLightIntensity = spawnLight.intensity;
        _originalLightRange = spawnLight.range;
    }

    void Update()
    {
        if (_spawnerState == SpawnerState.Spawning_Anim_Phase01)
        {
            _currentSpawnEffectPhase01Time -= Time.deltaTime;
            Vector3 newPosition = Vector3.Lerp
                (_raisedlMeshPosition, _originalMeshPosition, 1 - _currentSpawnEffectPhase01Time / spawnEffectPhase01Time);
            spawnEffectMesh.transform.position = newPosition;

            float amt = _currentSpawnEffectPhase01Time / spawnEffectPhase01Time;
            amt = Mathf.Clamp01(amt);
            spawnMaterial.SetFloat("_amount", amt);


            if (_currentSpawnEffectPhase01Time <= 0)
            {
                _spawnerState = SpawnerState.Spawning_Anim_Phase02;
                _currentSpawnEffectPhase02Time = spawnEffectPhase02Time;
            }
        }
        if (_spawnerState == SpawnerState.Spawning_Anim_Phase02)
        {
            var normalizedTime = _currentSpawnEffectPhase02Time / spawnEffectPhase02Time;
            _currentSpawnEffectPhase02Time -= Time.deltaTime;
            Vector3 scale = spawnEffectMesh.transform.localScale;
            scale.x += spawnEffectScaleGrowthVelocity * Time.deltaTime;
            scale.z += spawnEffectScaleGrowthVelocity * Time.deltaTime;
            spawnEffectMesh.transform.localScale = scale;

            spawnLight.intensity = Mathf.Lerp(
                    _originalLightIntensity * spawnLightIntensityMultiplier,
                    _originalLightIntensity,
                    normalizedTime);
            spawnLight.range = Mathf.Lerp(
                _originalLightRange * spawnLightRangeMultiplier,
                _originalLightRange,
                normalizedTime);

            if (_currentSpawnEffectPhase02Time <= 0)
            {
                _spawnerState = SpawnerState.Ready;
                Instantiate(enemyPrefabToSpawn, gameObject.transform.position, gameObject.transform.rotation);
                StartCoroutine("Dissolve");
                //spawnEffectMesh.SetActive(false);
                spawnLight.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator Dissolve()
    {
        Debug.Log("HELLO");
        while (spawnMaterial.GetFloat("_dissolveAmt") < 1)
        {

            spawnMaterial.SetFloat("_dissolveAmt",spawnMaterial.GetFloat("_dissolveAmt") + dissolveSpeed * Time.deltaTime);
            
            yield return null; 
        }
    }




    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }

    private float _currentSpawnEffectPhase01Time = 0.0f;
    private float _currentSpawnEffectPhase02Time = 0.0f;
    private SpawnerState _spawnerState = SpawnerState.Ready;
    private Vector3 _originalMeshPosition;
    private Vector3 _raisedlMeshPosition;
    private Vector3 _originalMeshScale;
    private float _originalLightIntensity;
    private float _originalLightRange;
}