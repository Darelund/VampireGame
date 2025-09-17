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
                currentState.ExitState();
                currentState = state;
                currentState.EnterState();
                return;
            }
        }
        Debug.LogWarning("New state not found");
    }
    public virtual void UpdateStateMachine() => currentState?.UpdateState();
    public bool IsState<aState>()
    {
        if (!currentState) return false;
        return currentState.GetType() == typeof(aState);    
    }
}
