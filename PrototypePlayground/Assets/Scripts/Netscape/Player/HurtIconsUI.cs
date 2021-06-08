using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is what holds the references to the images that make up the four hurt icons indicating where the player is being hit from.
/// TODO: Convert the images to an array, having them be 4 separate variables is messy.
/// </summary>
public class HurtIconsUI : MonoBehaviour
{
    /// <summary>
    /// The image for the forward direction.
    /// </summary>
    [SerializeField]
    private Image forward;
    /// <summary>
    /// The image for the backward direction.
    /// </summary>
    [SerializeField]
    private Image backward;
    /// <summary>
    /// The image for the left direction
    /// </summary>
    [SerializeField]
    private Image left;
    //The image for the right direction
    [SerializeField]
    private Image right;
    //How fast an icon goes back down to being invisible after being activated
    [SerializeField]
    private float decaySpeed;
    /// <summary>
    /// This is a float determining a certain tolerance for the angle at which a player is being attacked. Some overlap is added to each direction so that if you are being attacked in a diagonal direction
    /// or damaged from all sides (like in an explosion), you will see more than one icon activate
    /// </summary>
    [SerializeField]
    private float directionToleranceRange;
    /// <summary>
    /// An aray holding each of the 4 alphas for each of the images
    /// </summary>
    [SerializeField]
    private float[] alphas = new float[4];

    /// <summary>
    /// The curve that the alpha uses when going back down to zero. Purely visual.
    /// </summary>
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

    /// <summary>
    /// Decreases each alpha in accordance to the decay speed over time to zero.
    /// </summary>
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

    /// <summary>
    /// Sets the alphas of each relevant image. 
    /// </summary>
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

    /// <summary>
    /// Thisa function takes a direction, and a transform representing the position the damage is coming from in order to make a decision on which alpha to set to one. 
    /// The dot product is used here to determine where damage is coming from.
    /// </summary>
    /// <param name="direction">The direction the damage is coming from</param>
    /// <param name="t">The transform of the thing causing the damage. This is given because sometimes, like with an explosion, you need to know where a grenade is giving you damage, and sometimes the damage is coming from an enemy, not strictly whatever they're firing.</param>
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
