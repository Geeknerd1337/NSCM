using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// This class is used to control an image that covers the screen. You can decide the color, duration, whether or not to play a sound.
/// This can be used for things like fades, 
/// </summary>
public class ScreenCover : MonoBehaviour
{

    /// <summary>
    /// The reference to our audio source, used for playing sounds.
    /// </summary>
    private AudioSource coverSource;


    /// <summary>
    /// The actual sound file we want to play when covering the screen
    /// </summary>
    [SerializeField]
    private AudioClip coverClip;

    /// <summary>
    /// A reference to the transform we are spawning this image in
    /// </summary>
    private Transform canvas;

    /// <summary>
    /// This is a boolean storing whether or not this object will activate when the player enters a collider attached to this object
    /// </summary>
    [SerializeField]
    private bool isTrigger;
    private bool triggered;

    /// <summary>
    /// The color of the cover we are putting over the screen
    /// </summary>
    [SerializeField]
    private Color coverColor;

    /// <summary>
    /// How long, in seconds, the cover needs to last
    /// </summary>
    [SerializeField]
    private float coverTime;

    /// <summary>
    /// An animation curve representing how the curve fades out
    /// </summary>
    [SerializeField]
    private AnimationCurve coverCurve;

    /// <summary>
    /// An event that will be invoked when the cover finishes
    /// </summary>
    [SerializeField]
    private UnityEvent coverEvents;


    // Start is called before the first frame update
    void Start()
    {
        //TODO: Convert UI to global scope
        canvas = FindObjectOfType<UIMaster>().transform;
        //Get the audio source
        coverSource = GetComponent<AudioSource>();

    }

    /// <summary>
    /// A coroutine that physically creates, then covers the screen with the image;
    /// </summary>
    /// <returns></returns>
    public IEnumerator Cover()
    {
        //A timer variable
        float timer = 0;

        //Create the cover
        GameObject imageObj = new GameObject();
        Image image = imageObj.AddComponent<Image>();
        RectTransform rt = imageObj.GetComponent<RectTransform>();
        rt.SetParent(canvas);
        rt.sizeDelta = new Vector2(4096, 4096);
        rt.position = new Vector3(1920 / 2f, 1080 / 2f, 0);
        rt.transform.SetAsLastSibling();

        //Destroy after the fade time plus two frames
        Destroy(imageObj, coverTime + (1 / 30f));

        if(coverClip != null && coverSource != null)
        {
            coverSource.PlayOneShot(coverClip);
        }

        //Set the color of the image
        Color imageColor = coverColor;
        image.color = imageColor;

        //Make the image alpha match the cover curve until the end
        while(timer < coverTime)
        {
            timer += Time.deltaTime;
            imageColor.a = coverCurve.Evaluate(timer / coverTime);

            image.color = imageColor;

            yield return null;
        }

        coverEvents.Invoke();


    }

    /// <summary>
    /// Public method used for starting the cover;
    /// </summary>
    public void StartCover()
    {
        StartCoroutine(Cover());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && isTrigger && !triggered)
        {
            StartCoroutine(Cover());
            triggered = true;
        }
    }


}
