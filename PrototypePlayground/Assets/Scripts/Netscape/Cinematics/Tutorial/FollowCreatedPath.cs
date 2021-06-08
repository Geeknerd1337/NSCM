using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.Video;
public class FollowCreatedPath : MonoBehaviour
{
    public Transform robot;
    public Transform c4p; 
    #region Private Memebers
    private PathCreator path;
    private CyberSpaceFirstPerson player;
    #endregion



    [SerializeField]
    [Range(0,0.99f)]
    private float position;
    [SerializeField]
    private float speed;
    private float actualPostion;

    [Header("C4P Visual Flair")]
    [SerializeField] private float bobSpeed;
    [SerializeField] private Vector3 bobAmt;
    private Vector3 originalLocalPosition;
    private Vector3 perlinScroll;


    public VideoClip[] videoClips;
    [SerializeField]
    private VideoPlayer vidPlayer;

    public GameObject g;

    
    // Start is called before the first frame update
    void Start()
    {
        //Get the path
        path = GetComponent<PathCreator>();
        //Find The Player
        player = FindObjectOfType<CyberSpaceFirstPerson>();
        //Get original position of C4P in local space
        originalLocalPosition = c4p.localPosition;
        position = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRobotPosition();
        UpdateBob();
    }

    void UpdateRobotPosition()
    {
        actualPostion = Mathf.Lerp(actualPostion, position, SmoothStep(speed * Time.deltaTime));
        robot.transform.position = path.path.GetPointAtTime(actualPostion);
        robot.transform.LookAt(player.transform.position + Vector3.up * 0.2f);

    }

    float SmoothStep(float t)
    {
        t = t * t * t * (t * (6f * t - 15f) + 10f);
        return t;
    }

    void UpdateBob()
    {
        perlinScroll += Vector3.one * Time.deltaTime * bobSpeed;
        Vector3 posOffset = new Vector3(
            Mathf.PerlinNoise(perlinScroll.x, 0.1f) * bobAmt.x,
            Mathf.PerlinNoise(perlinScroll.y, 0.2f) * bobAmt.y,
            Mathf.PerlinNoise(perlinScroll.z, 0.3f) * bobAmt.z
            );
        c4p.localPosition = originalLocalPosition + posOffset;

    }

    public void SetPosition(float f)
    {
        position = f;
    }

    public void SetPoint(int i)
    {
        Debug.DrawRay(transform.TransformPoint(path.bezierPath.GetPoint(i * 3)), Vector3.up * 10f);
        //Debug.Break();
        position = path.path.GetClosestTimeOnPath(transform.TransformPoint(path.bezierPath.GetPoint(i * 3)));
    }

    public void PlayVideoClip(int i)
    {
        vidPlayer.Stop();
        vidPlayer.clip = videoClips[i];
        vidPlayer.Play();
    }

    public void PlayVideoClipDelay(int i)
    {
        StartCoroutine(PlayDelayedVideo(i, 1f));
    }

    public IEnumerator PlayDelayedVideo(int i, float f)
    {
        while(f > 0)
        {
            f -= Time.deltaTime;
            yield return null;
        }

        if(f <= 0)
        {
            vidPlayer.Stop();
            vidPlayer.clip = videoClips[i];
            vidPlayer.Play();
        }
    }
}
