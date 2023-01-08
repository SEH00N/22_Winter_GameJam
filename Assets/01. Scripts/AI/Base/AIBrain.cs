using UnityEngine;

public class AIBrain : MonoBehaviour
{
    [SerializeField] AIState currentState = null;
    public Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        currentState.UpdateState(); //상태 업데이트
    }

    public void ChangeToState(AIState targetState) //상태 변경
    {
        currentState = targetState;
    }
}
