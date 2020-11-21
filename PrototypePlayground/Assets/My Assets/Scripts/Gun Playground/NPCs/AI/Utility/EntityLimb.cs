using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityLimb : MonoBehaviour
{

    public float limbHealth;
    private EntityHealth entityHealth;
    [SerializeField]
    [Range(0, 2f)]
    private float damageMod;

    public UnityEvent hitEvents;
    private bool limbDeath;
    public UnityEvent deathEvents;
    public Vector3 incomingDamageDir;
    // Start is called before the first frame update
    void Start()
    {
        entityHealth = GetComponentInParent<EntityHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(limbHealth <= 0)
        {
            if (!limbDeath)
            {
                deathEvents.Invoke();
                limbDeath = true;
            }
        }
    }

    public void DamageEnemy(float f, Vector3 incomingDir)
    {
        limbHealth -= f * damageMod;
        entityHealth.Damage(f * damageMod);
        hitEvents.Invoke();
        incomingDamageDir = incomingDir;
    }
}
