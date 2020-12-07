using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.UI;

public class GrapplingHand : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private CyberSpaceFirstPerson charController;
    [SerializeField] private Camera playerCam;
    [Header("Grappling Hook")]
    [SerializeField] private float grapplingRange;
    [SerializeField] private GameObject grapplingHookPrefab;
    [SerializeField] private Transform grapplingHookStart;
    private GrapplingLineRenderer grappleRend;
    private GameObject grapplingHookInstance;
    [Header("Misc.")]
    public LayerMask rayCastLayerMask;
    public Animator animator;
    [SerializeField]
    private Transform worldTarget;
    [SerializeField]
    private Canvas myCanvas;
    [SerializeField]
    private Transform myElement;
    [SerializeField]
    private float iconMoveSpeed;

    Quaternion originalRotation;
    [SerializeField]
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        originalRotation = transform.localRotation;

    }

    // Update is called once per frame
    void Update()
    {
        HandleGrapple();
        GetCanGrapple();
        UpdateIconPosition();
    }

    void GetCanGrapple()
    {
        RaycastHit hit;
        myElement.gameObject.SetActive(false);
        if (Physics.SphereCast(playerCam.transform.position, 2f, playerCam.transform.forward, out hit, grapplingRange, rayCastLayerMask))
        {
            if (hit.transform.tag == "Grapple" && !charController.IsGrappling)
            {
                worldTarget = hit.transform;
                myElement.gameObject.SetActive(true);
            }
        }
    }

    Vector3 GetGrapplePosition()
    {
        RaycastHit hit;
        if (Physics.SphereCast(playerCam.transform.position, 2f, playerCam.transform.forward, out hit, grapplingRange, rayCastLayerMask))
        {
            if (hit.transform != null && hit.transform.tag == "Grapple")
            {
                return hit.point;
            }
        }

        return Vector3.zero;
    }

    void HandleGrapple()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !charController.IsGrappling && !animator.GetNextAnimatorStateInfo(0).IsName("Hands|grappling_anim"))
        {
            Vector3 grapplePosition = GetGrapplePosition();
            if (grapplePosition != Vector3.zero)
            {
                animator.SetBool("isGrappling", true);
            }
        }

        if (charController.IsGrappling && !Input.GetKey(KeyCode.Q))
        {
            charController.ResetGrapple();
            if (grappleRend != null)
            {
                Destroy(grapplingHookInstance);
            }

        }

        if (!charController.IsGrappling && !Input.GetKey(KeyCode.Q) && animator.GetBool("isGrappling"))
        {
            animator.SetBool("isGrappling", false);
            if (grappleRend != null)
            {
                Destroy(grapplingHookInstance);
            }

        }

        
        if (charController.IsGrappling)
        {
            if (grappleRend != null)
            {
                grappleRend.origin.position = grapplingHookStart.position;
            }
        }

        Quaternion targetRotation = originalRotation;
        /*if (charController.IsGrappling && grappleRend != null)
        {
            Vector3 dir = (grappleRend.desination.position - grapplingHookStart.position).normalized;
            Quaternion target = Quaternion.LookRotation(dir);
            Vector3 targetAngles = new Vector3(target.eulerAngles.x, 0, 0);
            targetRotation = Quaternion.Euler(targetAngles);
        }*/
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);


    }

    void BeginGrapple()
    {
        Vector3 grapplePosition = GetGrapplePosition();
        if (grapplePosition != Vector3.zero && Input.GetKey(KeyCode.Q))
        {

            charController.IsGrappling = true;
            charController.GrapplePosition = grapplePosition;
            charController.GiveCurrentPlayerVelocityToGrapple();

            grapplingHookInstance = Instantiate(grapplingHookPrefab);
            grappleRend = grapplingHookInstance.GetComponentInChildren<GrapplingLineRenderer>();
            grappleRend.desination.position = grapplePosition;
            CameraShaker.Instance.Shake(CameraShakePresets.Shot);


        }
    }

    void UpdateIconPosition()
    {
        if (worldTarget != null)
        {
            //myElement.transform.position = Vector3.Slerp(myElement.transform.position, worldToUISpace(myCanvas, worldTarget.transform.position), iconMoveSpeed * Time.deltaTime);
            myElement.transform.position = Vector3.MoveTowards(myElement.transform.position, worldToUISpace(myCanvas, worldTarget.transform.position), iconMoveSpeed * Time.deltaTime);
        }
    }

    public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos)
    {
        //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        //Convert the screenpoint to ui rectangle local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        //Convert the local point to world point
        return parentCanvas.transform.TransformPoint(movePos);
    }
}
