using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using EZCameraShake;

public class FriendlyNPC : MonoBehaviour
{
    #region Private Members
    private NavMeshAgent agent;
    private Animator friendlyAnimator;
    #endregion

    [SerializeField]
    private Transform target;

    [SerializeField]
    public bool runningCircle;

    [Header("Running In Circle")]
    public List<Transform> circlePoints;
    [SerializeField]
    private int circleIndex;
    public Animator a;
    public AudioSource sound;
    public AudioClip jumpSound;
    public AudioClip walkSound;
    private float jumpTimer;

    public Transform armature;
    public float rotSpd;
    private float myY;

    [Header("First Line")]
    public float firstLineDelay;
    public bool firstLineStarted;
    public bool stopped;

    [Header("Second Line")]
    [SerializeField]
    private bool secondLineStarted;
    public List<Transform> secondPointList;
    public float secondLineDelay;
    private bool secondLinePlayed;

    [Header("Third Line")]
    [SerializeField]
    private bool thirdLineStarted;

    [Header("Fourth Line")]
    [SerializeField]
    private bool fourthLineStarted;
    public float fourthLineDelay;
    private bool fourthPlayed;
    private bool setCheats;
    public GameObject cheats;
    public GameObject give;
    public float cheatDelay;
    public GameObject gun;
    public Animator gunAnim;
    public AudioSource gunEquip;
    public AudioSource portalAmbience;
    public GameObject netScapeDoor;
    public AudioSource portalSpawn;
    public GlitchEffectCinematic glitchEffect;


    [Header("Dialog Stuff")]
    public AudioClip[] clips;
    public AudioSource dialogSource;
    public Transform player;
    public Transform speaker;
    public GameObject speakerObj;
    public GameObject UIElement;
    private Quaternion originalArmatureRotation;
    public Collider col;
    private bool bb;


    // Start is called before the first frame update
    void Start()
    {
        //Get The Agent;
        agent = GetComponent<NavMeshAgent>();
        //Get the Animator
        friendlyAnimator = GetComponent<Animator>();
        a = GetComponent<Animator>();
        //GoToCurrentTarget();

        jumpTimer = Random.Range(1f, 3f);
        myY = armature.eulerAngles.y;
        originalArmatureRotation = Quaternion.Euler(-90f, 0, 0); ;

        cheats.SetActive(false);
        give.SetActive(false);
        gun.SetActive(false);
        netScapeDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAI();
    }

    private void LateUpdate()
    {
        if (runningCircle && !secondLineStarted)
        {
            RotateToTargetSmooth(circlePoints[circleIndex], rotSpd);
        }

        if (thirdLineStarted)
        {
            RotateToTargetSmooth(player, rotSpd);
        }

    }

    void ResetArmatureRotation()
    {
        armature.localRotation = originalArmatureRotation;
    }

    void UpdateAI()
    {

        //Basically check if the agent is moving
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            friendlyAnimator.SetBool("IsWalking", false);
        }
        else
        {
            friendlyAnimator.SetBool("IsWalking", true);
        }


        if (runningCircle)
        {
            TravelCircle();
            friendlyAnimator.SetBool("IsWalking", true);
        }

        FirstLine();
        TravelPoints();
        FourthLine();
        UpdateObjects();

        Debug.Log(dialogSource.clip + " " + clips[4] + " " + dialogSource.isPlaying);
        if(bb && !dialogSource.isPlaying)
        {
            col.enabled = false;
        }
    }

    void GoToCurrentTarget()
    {
        agent.SetDestination(target.position);
    }

    void MoveSpeaker()
    {
        speaker.LookAt(player);
    }


    void UpdateObjects()
    {
        if (dialogSource.isPlaying)
        {
            UIElement.SetActive(true);
            speakerObj.SetActive(true);
        }
        else
        {
            UIElement.SetActive(false);
            speakerObj.SetActive(false);
        }
        MoveSpeaker();
    }

    void TravelCircle()
    {
        Transform currPoint = circlePoints[circleIndex];
        if (agent.remainingDistance < 0.3f)
        {
            agent.SetDestination(currPoint.position);
            circleIndex++;
            if (circleIndex >= circlePoints.Count - 1)
            {
                circleIndex = 0;
            }
          
        }

        jumpTimer -= Time.deltaTime;
        if(jumpTimer <= 0)
        {
            //sound.PlayOneShot(jumpSound);
            //a.Play("Armature|Jump");
            jumpTimer = Random.Range(1f, 3f);
           // Vector3 t = transform.position;
        }

        if (a.GetCurrentAnimatorStateInfo(0).IsName("Armature|Jump"))
        {
            agent.speed = 10f;
        }
        else
        {
            agent.speed = 5f;
            sound.PlayOneShot(jumpSound);
            a.Play("Armature|Jump");
        }
    }


    void TravelPoints()
    {
        if (!secondLineStarted || thirdLineStarted)
        {
            return;
        }

        if (!secondLinePlayed)
        {
            secondLineDelay -= Time.deltaTime;
            if(secondLineDelay <= 0)
            {
                dialogSource.PlayOneShot(clips[1]);
                secondLinePlayed = true;
            }
        }

        Transform currPoint = secondPointList[circleIndex];
        if (agent.remainingDistance < 0.3f)
        {
            
            if (circleIndex >= secondPointList.Count - 1)
            {

                    dialogSource.PlayOneShot(clips[2]);
                    thirdLineStarted = true;
            }
            else
            {
                agent.SetDestination(currPoint.position);
                circleIndex++;
            }

        }
    }


    void FourthLine()
    {
        if (thirdLineStarted)
        {
            if (!dialogSource.isPlaying)
            {
                fourthLineStarted = true;
            }
        }
        if (!fourthLineStarted)
        {
            return;
        }

        fourthLineDelay -= Time.deltaTime;
        if(fourthLineDelay <= 0)
        {
            if (!fourthPlayed)
            {
                netScapeDoor.SetActive(true);
                CameraShakeInstance c = new CameraShakeInstance(0.5f, 20, 0f, 0.5f);
                c.PositionInfluence = Vector3.one * 1f;
                c.RotationInfluence = new Vector3(4, 1, 1);
                CameraShaker.Instance.Shake(c);
                dialogSource.PlayOneShot(clips[3]);
                portalAmbience.Play();
                portalSpawn.Play();
                glitchEffect.Jump();
                fourthPlayed = true;
            }
        }

        if (fourthPlayed)
        {
            if (!dialogSource.isPlaying)
            {
                if (!setCheats)
                {
                    cheats.SetActive(true);
                    cheatDelay -= Time.deltaTime;
                    if(cheatDelay <= 0)
                    {
                        //Where the multigun is actually "given"
                        give.SetActive(true);
                        gun.SetActive(true);
                        gunAnim.Play("Hands|cinematic_draw");
                        dialogSource.PlayOneShot(clips[4]);
                        gunEquip.Play();
                        setCheats = true;
                        bb = true;
                        
                    }
                }
            }
        }
    }

    void RotateToTarget(Transform t)
    {
        Vector3 dir = (t.position - armature.position);
        Quaternion q = Quaternion.LookRotation(dir.normalized);
        Vector3 euler = q.eulerAngles;
        armature.transform.eulerAngles = new Vector3(-90f, euler.y, 0);
    }

    void RotateToTargetSmooth(Transform t,float f)
    {
        Vector3 dir = (t.position - armature.position);
        Quaternion q = Quaternion.LookRotation(dir.normalized);
        Vector3 euler = q.eulerAngles;
        myY = Mathf.LerpAngle(myY, euler.y, f * Time.deltaTime);
        armature.transform.eulerAngles = new Vector3(-90f, myY, 0);

    }

    void FirstLine()
    {
        if (firstLineStarted)
        {
            if (runningCircle)
            {
                firstLineDelay -= Time.deltaTime;
                if(firstLineDelay <= 0)
                {
                    runningCircle = false;
                }
            }
            else
            {
                if (!secondLineStarted)
                {
                    RotateToTargetSmooth(player, rotSpd);
                }
                if (!stopped)
                {
                    agent.SetDestination(transform.position);
                    stopped = true;
                    dialogSource.PlayOneShot(clips[0]);
                }
                else
                {
                    if (!secondLineStarted)
                    {
                        if (!dialogSource.isPlaying)
                        {
                            circleIndex = 0;
                            //dialogSource.clip = clips[1];
                            //dialogSource.PlayScheduled(AudioSettings.dspTime + 5f);
                            agent.speed = 2.5f;
                            ResetArmatureRotation();
                            Debug.Log(armature.localEulerAngles);
                            myY = 0;
                            secondLineStarted = true;
                        }
                    }
                }
            }
        }
    }

    public void StartFirstLine()
    {
        firstLineStarted = true;
    }
}
