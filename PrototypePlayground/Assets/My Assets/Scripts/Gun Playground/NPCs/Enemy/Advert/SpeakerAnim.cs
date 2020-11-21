using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerAnim : MonoBehaviour
{
    private Vector3 initialPosition;
    [SerializeField]
    private Vector3 animSpeed;
    [SerializeField]
    public float animAmount;
    private Vector3 animScroll;
    [SerializeField]
    private Vector3 animAmounts;
    [SerializeField]
    [Range(-0.2f,0.2f)]
    private float anger;
    [SerializeField]
    private float angerRange;
    [SerializeField]
    private float right;
    private float phase;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
        phase = Random.Range(-10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {

        float angerRemap = Remap(angerRange, -0.2f, 0.2f, 1, 2);
        animScroll.x += Time.deltaTime * animSpeed.x * angerRemap;
        animScroll.y += Time.deltaTime * animSpeed.y * angerRemap;
        animScroll.z += Time.deltaTime * animSpeed.z * angerRemap;   
        float p1 = Mathf.Sin(animScroll.x + phase);
        float p2 = Mathf.Sin(animScroll.y + phase);
        float p3 = Mathf.Sin(animScroll.z + phase);
        p1 = p1 * animAmounts.x;
        p2 =  p2 * animAmounts.y;
        p3 =  p3 * animAmounts.z;
        Vector3 v = new Vector3(p1,p2,p3) * animAmount;
        transform.localPosition = initialPosition + v + ((transform.up + (transform.right * right)).normalized * anger) * angerRange;
    }

    private void LateUpdate()
    {
        
    }

    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}



