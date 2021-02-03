using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;
using UnityStandardAssets.Characters.FirstPerson;



[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class CyberSpaceFirstPerson : MonoBehaviour
{
    [SerializeField] private bool m_IsWalking;
    [SerializeField] private float m_WalkSpeed;
    [SerializeField] private float m_RunSpeed;
    [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
    [SerializeField] private float m_JumpSpeed;
    [SerializeField] private float m_StickToGroundForce;
    [SerializeField] private float m_GravityMultiplier;
    [SerializeField] private MouseLook m_MouseLook;
    [SerializeField]
    public float m_MouseLook_x
    {
        get { return m_MouseLook.yAdjust; }
        set { m_MouseLook.yAdjust = value; }
    }
    [SerializeField] private bool m_UseFovKick;
    [SerializeField] private FOVKick m_FovKick = new FOVKick();
    [SerializeField] private bool m_UseHeadBob;
    [SerializeField] private CurveControlledBob m_HeadBob = new CurveControlledBob();
    [SerializeField] private LerpControlledBob m_JumpBob = new LerpControlledBob();
    [SerializeField] private float m_StepInterval;
    [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
    [SerializeField] private AudioClip m_JumpSound;           // the sound played when character leaves the ground.
    [SerializeField] private AudioClip m_LandSound;           // the sound played when character touches back on ground.
    [SerializeField] private float m_dashTime;
    private float dashTimer = 0f;
    [SerializeField] private Vector3 m_DashDrag;
    [SerializeField] private float m_DashSpeed;
    [SerializeField] private AudioClip m_DashSound;

    private Camera m_Camera;
    private bool m_Jump;
    private float m_YRotation;
    private Vector2 m_Input;
    private Vector3 m_MoveDir = Vector3.zero;
    private CharacterController m_CharacterController;
    private CollisionFlags m_CollisionFlags;
    private bool m_PreviouslyGrounded;
    private Vector3 m_OriginalCameraPosition;
    private float m_StepCycle;
    private float m_NextStep;
    private bool m_Jumping;
    private AudioSource m_AudioSource;
    public Vector3 AddDirVector;
    public float dirVectorSpeed;
    private Vector3 dirVector;
    [SerializeField] private AudioSource m_DashSource;

    [Header("Double Jump")]
    [SerializeField] private float m_doublejump_speed;
    [SerializeField] private bool m_doublejump;
    [SerializeField] private bool can_doublejump;
    [SerializeField] private float doubleJumpDelay;
    [SerializeField] private float doubleJumpTimer;
    private bool m_doublejumping;
    [SerializeField]
    private AudioClip doubleJumpClip;

    [Header("Grappling Hook")]
    [SerializeField] private Vector3 grapplePosition;
    [SerializeField] private bool grappling;
    public bool IsGrappling
    {
        get { return grappling; }
        set { grappling = value; }
    }
    public Vector3 GrapplePosition { set { grapplePosition = value; } }
    [SerializeField] private float grappleSpeed;
    [SerializeField] private float initialGrappleSpeed;
    [SerializeField] private float maxGrappleSpeed;
    [SerializeField] private float grappleAcceleration;
    [SerializeField] private float grappleGravityModifier;
    [SerializeField] private float grappleCutDistance;
    [SerializeField] private float grappleCameraInfluence;
    [SerializeField] private float grappleEndForce;
    private Vector3 inheritedPlayerVelocity;
    private Vector3 grappleAddSpeed;

    public CameraRollEffects rollEffects;

    [Header("Aditional Physics")]
    [SerializeField] public Vector3 leftOverVelocity;
    [SerializeField] private float drag;
    [SerializeField] private float airDrag;
    [SerializeField] private float universalDecayAmt;
    [SerializeField] private bool waitForCarryVelocityBeforeMove;

    //nat's vars
    private Vector3 lastMove;
    private Vector3 airMove;
    public float airSpeed;
    public float airMovementMod;
    public float groundedDrag;


    [Header("Misc")]
    [SerializeField] private FallManager fallM;

    // Use this for initialization
    private void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_Camera = Camera.main;
        m_OriginalCameraPosition = m_Camera.transform.localPosition;
        m_FovKick.Setup(m_Camera);
        m_HeadBob.Setup(m_Camera, m_StepInterval);
        m_StepCycle = 0f;
        m_NextStep = m_StepCycle / 2f;
        m_Jumping = false;
        m_AudioSource = GetComponent<AudioSource>();
        m_MouseLook.Init(transform, m_Camera.transform);
        grapplePosition = Vector3.zero;
        grappling = false;
        grappleSpeed = initialGrappleSpeed;
        grappleAddSpeed = Vector3.zero;
        fallM = GetComponent<FallManager>();
    }


    // Update is called once per frame
    private void Update()
    {

        // the jump state needs to read here to make sure it is not missed
        if (!m_Jump && m_CharacterController.isGrounded)
        {
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }

        //Double jump
        if (can_doublejump && !m_doublejump && !m_CharacterController.isGrounded && doubleJumpTimer > doubleJumpDelay)
        {
            m_doublejump = CrossPlatformInputManager.GetButtonDown("Jump");

        }

        if (!m_PreviouslyGrounded && m_CharacterController.isGrounded)
        {
            StartCoroutine(m_JumpBob.DoBobCycle());
            PlayLandingSound();
            m_MoveDir.y = 0f;
            m_Jumping = false;
            doubleJumpTimer = 0;
            can_doublejump = true;
            m_doublejumping = false;
            rollEffects.vectorAdditions.x += 10f;
        }

        if (!m_CharacterController.isGrounded && !grappling)
        {
            doubleJumpTimer += Time.deltaTime;
        }

        if (!m_CharacterController.isGrounded && !m_Jumping && !m_doublejumping && m_PreviouslyGrounded && !grappling)
        {
            m_MoveDir.y = 0f;
        }

        m_PreviouslyGrounded = m_CharacterController.isGrounded;
    }

    private void LateUpdate()
    {
        RotateView();
    }

    private void PlayLandingSound()
    {
        m_AudioSource.clip = m_LandSound;
        m_AudioSource.Play();
        m_NextStep = m_StepCycle + .5f;
        if(fallM != null)
        {
            //fallM.originalPosition = transform.position;
        }
    }


    private void FixedUpdate()
    {
        float speed;
        GetInput(out speed);
        // always move along the camera forward as it is the direction that it being aimed at
        Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;

        //Air Control while carrying over velocity
        if (waitForCarryVelocityBeforeMove)
        {
            desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;
            if (leftOverVelocity.magnitude > m_WalkSpeed)
            {
                desiredMove = desiredMove * 0.2f;
            }
        }

        // get a normal for the surface that is being touched to move along it
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                           m_CharacterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

        //Get the grapple vector
        Vector3 grappleVal = Vector3.zero;
        if (grappling && grapplePosition != Vector3.zero)
        {
            grappleVal = grapplePosition - transform.position;
            grappleVal = grappleVal.normalized;
        }

        //movetowards to make the movement flow
        if (m_CharacterController.isGrounded)
        {
            lastMove = Vector3.MoveTowards(lastMove, desiredMove, groundedDrag * Time.fixedDeltaTime);

            m_MoveDir.x = lastMove.x * speed;
            m_MoveDir.z = lastMove.z * speed;

            airMove = lastMove;
        }
        else
        {
            print(desiredMove);
            airMove = Vector3.MoveTowards(airMove, desiredMove * airSpeed, airDrag * Time.fixedDeltaTime);

            m_MoveDir.x = airMove.x;
            m_MoveDir.z = airMove.z;
        }

        

        


        if (m_CharacterController.isGrounded)
        {
            m_MoveDir.y = -m_StickToGroundForce;

            if (m_Jump)
            {
                m_MoveDir.y = m_JumpSpeed;
                PlayJumpSound();
                m_Jump = false;
                m_Jumping = true;
            }
        }
        else
        {
            //Double Jump
            if (m_doublejump && !grappling)
            {
                m_MoveDir.y = m_doublejump_speed;
                can_doublejump = false;
                m_doublejump = false;
                rollEffects.vectorAdditions.x += 15f;
                m_doublejumping = true;
                PlayDoubleJumpSound();
            }
            //Add gravity while in the air, but not when grappling
            if (!grappling && AddDirVector == Vector3.zero)
            {
                m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
            }
        }

        dirVector = Vector3.MoveTowards(dirVector, AddDirVector, dirVectorSpeed);
        if (dirVector != Vector3.zero)
        {
            m_MoveDir = dirVector;
        }

        //Handling the grapple vectors
        if (grappleVal != Vector3.zero && grappling)
        {
            grappleSpeed += grappleAcceleration * Time.fixedDeltaTime;
            grappleSpeed = Mathf.Clamp(grappleSpeed, 0, maxGrappleSpeed);
            grappleAddSpeed.y = Mathf.Clamp(grappleAddSpeed.y, -maxGrappleSpeed, maxGrappleSpeed);
            grappleAddSpeed += Physics.gravity * grappleGravityModifier * Time.fixedDeltaTime;

            float dot = Vector3.Dot(grappleVal, m_Camera.transform.forward);
            dot = Mathf.Clamp(dot, -0.5f, 1);
            dot = Remap(dot, -0.5f, 1f, 0, 1f);




            m_MoveDir = (grappleVal * grappleSpeed) + grappleAddSpeed + inheritedPlayerVelocity + (m_Camera.transform.forward * grappleCameraInfluence * (1 - Mathf.Pow(dot, 10f)));




            if (Vector3.Distance(transform.position, grapplePosition) < grappleCutDistance)
            {
                ResetGrapple();
                leftOverVelocity += m_Camera.transform.forward * grappleEndForce;

            }

        }

        //If we hit the ceiling, set the vertical speed of the leftover velocity to zero
        if ((m_CharacterController.collisionFlags & (CollisionFlags.Above)) != 0)
        {
            leftOverVelocity.y = 0;
            m_MoveDir.y = -1;
        }

        if (m_CharacterController.isGrounded)
        {
            leftOverVelocity = Vector3.MoveTowards(leftOverVelocity, Vector3.zero, drag * Time.fixedDeltaTime);
        }
        else
        {
            leftOverVelocity = Vector3.MoveTowards(leftOverVelocity, Vector3.zero, airDrag * Time.fixedDeltaTime);
        }



        m_CollisionFlags = m_CharacterController.Move((m_MoveDir + leftOverVelocity) * Time.fixedDeltaTime);

        ProgressStepCycle(speed);
        UpdateCameraPosition(speed);

        m_MouseLook.UpdateCursorLock();
        AddDirVector = Vector3.zero;
    }

    public float Remap(float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        var fromAbs = from - fromMin;
        var fromMaxAbs = fromMax - fromMin;

        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = toMax - toMin;
        var toAbs = toMaxAbs * normal;

        var to = toAbs + toMin;

        return to;
    }

    public void ResetGrapple()
    {

        grappling = false;
        grappleSpeed = initialGrappleSpeed;
        grapplePosition = Vector3.zero;
        grappleAddSpeed = Vector3.zero;
        leftOverVelocity.x = m_MoveDir.x;
        leftOverVelocity.z = m_MoveDir.z;

        can_doublejump = true;
        //leftOverVelocity.y = m_MoveDir.y;

    }

    private void PlayJumpSound()
    {
        m_AudioSource.clip = m_JumpSound;
        m_AudioSource.Play();
    }

    public void GiveCurrentPlayerVelocityToGrapple()
    {
        leftOverVelocity.x = m_MoveDir.x;
        leftOverVelocity.z = m_MoveDir.z;
        //grappleAddSpeed.y = m_MoveDir.y;
    }

    private void ProgressStepCycle(float speed)
    {
        if (m_CharacterController.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
        {
            m_StepCycle += (m_CharacterController.velocity.magnitude + (speed * (m_IsWalking ? 1f : m_RunstepLenghten))) *
                         Time.fixedDeltaTime;
        }

        if (!(m_StepCycle > m_NextStep))
        {
            return;
        }

        m_NextStep = m_StepCycle + m_StepInterval;

        PlayFootStepAudio();
    }


    private void PlayFootStepAudio()
    {
        if (!m_CharacterController.isGrounded)
        {
            return;
        }
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }

    private void PlayDoubleJumpSound()
    {
        m_AudioSource.PlayOneShot(doubleJumpClip);
    }


    private void UpdateCameraPosition(float speed)
    {
        Vector3 newCameraPosition;
        if (!m_UseHeadBob)
        {
            return;
        }
        if (m_CharacterController.velocity.magnitude > 0 && m_CharacterController.isGrounded)
        {
            m_Camera.transform.localPosition =
                m_HeadBob.DoHeadBob(m_CharacterController.velocity.magnitude +
                                  (speed * (m_IsWalking ? 1f : m_RunstepLenghten)));
            newCameraPosition = m_Camera.transform.localPosition;
            newCameraPosition.y = m_Camera.transform.localPosition.y - m_JumpBob.Offset();
        }
        else
        {
            newCameraPosition = m_Camera.transform.localPosition;
            newCameraPosition.y = m_OriginalCameraPosition.y - m_JumpBob.Offset();
        }
        m_Camera.transform.localPosition = newCameraPosition;
    }


    private void GetInput(out float speed)
    {
        // Read input
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        bool waswalking = m_IsWalking;

#if !MOBILE_INPUT
        // On standalone builds, walk/run speed is modified by a key press.
        // keep track of whether or not the character is walking or running
        m_IsWalking = !Input.GetKey(KeyCode.LeftShift);
#endif
        // set the desired speed to be walking or running
        speed = m_IsWalking ? m_WalkSpeed : m_RunSpeed;
        m_Input = new Vector2(horizontal, vertical);

        // normalize input if it exceeds 1 in combined length:
        if (m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }

        // handle speed change to give an fov kick
        // only if the player is going to a run, is running and the fovkick is to be used
        if (m_IsWalking != waswalking && m_UseFovKick && m_CharacterController.velocity.sqrMagnitude > 0)
        {
            StopAllCoroutines();
            StartCoroutine(!m_IsWalking ? m_FovKick.FOVKickUp() : m_FovKick.FOVKickDown());
        }
    }


    private void RotateView()
    {
        if (MenuPause.GamePaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }
        m_MouseLook.LookRotation(transform, m_Camera.transform);
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        //dont move the rigidbody if the character is on top of it
        if (m_CollisionFlags == CollisionFlags.Below)
        {
            return;
        }

        if (body == null || body.isKinematic)
        {
            return;
        }
        body.AddForceAtPosition(m_CharacterController.velocity * 0.1f, hit.point, ForceMode.Impulse);
    }
}

