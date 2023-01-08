using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    protected AIBrain brain;

    protected virtual void Awake()
    {
        brain = transform.parent.parent.GetComponent<AIBrain>();
    }
    
    /// <summary>
    /// Action to take when in current state
    /// <br>
    ///     (Function called on every frame when in current state)
    /// </br>
    /// </summary>
    public abstract void TakeAction(); 
}
