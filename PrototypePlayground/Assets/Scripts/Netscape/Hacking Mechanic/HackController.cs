using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HackController : MonoBehaviour
{

    #region Private Members
    private Transform cameraTransform;
    private Transform worldTarget;
    private Hackable currentHackable;
    private float initialElementScale;
    [SerializeField]
    private Canvas myCanvas;
    [SerializeField]
    private float hackRange;
    [SerializeField]
    private Transform myElement;
    [SerializeField]
    private LayerMask sphereMask;
    [SerializeField]
    private LayerMask rayMask;
    [SerializeField]
    private float hackRayThickness;
    [SerializeField]
    private float iconMoveSpeed;
    [SerializeField]
    private Image fillImage;
    [SerializeField]
    private Image myElementImage;
    [SerializeField]
    private float hackTime;
    private float hackTimer;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private Image fullyFilledImage;
    [SerializeField]
    private float filledAlphaSpeed;
    [SerializeField]
    private AudioSource riseSound;
    [SerializeField]
    private AudioSource typeSound;
    [SerializeField]
    private AudioSource successSound;
    [SerializeField]
    private AnimationCurve pitchCurve;
    [SerializeField]
    private Text hackCostText;
    [SerializeField]
    private Animator hackHandAnimator;
    [SerializeField]
    private bool enableHackAnimations;
    private PlayerStats playerStats;
    
    #endregion

    #region Public Members

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        UIMaster UI = FindObjectOfType<UIMaster>();
        myCanvas = UI.gameObject.GetComponent<Canvas>();
        myElement = UI.hackElement;
        fillImage = UI.hackRadialElement;
        fullyFilledImage = UI.hackFillElement;
        initialElementScale = myElement.transform.localScale.x;
        myElementImage = UI.hackElement.GetComponent<Image>();
        hackCostText = UI.hackElement.GetComponentInChildren<Text>();
        playerStats = UIMaster.playerStats;
           
    }

    // Update is called once per frame
    void Update()
    {
        CheckForHack();
        UpdateIconPosition();
        Interact();
    }

    void Interact()
    {
        if (Input.GetKey(KeyCode.Q) && worldTarget != null && currentHackable.canUse)
        {
            if (currentHackable.enableHackCost)
            {
                
                if(playerStats.Hack < currentHackable.hackCost)
                {
                    return;
                }
            }
            if (hackTimer < hackTime)
            {
                hackTimer += Time.deltaTime * currentHackable.hackTimeMod;

                if (riseSound.isPlaying)
                {
                    riseSound.pitch = Mathf.Lerp(0.8f, 1.1f, pitchCurve.Evaluate(hackTimer / hackTime));
                }
            }
            if (!riseSound.isPlaying)
            {
                riseSound.Play();
                typeSound.Play();
            }
        }
        else
        {
            if (hackTimer > 0)
            {
                hackTimer -= Time.deltaTime * 2f;
            }
            riseSound.Stop();
            typeSound.Stop();
        }

        if(hackTimer > hackTime)
        {
            Color c = fullyFilledImage.color;
            c.a = 1;
            fullyFilledImage.color = c;
            currentHackable.Interact();
            successSound.Play();
            hackTimer = 0;
            riseSound.Stop();
            typeSound.Stop();
            hackHandAnimator.Play("Hands|hack_quick_success");
            playerStats.Hack -= currentHackable.hackCost;
        }

        UpdateFill(hackTimer / hackTime);
    }
    void CheckForHack()
    {
        worldTarget = null;
        myElement.gameObject.SetActive(false);
        RaycastHit hit;
        if(Physics.SphereCast(transform.position,hackRayThickness,transform.forward, out hit, hackRange, sphereMask)){
            RaycastHit rayHit;
            
            if(Physics.SphereCast(transform.position,hackRayThickness * 0.1f,transform.forward,out rayHit, hackRange, rayMask))
            {
               
                if (rayHit.distance > hit.distance)
                {
                    Hackable myHackable = null;
                    myHackable = hit.transform.GetComponent<Hackable>();
                    if (myHackable != null && myHackable.canUse)
                    {
                        worldTarget = hit.transform;
                        currentHackable = myHackable;
                        myElement.gameObject.SetActive(true);
                        //Debug.Log("Ray Hit: " + rayHit.distance + " Name: " + rayHit.transform.name);
                        //Debug.Log("Hit Distance: " + hit.distance + "Name: " + rayHit.transform.name);
                    }

                }
            }
            else
            {
                Hackable myHackable = null;
                    myHackable = hit.transform.GetComponent<Hackable>();
                    if (myHackable != null && myHackable.canUse)
                    {
                        worldTarget = hit.transform;
                        currentHackable = myHackable;
                        myElement.gameObject.SetActive(true);
                    }
            }
        }
    }

    void UpdateFill(float f)
    {
        fillImage.fillAmount = f;
        rotateSpeed = Mathf.Lerp(0, 400f, f);
        myElement.transform.localScale = Vector3.one * Mathf.Lerp(initialElementScale, initialElementScale * 0.9f, f);
        Color c = fullyFilledImage.color;
        c.a = Mathf.Lerp(c.a, 0, Time.deltaTime * filledAlphaSpeed);
        fullyFilledImage.color = c;

        //This is some experimentation with the animator
        if (enableHackAnimations && f > 0)
        {
            if (f < 1)
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    hackHandAnimator.Play("Hands|hack_quick", -1, f);
                }
                else
                {
                    hackHandAnimator.Play("Hands | third_arm_idle");
                }
            }
        }

        //Essentially, this says whether or not we have a hackable in our sights and if it uses hack sot
        if (currentHackable != null && currentHackable.enableHackCost)
        {
            //If it does, then use the rarity gradient to set a color based on its price
            Color cc = currentHackable.hackGradient.Evaluate(currentHackable.hackCost / (float)currentHackable.MaxHackCost);
            myElementImage.color = cc;
            fillImage.color = cc;
            //Set the text to be the cost of the hack
            hackCostText.text = currentHackable.hackCost.ToString();
            //This just makes the text invisible if we're hacking, then moves the alpha of the text back to one if we're not
            if (f > 0)
            {
                hackCostText.text = "";
                Color hackTextColor = hackCostText.color;
                hackTextColor.a = 0;
                hackCostText.color = hackTextColor;

                
            }
            else
            {
                Vector3 currentRotation = new Vector3(myElement.transform.eulerAngles.x, myElement.transform.eulerAngles.y, myElement.transform.eulerAngles.z);
                if (currentRotation.z <= 0.1f)
                {
                    Color hackTextColor = hackCostText.color;
                    hackTextColor.a = Mathf.Lerp(hackTextColor.a, 1f, Time.deltaTime * (filledAlphaSpeed / 2f)); ;
                    hackCostText.color = hackTextColor;
                }
            }
        }
        else
        {
            fillImage.color = Color.white;
            myElementImage.color = Color.white;
            hackCostText.text = "";
        }
    }

    void UpdateIconPosition()
    {
        if (worldTarget != null)
        {
            //myElement.transform.position = Vector3.Slerp(myElement.transform.position, worldToUISpace(myCanvas, worldTarget.transform.position), iconMoveSpeed * Time.deltaTime);
            myElement.transform.position = Vector3.MoveTowards(myElement.transform.position,worldToUISpace(myCanvas, worldTarget.transform.position), iconMoveSpeed * Time.deltaTime);
        }
        Vector3 currentRotation = new Vector3(myElement.transform.eulerAngles.x, myElement.transform.eulerAngles.y, myElement.transform.eulerAngles.z);
        if (rotateSpeed != 0)
        {
            currentRotation.z += currentHackable.hackTimeMod * rotateSpeed * Time.deltaTime;
        }
        else
        {
            currentRotation.z = Mathf.LerpAngle(currentRotation.z, 0, 10 * Time.deltaTime);
        }
        myElement.transform.eulerAngles = currentRotation;
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
