using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected AIBrain brain = null;
    
    protected virtual void Awake()
    {
        brain = transform.parent.parent.parent.GetComponent<AIBrain>();
    }

    /// <summary>
    /// Return boolean that is the decision for the next status update
    /// <br>
    ///     (Function called on every frame when in current state)
    /// </br>
    /// </summary>
    /// <returns></returns>
    public abstract bool MakeDecision();
}
