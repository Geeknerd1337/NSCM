using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityHealth : MonoBehaviour
{
    private AIEntity controller;
    private bool dead;

    [Header("Ragdoll Physics")]
    private Rigidbody[] ragdoll;

    [Header("Health")]
    [SerializeField]
    private float health;
    public float maxHealth;

    [Header("Death Events")]
    [SerializeField]
    private UnityEvent deathEvents;
    public List<MonoBehaviour> componentsToDisable;

    public bool IsDead => dead;

    public float Health
    {
        get { return health; }
    }

    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in ragdoll)
        {
            rb.isKinematic = true;
        }
        health = maxHealth;
        controller = GetComponent<AIEntity>();
        dead = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            if (!dead)
            {
                dead = true;
                ActivateRagdoll();
                deathEvents.Invoke();
            }
        }
    }

    void ActivateRagdoll()
    {
        if (controller != null)
        {
            controller.Agent.enabled = false;
            controller.enabled = false;
        }
        foreach (Rigidbody rb in ragdoll)
        {
            rb.isKinematic = false;
        }
        foreach(MonoBehaviour component in componentsToDisable)
        {
            component.enabled = false;
        }
    }

    public void Damage(float h)
    {
        health -= h;
    }
}
