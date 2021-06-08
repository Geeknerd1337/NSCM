using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "AI/Decisions/Animation Ended")]
public class AnimationEndDecision : AIDecision
{
    public string animation;
    public override bool Decide(AIEntity controller)
    {
        return AnimationEnded(controller);
    }

    private bool AnimationEnded(AIEntity controller)
    {
        Animator animator = controller.EntityAnimator;
        if(animator != null)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(animation) &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                return true;
            }
        }
        return false;

    }
}
