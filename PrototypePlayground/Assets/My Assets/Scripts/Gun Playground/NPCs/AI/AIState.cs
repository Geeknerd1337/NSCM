using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/State")]
public class AIState : ScriptableObject
{
    public AIAction[] actions;
    public AITransition[] transitions;
    public Color sceneGizmoColor = Color.gray;

    public void UpdateState(AIEntity controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(AIEntity controller)
    {
        for(int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }
    
    private void CheckTransitions(AIEntity controller)
    {
        for(int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if (decisionSucceeded)
            {
                controller.TransitionToState(transitions[i].trueState);
            }
            else
            {
                controller.TransitionToState(transitions[i].falseState);
            }
        }
    }
}
