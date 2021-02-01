using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class Hackable : MonoBehaviour
{
    public float hackTimeMod = 1;
    public bool triggered;
    public bool canUse;
    public float coolDownTime;
    [SerializeField]
    private bool allowCooldown;

    public UnityEvent myEvents;

    [SerializeField]
    public bool enableHackCost;

    [SerializeField]
    [Range(1,25)]
    public int hackCost;
    [SerializeField]
    [ReadOnly]
    public Gradient hackGradient;

    
    private const int maxHackCost = 25;

    public int MaxHackCost
    {
        get { return maxHackCost; }
    }
      

    public virtual void Interact()
    {
        if (allowCooldown)
        {
            StartCoroutine("CoolDown");
        }
        else
        {
            canUse = false;
        }
        myEvents.Invoke();
    }

    private void Start()
    {
        canUse = true;
        SetGradientRarityColors();
    }

    public IEnumerator CoolDown()
    {
        canUse = false;
        yield return new WaitForSeconds(coolDownTime);
        canUse = true;
    }

    private void OnValidate()
    {
        SetGradientRarityColors();
    }

    void SetGradientRarityColors()
    {
        GradientColorKey[] colorKey = new GradientColorKey[5];
        GradientAlphaKey[] alphaKey = new GradientAlphaKey[5];
        Color[] rarityColors = new Color[5];
        
        //White
        rarityColors[0] = CreateColor(255f, 255f, 255f,2f);
        //Green
        rarityColors[1] = CreateColor(29f, 153f, 62f , 2f);
        //Blue
        rarityColors[2] = CreateColor(32f, 121f, 221f, 2f);
        //Purple
        rarityColors[3] = CreateColor(234, 29f , 211f, 2f);
        //Orange
        rarityColors[4] = CreateColor(225, 131f, 14f, 2f);

        

        for(int i = 0; i < rarityColors.Length; i++)
        {
            colorKey[i].color = rarityColors[i];
            colorKey[i].time = (float) (i + 1) / rarityColors.Length;
            alphaKey[i].alpha = 1f;
            alphaKey[i].time = colorKey[i].time;
            
        }
        if (hackGradient != null)
        {
            hackGradient.SetKeys(colorKey, alphaKey);
            hackGradient.mode = GradientMode.Fixed;
        }

    }

    public Color CreateColor(float r, float b, float g, float i)
    {
        return new Color((r / 255f) * i, (b / 255f) * i, (g / 255f) * i);
    }


}

public class ReadOnlyAttribute : PropertyAttribute
{

}





