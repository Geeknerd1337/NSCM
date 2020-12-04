using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DogAnimControl : MonoBehaviour
{

    public Animator a;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = agent.velocity.magnitude / agent.speed;
        velocity = Mathf.Clamp01(velocity);
        a.SetFloat("WalkBlend", velocity);
    }
}
