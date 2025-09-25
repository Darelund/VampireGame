using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private List<State> states;
    private State currentState;

    public void SwitchState<aState>()
    {
       foreach (var state in states)
        {
            if(state.GetType() == typeof(aState))
            {
                if(currentState != null)
                currentState.ExitState();
                currentState = state;
                currentState.EnterState();
                return;
            }
        }
        Debug.LogWarning("New state not found");
    }
    public virtual void UpdateStateMachine() => currentState?.UpdateState();
    public virtual void LateUpdateStateMachine() => currentState?.LateUpdateState();
    public bool IsState<aState>()
    {
        if (!currentState) return false;
        return currentState.GetType() == typeof(aState);    
    }
}
