using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtIconsUI : MonoBehaviour
{
    [SerializeField]
    private Image forward;
    [SerializeField]
    private Image backward;
    [SerializeField]
    private Image left;
    [SerializeField]
    private Image right;
    [SerializeField]
    private float decaySpeed;
    [SerializeField]
    private float directionToleranceRange;
    [SerializeField]
    private float[] alphas = new float[4];

    public AnimationCurve alphaCurve;
    
    // Start is called before the first frame update
    void Start()
    {

        for(int i =0; i < alphas.Length; i++)
        {
            alphas[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BringAlphasDown();
        SetAlphas();
    }

    void BringAlphasDown()
    {
        for (int i = 0; i < alphas.Length; i++)
        {
            if (alphas[i] > 0)
            {
                alphas[i] -= Time.deltaTime * decaySpeed;
            }
            alphas[i] = Mathf.Clamp01(alphas[i]);
        }
    }

    void SetAlphas()
    {
        Color c = forward.color;
        c.a = alphaCurve.Evaluate(alphas[0]);
        forward.color = c;

        c = backward.color;
        c.a = alphaCurve.Evaluate(alphas[1]);
        backward.color = c;

        c = left.color;
        c.a = alphaCurve.Evaluate(alphas[2]);
        left.color = c;

        c = right.color;
        c.a = alphaCurve.Evaluate(alphas[3]);
        right.color = c;
    }

    public void AlertPlayer(Vector3 direction,Transform t)
    {
        //Front
        float dot = Vector3.Dot(direction, t.forward);
        if(dot > directionToleranceRange)
        {
            alphas[0] = 1f;
        }

        //Back
        dot = Vector3.Dot(direction, t.forward * -1f);
        if (dot > directionToleranceRange)
        {
            alphas[1] = 1f;
        }
        //Left
        dot = Vector3.Dot(direction, t.right * -1f);
        if (dot > directionToleranceRange)
        {
            alphas[2] = 1f;
        }

        dot = Vector3.Dot(direction, t.right);
        if (dot > directionToleranceRange)
        {
            alphas[3] = 1f;
        }

    }
}
