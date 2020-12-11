using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EnemySpawnerGroupEntranceEffect
{
    None,
    DarkenDirectionalLightAndBurstSpawn
}

public class EnemySpawnerGroup : MonoBehaviour
{
    public BoxCollider groupVolume;
    [SerializeField] private EnemySpawnerGroupEntranceEffect entranceEffect;

    // the distance a spawner needs to be from an enemy or the player to be chosen to spawn
    [SerializeField] private float safeDistance = 2.5f;


    //DarkenDirectionalLightAndBurstSpawnState public data
    [SerializeField] private float lightFadeOutTime = 0.5f;
    [SerializeField] private float lightFadeHoldTime = 1.0f;
    [SerializeField] private float lightFadeInTime = 5.0f;
    [SerializeField] private AudioClip lightFadeOutSound;
    [SerializeField] private AudioClip lightFadeInSound;

    // public properties
    public int SpawnerCount => _spawners.Count;
    public bool IsRunningEntranceEffect { get; private set; }

    public bool CanSpawnEnemies { get; private set; } = false;

    public void Init(List<EnemySpawner> spawners)
    {
        // find all spawners inside our volume and cache them
        foreach (var spawner in spawners)
        {
            if (groupVolume.bounds.Contains(spawner.gameObject.transform.position))
            {
                _spawners.Add(spawner);
            }
        }
        ResetUnusedSpawners();
        //Debug.Log("number of spawners in group is" + spawners.Count);
    }

    public EnemySpawner GetRandomSpawner(bool distanceCheck = true)
    {
        if (!CanSpawnEnemies)
        {
            return null;
        }
        // TODO  when picking a spawner make sure it's not blocked by an enemy or the player
        if (_unusedSpawners.Count == 0)
        {
            ResetUnusedSpawners();
        }
        EnemySpawner spawner = null;
        if (!distanceCheck)
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            int attemptCount = _unusedSpawners.Count;
            while (attemptCount >= 0)
            {
                spawner = _unusedSpawners.ToArray()[Random.Range(0, _unusedSpawners.Count - 1)];
                bool goodSpawn = true;
                foreach (var enemy in enemies)
                {
                    float distance = Vector3.Distance(enemy.transform.position, spawner.transform.position);
                    if (distance < safeDistance)
                    {
                        goodSpawn = false;
                    }
                }
                if (goodSpawn)
                {
                    _unusedSpawners.Remove(spawner);
                    return spawner;

                }
                attemptCount--;
            }
        }
        else
        {
            spawner = _unusedSpawners.ToArray()[Random.Range(0, _unusedSpawners.Count - 1)];
            _unusedSpawners.Remove(spawner);
            return spawner;
        }

        return null;
    }

    private void ResetUnusedSpawners()
    {
        foreach (var itemToAdd in _spawners)
        {
            _unusedSpawners.Add(itemToAdd);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CanSpawnEnemies = true;
        if (!_hasStartedPlayingSpawnEntranceEffect)
        {
            _hasStartedPlayingSpawnEntranceEffect = true;
            switch (entranceEffect)
            {
                case EnemySpawnerGroupEntranceEffect.DarkenDirectionalLightAndBurstSpawn:
                    _darkenState = DarkenDirectionalLightAndBurstSpawnState.FadingOut;
                    _lightingFadeOutTimerCurrent = lightFadeOutTime;
                    _lightingFadeHoldTimerCurrent = lightFadeHoldTime;
                    _lightingFadeInTimerCurrent = lightFadeInTime;
                    if (lightFadeOutSound != null)
                    {
                        _darkenStateAudioSource.PlayOneShot(lightFadeOutSound);
                    }
                    break;
                case EnemySpawnerGroupEntranceEffect.None:
                default:
                    break;
            }
            if (entranceEffect != EnemySpawnerGroupEntranceEffect.None)
            {
                IsRunningEntranceEffect = true;
            }
        }
    }

    void Start()
    {
        var playerTest = FindObjectOfType<CyberSpaceFirstPerson>();
        if (playerTest == null)
        {
            Debug.LogError("Unable to get player ref");
        }
        else
        {
            _player = playerTest.gameObject;
        }

        _directionalLight = FindObjectsOfType<Light>().Where(x => x.type == LightType.Directional).SingleOrDefault();
        if (_directionalLight == null)
        {
            Debug.LogError("can't find single directional light, either missing or more than one");
        }
        else
        {
            _originalDirectionalLightIntensity = _directionalLight.intensity;
        }
    }

    void Update()
    {
        void HandleDarkenDirectionalLightAndBurstSpawn()
        {
            switch (_darkenState)
            {
                case DarkenDirectionalLightAndBurstSpawnState.Armed:
                    break;
                case DarkenDirectionalLightAndBurstSpawnState.FadingOut:
                    _lightingFadeOutTimerCurrent -= Time.deltaTime;
                    _directionalLight.intensity =
                        Mathf.Lerp(0.0f, _originalDirectionalLightIntensity, _lightingFadeOutTimerCurrent / lightFadeOutTime);
                    if (_lightingFadeOutTimerCurrent <= 0)
                    {
                        _darkenState = DarkenDirectionalLightAndBurstSpawnState.FadeHold;
                    }
                    break;
                case DarkenDirectionalLightAndBurstSpawnState.FadeHold:
                    _lightingFadeHoldTimerCurrent -= Time.deltaTime;
                    if (_lightingFadeHoldTimerCurrent <= 0)
                    {
                        _darkenState = DarkenDirectionalLightAndBurstSpawnState.FadingIn;
                        if (lightFadeInSound != null)
                        {
                            _darkenStateAudioSource.PlayOneShot(lightFadeInSound);
                        }
                    }
                    break;
                case DarkenDirectionalLightAndBurstSpawnState.FadingIn:
                    _lightingFadeInTimerCurrent -= Time.deltaTime;
                    _directionalLight.intensity =
                        Mathf.Lerp(_originalDirectionalLightIntensity, 0.0f, _lightingFadeInTimerCurrent / lightFadeInTime);
                    int numUniqueSpawnsLeft = _unusedSpawners.Count;
                    if (numUniqueSpawnsLeft > 0)
                    {
                        float interval = 1.0f / numUniqueSpawnsLeft;
                        if (_lightingFadeInTimerCurrent / lightFadeInTime < interval)
                        {
                            var spawn = GetRandomSpawner();
                            spawn.Spawn();
                        }
                    }
                    if (_lightingFadeInTimerCurrent <= 0)
                    {
                        _darkenState = DarkenDirectionalLightAndBurstSpawnState.Done;
                    }
                    break;
                case DarkenDirectionalLightAndBurstSpawnState.Done:
                    _hasCompletedPlayingSpawnEntranceEffect = true;
                    IsRunningEntranceEffect = false;
                    break;
            }
        };
        if (!_hasCompletedPlayingSpawnEntranceEffect)
        {
            switch (entranceEffect)
            {
                case EnemySpawnerGroupEntranceEffect.DarkenDirectionalLightAndBurstSpawn:
                    HandleDarkenDirectionalLightAndBurstSpawn();
                    break;
                case EnemySpawnerGroupEntranceEffect.None:
                default:
                    break;
            }
        }
    }

    private enum DarkenDirectionalLightAndBurstSpawnState
    {
        Armed,
        FadingOut,
        FadeHold,
        FadingIn,
        Done
    }

    private HashSet<EnemySpawner> _unusedSpawners = new HashSet<EnemySpawner>();
    private List<EnemySpawner> _spawners = new List<EnemySpawner>();
    private GameObject _player;
    private bool _hasStartedPlayingSpawnEntranceEffect = false;
    private bool _hasCompletedPlayingSpawnEntranceEffect = false;

    //DarkenDirectionalLightAndBurstSpawnState private data 
    private DarkenDirectionalLightAndBurstSpawnState _darkenState = DarkenDirectionalLightAndBurstSpawnState.Armed;
    private Light _directionalLight = null;
    private float _originalDirectionalLightIntensity = 0.0f;
    private float _lightingFadeOutTimerCurrent = 0.0f;
    private float _lightingFadeHoldTimerCurrent = 0.0f;
    private float _lightingFadeInTimerCurrent = 0.0f;
    private AudioSource _darkenStateAudioSource = new AudioSource();
}