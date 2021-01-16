using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4PCables : MonoBehaviour
{

    [SerializeField]
    private Transform home;
    private Vector3 originalPosition;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 phase;
    [SerializeField]
    private Vector3 size;
    private float scroll;

    [SerializeField]
    private Vector2 yRange;

    [SerializeField]
    private Vector2 phaseRange;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = new Vector3(home.localPosition.x, transform.localPosition.y - Random.Range(yRange.x, yRange.y), transform.localPosition.z);

        phase.x = Random.Range(phaseRange.x, phaseRange.y);
        phase.y = Random.Range(phaseRange.x, phaseRange.y);
        phase.z = Random.Range(phaseRange.x, phaseRange.y);
    }

    // Update is called once per frame
    void Update()
    {
        scroll += Time.deltaTime * speed;
        Vector3 offset = new Vector3(
            Mathf.Sin(scroll + phase.x) * size.x,
            Mathf.Cos(scroll + phase.y) * size.y,
            0);
        transform.localPosition = originalPosition + offset;
    }
}
